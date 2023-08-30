using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using System.Globalization;
using System.Diagnostics;
using NAudio.CoreAudioApi;

namespace AudioPerformer
{
    public partial class frmMain : Form
    {
        //专辑封面显示
        Bitmap bitmap = null;

        //声明一个list以存放文件路径
        List<string> directionList = new List<string>();
        //记录当前播放的音乐的路径
        string currentDirPlaying = null;
        //创建一个WaveOutEvent对象
        WaveOutEvent waveOut = new WaveOutEvent();
        //创建音频文件读取实例
        AudioFileReader audioFileReader;
        //采样提供
        private VarispeedSampleProvider speedControl;

        //变速模式
        bool isTempo = true;

        //曲目信息
        string artists = null;
        string albums = null;
        string sorts = null;
        Tuple<string[], string[]> info = null;

        //播放模式枚举类
        enum PlayModeEnum
        {
            Sequential, //顺序播放
            Random, //随机播放
            SingleCycle //单曲循环
        }

        //播放模式，默认列表循环
        PlayModeEnum playMode = PlayModeEnum.Sequential;
        //用于随机播放
        Random rd = new Random();
        //现在是否在播放，开启播放后为true，暂停后显示为false
        bool isPlaying = false;

        //音频总时长
        TimeSpan timeSpan = new TimeSpan(0, 0, 0);
        //时长显示规格
        CultureInfo culture = new CultureInfo("en-US");

        //音频捕获
        WasapiCapture capture; 

