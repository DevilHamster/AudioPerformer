using System;
using NAudio.Wave;

namespace AudioPerformer
{
    //播放采样提供类
    //继承NAudio的ISampleProvider接口，需实现Read方法和WaveFormat属性
    class VarispeedSampleProvider : ISampleProvider, IDisposable
    {
        private readonly ISampleProvider sourceProvider; //一个ISampleProvider对象，本类的核心
        private readonly SoundTouch soundTouch;
        private readonly float[] sourceReadBuffer; //采样数据存放数组
        private readonly float[] soundTouchReadBuffer; //soundTouch的采样数据存放数组
        private readonly int channelCount; //声道数
        private float playbackRate = 1.0f; //速度设置
        private SoundTouchProfile currentSoundTouchProfile;
        private bool repositionRequested;

        public VarispeedSampleProvider(ISampleProvider sourceProvider, int readDurationMilliseconds, SoundTouchProfile soundTouchProfile)
        {
            soundTouch = new SoundTouch();
            // explore what the default values are before we change them:
            //Debug.WriteLine(String.Format("SoundTouch Version {0}", soundTouch.VersionString));
            //Debug.WriteLine("Use QuickSeek: {0}", soundTouch.GetUseQuickSeek());
            //Debug.WriteLine("Use AntiAliasing: {0}", soundTouch.GetUseAntiAliasing());

            SetSoundTouchProfile(soundTouchProfile);
            this.sourceProvider = sourceProvider;
            soundTouch.SetSampleRate(WaveFormat.SampleRate);
            channelCount = WaveFormat.Channels;
            soundTouch.SetChannels(channelCount);
            //sourceReadBuffer，数组大小 = 音频采样率*声道数*时长(毫秒为单位) / 1000
            sourceReadBuffer = new float[(WaveFormat.SampleRate * channelCount * (long)readDurationMilliseconds) / 1000];
            //soundTouchReadBuffer，数组大小为sourceReadBuffer的10倍，即整个音频所有采样的1/100
            soundTouchReadBuffer = new float[sourceReadBuffer.Length * 10]; // support down to 0.1 speed
        }

        //读取采样数据，送入音频输出给buffer，count为每次送入的采样数量
        /*
         * Read函数在播放过程中每隔一段时间调用一次，做了以下几件事：
         * 1.更新buffer数组(read函数必须有的功能)
         * 2.确保每次read，soundTouchReadBuffer都能往前更新一轮
         */
        public int Read(float[] buffer, int offset, int count)
        {
            //如果倍速为0，即不播放
            if (playbackRate == 0) // play silence
            {
                for (int n = 0; n < count; n++)
                {
                    buffer[offset++] = 0;
                }
                return count;
            }

            //如果重置
            //soundTouch清除所有采样输出
            if (repositionRequested)
            {
                soundTouch.Clear();
                repositionRequested = false;
            }

            int samplesRead = 0; //已读取采样数量
            bool reachedEndOfSource = false; //标记是否读取完成

            //确保已读取采样数小于count
            while (samplesRead < count)
            {
                //如果soundTouchReadBuffer里的是音频最后一段采样，用sourceProvider看当前有没有播放完(sourceProvider只是个临时容器)
                if (soundTouch.NumberOfSamplesAvailable == 0)
                {
                    //sourceReadBuffer  
                    var readFromSource = sourceProvider.Read(sourceReadBuffer, 0, sourceReadBuffer.Length);
                    //
                    if (readFromSource > 0)
                    {
                        soundTouch.PutSamples(sourceReadBuffer, readFromSource / channelCount);
                    }
                    //整个音频文件播放完毕，关闭
                    else
                    {
                        reachedEndOfSource = true;
                        soundTouch.Flush();
                    }
                }


                var desiredSampleFrames = (count - samplesRead) / channelCount;

                //soundTouchReadBuffer更新，一次read读取多少数据就更新多少
                var received = soundTouch.ReceiveSamples(soundTouchReadBuffer, desiredSampleFrames) * channelCount;
                //soundTouchReadBuffer向buffer注水
                for (int n = 0; n < received; n++)
                {
                    buffer[offset + samplesRead++] = soundTouchReadBuffer[n];
                }
                if (received == 0 && reachedEndOfSource) break;
            }
            return samplesRead;
        }

        public WaveFormat WaveFormat => sourceProvider.WaveFormat;

        public float PlaybackRate
        {
            get
            {
                return playbackRate;
            }
            set
            {
                if (playbackRate != value)
                {
                    UpdatePlaybackRate(value);
                    playbackRate = value;
                }
            }
        }

        private void UpdatePlaybackRate(float value)
        {
            if (value != 0)
            {
                if (currentSoundTouchProfile.UseTempo)
                {
                    soundTouch.SetTempo(value);
                }
                else
                {
                    soundTouch.SetRate(value);
                }
            }
        }

        public void Dispose()
        {
            soundTouch.Dispose();
        }

        /*
         *配置soundTouchProfile和soundTouch设定，包括：
         *1.变速变调/变速不变调播放，soundTouch.SetRate控制变速变调下的倍速，soundTouch.SetTempo控制变速不变调下的倍速，在使用其中一个函数时，另一个函数参数需设置为1.0
         */
        public void SetSoundTouchProfile(SoundTouchProfile soundTouchProfile)
        {
            //如果有现有设定，且播放速度不为1.0，且要新设定UseTempo值不等于既有设定，变更变速参数
            //只有这三个条件同时满足，才有必要重新设定变速参数
            if (currentSoundTouchProfile != null &&
                playbackRate != 1.0f &&
                soundTouchProfile.UseTempo != currentSoundTouchProfile.UseTempo)
            {
                //如果新设定使用变速不变调，则：rate参数为1.0，不变调，通过设置tempo实现仅变速播放
                if (soundTouchProfile.UseTempo)
                {
                    soundTouch.SetRate(1.0f);
                    soundTouch.SetPitchOctaves(0f);
                    soundTouch.SetTempo(playbackRate);
                }
                //如果新设定使用变速变调，则：tempo参数为1.0，通过设置rate实现变速又变调播放
                else
                {
                    soundTouch.SetTempo(1.0f);
                    soundTouch.SetRate(playbackRate);
                }
            }
            this.currentSoundTouchProfile = soundTouchProfile;
            soundTouch.SetUseAntiAliasing(soundTouchProfile.UseAntiAliasing);
            soundTouch.SetUseQuickSeek(soundTouchProfile.UseQuickSeek);
        }

        public void Reposition()
        {
            repositionRequested = true;
        }
    }
}