using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AudioPerformer
{
    //该类需手动进行垃圾回收，继承Idisposable接口
    class SoundTouch : IDisposable
    {
        #region 字段

        //文件句柄
        private IntPtr handle;
        //Soundtouch 版本
        private string versionString;
        //位数是否64
        private readonly bool is64Bit;

        #endregion

        #region 属性

        public SoundTouch()
        {
            //初始化时，判断电脑句柄大小，为8代表电脑是64位的，为4代表电脑是32位的
            is64Bit = Marshal.SizeOf<IntPtr>() == 8;

            //创建与位数对应的SoundTouch processor，soundtouch_createInstance()函数
            handle = is64Bit ? SoundTouchInterop64.soundtouch_createInstance() :
                SoundTouchInterop32.soundtouch_createInstance();
        }

        //获取soundtouch版本号
        public string VersionString
        {
            get
            {
                if (versionString == null)
                {
                    var s = new StringBuilder(100);
                    if (is64Bit)
                        SoundTouchInterop64.soundtouch_getVersionString2(s, s.Capacity);
                    else
                        SoundTouchInterop32.soundtouch_getVersionString2(s, s.Capacity);
                    versionString = s.ToString();
                }
                return versionString;
            }
        }

        #endregion



        //设置与原始音高相比的音高变化（以八度为单位）,pitchOctaves值限定在-1.00到1.00间
        public void SetPitchOctaves(float pitchOctaves)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setPitchOctaves(handle, pitchOctaves);
            else
                SoundTouchInterop32.soundtouch_setPitchOctaves(handle, pitchOctaves);
        }

        //设置采样率
        public void SetSampleRate(int sampleRate)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setSampleRate(handle, (uint)sampleRate);
            else
                SoundTouchInterop32.soundtouch_setSampleRate(handle, (uint)sampleRate);
        }

        //设置声道，1为单声道，2为立体声道
        public void SetChannels(int channels)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setChannels(handle, (uint)channels);
            else
                SoundTouchInterop32.soundtouch_setChannels(handle, (uint)channels);
        }

        //销毁实例
        private void DestroyInstance()
        {
            if (handle != IntPtr.Zero)
            {
                if (is64Bit)
                    SoundTouchInterop64.soundtouch_destroyInstance(handle);
                else
                    SoundTouchInterop32.soundtouch_destroyInstance(handle);
                handle = IntPtr.Zero;
            }
        }

        //销毁实例
        public void Dispose()
        {
            DestroyInstance();
            //手动回收非托管内存，禁用垃圾回收器
            GC.SuppressFinalize(this);
        }

        //析构函数，调用销毁函数
        ~SoundTouch()
        {
            DestroyInstance();
        }

        //
        public void PutSamples(float[] samples, int numSamples)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_putSamples(handle, samples, numSamples);
            else
                SoundTouchInterop32.soundtouch_putSamples(handle, samples, numSamples);
        }

        //
        public int ReceiveSamples(float[] outBuffer, int maxSamples)
        {
            if (is64Bit)
                return (int)SoundTouchInterop64.soundtouch_receiveSamples(handle, outBuffer, (uint)maxSamples);
            return (int)SoundTouchInterop32.soundtouch_receiveSamples(handle, outBuffer, (uint)maxSamples);
        }

        //句柄是否为空，只读
        public bool IsEmpty
        {
            get
            {
                if (is64Bit)
                    return SoundTouchInterop64.soundtouch_isEmpty(handle) != 0;
                return SoundTouchInterop32.soundtouch_isEmpty(handle) != 0;
            }
        }

        //可用采样数
        public int NumberOfSamplesAvailable
        {
            get
            {
                if (is64Bit)
                    return (int)SoundTouchInterop64.soundtouch_numSamples(handle);
                return (int)SoundTouchInterop32.soundtouch_numSamples(handle);
            }
        }

        //未播放的采样数
        public int NumberOfUnprocessedSamples
        {
            get
            {
                if (is64Bit)
                    return SoundTouchInterop64.soundtouch_numUnprocessedSamples(handle);
                return SoundTouchInterop32.soundtouch_numUnprocessedSamples(handle);
            }
        }

        public void Flush()
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_flush(handle);
            else
                SoundTouchInterop32.soundtouch_flush(handle);
        }

        public void Clear()
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_clear(handle);
            else
                SoundTouchInterop32.soundtouch_clear(handle);
        }

        public void SetRate(float newRate)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setRate(handle, newRate);
            else
                SoundTouchInterop32.soundtouch_setRate(handle, newRate);
        }

        public void SetTempo(float newTempo)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setTempo(handle, newTempo);
            else
                SoundTouchInterop32.soundtouch_setTempo(handle, newTempo);
        }

        public int GetUseAntiAliasing()
        {
            if (is64Bit)
                return SoundTouchInterop64.soundtouch_getSetting(handle, SoundTouchSettings.UseAaFilter);
            return SoundTouchInterop32.soundtouch_getSetting(handle, SoundTouchSettings.UseAaFilter);
        }

        public void SetUseAntiAliasing(bool useAntiAliasing)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setSetting(handle, SoundTouchSettings.UseAaFilter, useAntiAliasing ? 1 : 0);
            else
                SoundTouchInterop32.soundtouch_setSetting(handle, SoundTouchSettings.UseAaFilter, useAntiAliasing ? 1 : 0);
        }

        public void SetUseQuickSeek(bool useQuickSeek)
        {
            if (is64Bit)
                SoundTouchInterop64.soundtouch_setSetting(handle, SoundTouchSettings.UseQuickSeek, useQuickSeek ? 1 : 0);
            else
                SoundTouchInterop32.soundtouch_setSetting(handle, SoundTouchSettings.UseQuickSeek, useQuickSeek ? 1 : 0);
        }

        public int GetUseQuickSeek()
        {
            if (is64Bit)
                return SoundTouchInterop64.soundtouch_getSetting(handle, SoundTouchSettings.UseQuickSeek);
            return SoundTouchInterop32.soundtouch_getSetting(handle, SoundTouchSettings.UseQuickSeek);
        }
    }
}