        /// <summary>
        /// 窗体初始化
        /// </summary>
        public frmMain()
        {

            capture= new WasapiCapture(); //开始捕获声卡输出信息
            capture.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(8192, 1);      // 指定捕获的格式, 单声道, 32位深度, IeeeFloat 编码, 8192采样率

            InitializeComponent();

            //初始时计时器关闭
            timer1.Enabled = false;
            //初始时进度条清零
            barProcess._Min = 0;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 计时逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //更新lblProcess
            lblProcess.Text = audioFileReader.CurrentTime.ToString(@"hh\:mm\:ss", culture) + "/" + timeSpan.ToString(@"hh\:mm\:ss", culture);
            //更新进度条
            barProcess._Value = (int)Math.Round(barProcess._Max * (audioFileReader.CurrentTime.TotalSeconds / timeSpan.TotalSeconds));

            //一首歌播放到结束，执行next相同逻辑
            if (barProcess._Value >= barProcess._Max)
            {
                //如果播放模式为顺序播放
                if (playMode == PlayModeEnum.Sequential)
                {
                    //如果当前播放列表中最后一首，停止播放当前内容，播放第一首，更新currentDirPlaying和txtboxPlaying
                    if (directionList[directionList.Count - 1] == currentDirPlaying)
                    {
                        //停止播放音乐
                        waveOut.Stop();
                        //释放资源
                        waveOut.Dispose();
                        audioFileReader.Dispose();

                        AudioPlay(directionList[0]);
                        currentDirPlaying = directionList[0];
                        //正在播放:xxx
                        txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[0];
                    }
                    //否则，播放下一首，更新currentDirPlaying和txtboxPlaying
                    else
                    {
                        //停止播放音乐
                        waveOut.Stop();
                        //释放资源
                        waveOut.Dispose();
                        audioFileReader.Dispose();

                        //获取下一首的索引
                        int idx = getIndex(currentDirPlaying, directionList) + 1;
                        AudioPlay(directionList[idx]);
                        currentDirPlaying = directionList[idx];
                        //正在播放:xxx
                        txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];
                    }
                }
                //如果播放模式为单曲循环
                else if (playMode == PlayModeEnum.SingleCycle)
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();

                    //获取当前播放曲目索引
                    int idx = getIndex(currentDirPlaying, directionList);
                    AudioPlay(directionList[idx]);
                    currentDirPlaying = directionList[idx];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];
                }
                //如果播放模式为随机播放
                else if (playMode == PlayModeEnum.Random)
                {

                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();

                    //生成随机索引
                    int idx = rd.Next(0, directionList.Count);
                    AudioPlay(directionList[idx]);
                    currentDirPlaying = directionList[idx];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];
                }
            }
        }

        /// <summary>
        /// 在playlist中添加歌曲
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //实例化一个打开文件的对话框
            OpenFileDialog of = new OpenFileDialog();
            //允许多选
            of.Multiselect = true;
            //设置对话框标题
            of.Title = "Please choose a music file to play";
            //指定音乐文件类型
            of.Filter = "Audio Files|*.mp3;*.wav;*.ape";
            //显示对话框，如果选择"确定"
            if (of.ShowDialog() == DialogResult.OK)
            {
                //获取选中文件的路径
                string[] nameList = of.FileNames;
                //读取数组中的数据
                foreach (string dir in nameList)
                {
                    //listboxMusicList中显示不带后缀名的文件名
                    listboxPlaylist.Items.Add(Path.GetFileNameWithoutExtension(dir));
                    //音频文件列表更新
                    directionList.Add(dir);
                }
            }
        }

        /// <summary>
        /// Play键按下，摁键透明度变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_MouseDown(object sender, MouseEventArgs e)
        {
            btnPlay.BackColor = Color.FromArgb(50, btnPlay.BackColor.R, btnPlay.BackColor.G, btnPlay.BackColor.B);
        }
        /// <summary>
        /// Play键按下，播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            //列表中无歌曲载入，弹窗提示
             if (directionList.Count < 1)
            {
                MessageBox.Show("Please select the files to play."); return;
            }
            //列表中无选中歌曲，弹窗提示
            if (listboxPlaylist.SelectedIndex < 0)
            {
                MessageBox.Show("Please select one file to play."); return;
            }

            //如果当前无曲目在播放，播放音乐，改变图标为暂停
            if (isPlaying == false)
            {
                //图标变成暂停图标
                btnPlay.Image = Properties.Resources.pauseButton;

                if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    isPlaying = true; EnableControl(isPlaying);
                    waveOut.Play();
                    return;
                }

                //如果当前播放曲目不为空，并要播放新的曲目，则....
                if (currentDirPlaying != directionList[listboxPlaylist.SelectedIndex] && currentDirPlaying != null)
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();
                    //播放新选中的歌曲
                    AudioPlay(directionList[listboxPlaylist.SelectedIndex]);
                    currentDirPlaying = directionList[listboxPlaylist.SelectedIndex];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.SelectedItem.ToString();

                    isPlaying = true; EnableControl(isPlaying);
                    return;
                }
                else
                {
                    AudioPlay(directionList[listboxPlaylist.SelectedIndex]);
                    currentDirPlaying = directionList[listboxPlaylist.SelectedIndex];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.SelectedItem.ToString();

                    isPlaying = true; EnableControl(isPlaying);
                    return;
                }
            }

            //如果当前有曲目在播放，暂停音乐，改变图标为播放
            else
            {
                //改变图标
                btnPlay.Image = Properties.Resources.playButton;
                //暂停播放
                waveOut.Pause();
                //设置为未在播放状态
                isPlaying = false; EnableControl(isPlaying);
                return;
            }
        }

        #region 上一首和下一首功能实现
        /// <summary>
        /// Prev键按下，摁键透明度变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_MouseDown(object sender, MouseEventArgs e)
        {
            btnPrev.BackColor = Color.FromArgb(50, btnPrev.BackColor.R, btnPrev.BackColor.G, btnPrev.BackColor.B);
        }
        /// <summary>
        /// 按下Prev键，切换至上一首
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            //判断列表中有无歌曲，无则弹窗提示
            if (directionList.Count < 1)
            {
                MessageBox.Show("Please select the files to play."); return;
            }
            //判断当前列表中有无选中歌曲，无则弹窗提示
            if (listboxPlaylist.SelectedIndex < 0)
            {
                MessageBox.Show("Please select one file here in the playlist."); return;
            }
            //如果当前未在播放，弹窗提示
            if (currentDirPlaying == null)
            {
                MessageBox.Show("There is no current playing file."); return;
            }


            //如果播放模式为顺序播放
            if (playMode == PlayModeEnum.Sequential)
            {
                //如果当前播放列表中第一首，停止播放当前内容，播放最后一首，更新currentDirPlaying和txtboxPlaying
                if (directionList[0] == currentDirPlaying)
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();

                    AudioPlay(directionList[directionList.Count - 1]);
                    currentDirPlaying = directionList[directionList.Count - 1];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[directionList.Count - 1];

                    isPlaying = true; EnableControl(isPlaying);
                }
                //否则，播放上一首，更新currentDirPlaying和txtboxPlaying
                else
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();

                    //获取下一首的索引
                    int idx = getIndex(currentDirPlaying, directionList) - 1;
                    AudioPlay(directionList[idx]);
                    currentDirPlaying = directionList[idx];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];

                    isPlaying = true; EnableControl(isPlaying);

                }
            }
            //如果播放模式为单曲循环
            else if (playMode == PlayModeEnum.SingleCycle)
            {
                //停止播放音乐
                waveOut.Stop();
                //释放资源
                waveOut.Dispose();
                audioFileReader.Dispose();

                //获取当前播放曲目索引
                int idx = getIndex(currentDirPlaying, directionList);
                AudioPlay(directionList[idx]);
                currentDirPlaying = directionList[idx];
                //正在播放:xxx
                txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];

                isPlaying = true; EnableControl(isPlaying);
            }
            //如果播放模式为随机播放
            else if (playMode == PlayModeEnum.Random)
            {

                //停止播放音乐
                waveOut.Stop();
                //释放资源
                waveOut.Dispose();
                audioFileReader.Dispose();

                //生成随机索引
                int idx = rd.Next(0, directionList.Count);
                AudioPlay(directionList[idx]);
                currentDirPlaying = directionList[idx];
                //正在播放:xxx
                txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];

                isPlaying = true; EnableControl(isPlaying);
            }
        }

        /// <summary>
        /// Next键按下，摁键透明度变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_MouseDown(object sender, MouseEventArgs e)
        {
            btnNext.BackColor = Color.FromArgb(50, btnNext.BackColor.R, btnNext.BackColor.G, btnNext.BackColor.B);
        }
        /// <summary>
        /// 按下Next键，切换至下一首
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断列表中有无歌曲，无则弹窗提示
            if (directionList.Count < 1)
            {
                MessageBox.Show("Please select the files to play."); return;
            }
            //判断当前列表中有无选中歌曲，无则弹窗提示
            if (listboxPlaylist.SelectedIndex < 0)
            {
                MessageBox.Show("Please select one file here in the playlist."); return;
            }
            //如果当前未在播放，弹窗提示
            if (currentDirPlaying == null)
            {
                MessageBox.Show("There is no current playing file."); return;
            }

            //如果播放模式为顺序播放
            if (playMode == PlayModeEnum.Sequential)
            {
                //如果当前播放列表中最后一首，停止播放当前内容，播放第一首，更新currentDirPlaying和txtboxPlaying
                if (directionList[directionList.Count - 1] == currentDirPlaying)
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();

                    AudioPlay(directionList[0]);
                    currentDirPlaying = directionList[0];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[0];

                    isPlaying = true; EnableControl(isPlaying);
                }
                //否则，播放下一首，更新currentDirPlaying和txtboxPlaying
                else
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();

                    //获取下一首的索引
                    int idx = getIndex(currentDirPlaying, directionList) + 1;
                    AudioPlay(directionList[idx]);
                    currentDirPlaying = directionList[idx];
                    //正在播放:xxx
                    txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];

                    isPlaying = true; EnableControl(isPlaying);
                }
            }
            //如果播放模式为单曲循环
            else if (playMode == PlayModeEnum.SingleCycle)
            {
                //停止播放音乐
                waveOut.Stop();
                //释放资源
                waveOut.Dispose();
                audioFileReader.Dispose();

                //获取当前播放曲目索引
                int idx = getIndex(currentDirPlaying, directionList);
                AudioPlay(directionList[idx]);
                currentDirPlaying = directionList[idx];
                //正在播放:xxx
                txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];

                isPlaying = true; EnableControl(isPlaying);
            }
            //如果播放模式为随机播放
            else if (playMode == PlayModeEnum.Random)
            {

                //停止播放音乐
                waveOut.Stop();
                //释放资源
                waveOut.Dispose();
                audioFileReader.Dispose();

                //生成随机索引
                int idx = rd.Next(0, directionList.Count);
                AudioPlay(directionList[idx]);
                currentDirPlaying = directionList[idx];
                //正在播放:xxx
                txtboxPlaying.Text = "Playing: " + listboxPlaylist.Items[idx];

                isPlaying = true; EnableControl(isPlaying);
            }
        }
        #endregion

        /// <summary>
        /// 根据currentDirPlaying返回在directionList中的索引
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int getIndex(string path, List<string> list)
        {
            int temp = 0;
            for (int a = 0; a < list.Count; a++)
            {
                if (list[a] == path)
                {
                    temp = a;
                }
            }
            return temp;
        }

        /// <summary>
        /// 音频开始播放的方法
        /// </summary>
        private void AudioPlay(string path)
        {
            artists = null;

            //创建一个WaveOutEvent对象
            waveOut = new WaveOutEvent();
            //加载音频文件
            audioFileReader = new AudioFileReader(path);
            //设置采样提供
            speedControl = new VarispeedSampleProvider(audioFileReader, 100, new SoundTouchProfile(isTempo, false));

            waveOut.Init(speedControl);

            //播放音频
            waveOut.Play();
            isPlaying= true; EnableControl(isPlaying);
            lblSpeedMani.Text = "1.00";

            //每调用一次播放函数，获取音频时长，开启计时器，设定进度条长度(秒数)
            timer1.Enabled = true;
            timeSpan = audioFileReader.TotalTime;
            barProcess._Max = (int)timeSpan.TotalSeconds;

            //一旦播放，改变图标为暂停
            btnPlay.Image = Properties.Resources.pauseButton;

            //更新专辑封面
            ShowImage(path);

            //更新专辑信息
            info = Mp3FileReader.GetInfo(path);
            foreach (string str in info.Item1)
            {
                if (artists == null)
                {
                    artists = str;
                }
                else
                {
                    artists = artists + "/" + str;
                }
            }
            albums = info.Item2[0];
            sorts = info.Item2[1];
            lblArtists.Text = "Artist: " + artists;
            lblAlbum.Text = "Album: " + albums;
            lblSorts.Text = "Sorts: " + sorts;
        }

        /// <summary>
        /// 播放模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMode_Click_1(object sender, EventArgs e)
        {
            switch (playMode)
            {
                case PlayModeEnum.Sequential:
                    btnMode.Image = Properties.Resources.modeButton2;
                    playMode = PlayModeEnum.SingleCycle;
                    break;
                case PlayModeEnum.SingleCycle:
                    btnMode.Image = Properties.Resources.modeButton3;
                    playMode = PlayModeEnum.Random;
                    break;
                case PlayModeEnum.Random:
                    btnMode.Image = Properties.Resources.modeButton1;
                    playMode = PlayModeEnum.Sequential;
                    break;
            }
        }

        /// <summary>
        /// 进度条拖动/点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barProcess_ValueChanged(object sender, EH_TrackBarEventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.CurrentTime = new TimeSpan(0, 0, barProcess._Value);
            }
        }

        /// <summary>
        /// 播放列表，双击项目直接进行播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listboxPlaylist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listboxPlaylist.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                this.listboxPlaylist.SelectedIndex = index;//切换选中项
                
                //取消播放当前在播放的曲目
                if (isPlaying == true)
                {
                    //停止播放音乐
                    waveOut.Stop();
                    //释放资源
                    waveOut.Dispose();
                    audioFileReader.Dispose();
                }

                //播放选中曲目
                AudioPlay(directionList[listboxPlaylist.SelectedIndex]);
                currentDirPlaying = directionList[listboxPlaylist.SelectedIndex];
                //正在播放:xxx
                txtboxPlaying.Text = "Playing: " + listboxPlaylist.SelectedItem.ToString();

                //isPlaying = true;
                return;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 音量条变动，引起播放音量变动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barVol_ValueChanged(object sender, EH_TrackBarEventArgs e)
        {
            //在有曲目播放时变动音量
            if (isPlaying == true)
            {
                //瞬间暂停
                //waveOut.Pause();
                //改变音量
                waveOut.Volume = (float)barVol._Value / 10f;
                //继续播放
                //waveOut.Play();
            }
        }

        /// <summary>
        /// 倍速增加0.05
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpeedUp_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                if (speedControl.PlaybackRate < 3)
                {
                    speedControl.PlaybackRate += 0.05f;
                }
                lblSpeedMani.Text = $"{speedControl.PlaybackRate:F2}";
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 倍速减小0.05
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpeedDown_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                if (speedControl.PlaybackRate > 0.5)
                {
                    speedControl.PlaybackRate -= 0.05f;
                }
                lblSpeedMani.Text = $"{speedControl.PlaybackRate:F2}";
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 变速模式变成变速+变调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isTempo = false;
            tempoToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            speedToolStripMenuItem.BackColor = Color.FromArgb(100, 100, 100);
        }

        /// <summary>
        /// 变速模式变成变速不变调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isTempo = true;
            tempoToolStripMenuItem.BackColor = Color.FromArgb(100, 100, 100);
            speedToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
        }

        /// <summary>
        /// 音乐在播放时，无法切换speed/tempo和打开新文件
        /// </summary>
        /// <param name="isPlaying"></param>
        private void EnableControl(bool isPlaying)
        {
            settingsToolStripMenuItem.Enabled = !isPlaying;
            systemToolStripMenuItem.Enabled= !isPlaying;
        }

        /// <summary>
        /// 点击，直接重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearPlayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Process.GetCurrentProcess().Kill();
        }
        
        /// <summary>
        /// 根据文件路径，在界面上显示专辑封面信息
        /// </summary>
        /// <param name="path"></param>
        private void ShowImage(string path)
        {
            bitmap = Mp3FileReader.GetCover(path); 
            //如果有专辑封面，传入bitmap
            if (bitmap != null)
            {
                picBox.Image = Mp3FileReader.CircularCut(bitmap, Properties.Resources.disc);
            }
            //如果没有专辑封面
            else
            {
                picBox.Image = Properties.Resources.disc;
            }
        }
    }
}
