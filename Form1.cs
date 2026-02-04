using AxWMPLib;
using Global;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;
using static Global.EasyObject;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// https://lets-csharp.com/windows-media-player-key-mouse/
namespace MyMediaPlayer
{
    public partial class Form1 : Form
    {
        AxWMPLib.AxWindowsMediaPlayer MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
        System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.StartPosition = FormStartPosition.Manual;
            Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;
            this.ClientSize = new Size((int)(screen.Width * 0.75), (int)(screen.Height * 0.75)); /**/
            //this.Size = new Size((int)(screen.Width * 0.75), (int)(screen.Height * 0.75)); /**/
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            this.Size = new Size(w, h);
            //AllocConsole();
            Log("ハロー©");
            // Windows Media Playerコントロールの名前を mediaPlayer と仮定
            //axWindowsMediaPlayer1.enableContextMenu = false; // Disable the Default Context Menu 
            //axWindowsMediaPlayer1.MouseUp += MediaPlayer_MouseUp;
            //axWindowsMediaPlayer1.ContextMenuStrip = contextMenuStrip1;
            // メニューの名前を contextMenuStrip1 と仮定
            //contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            this.AllowDrop = true;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            Timer.Start();

            //trackBar1.ValueChanged += TrackBar1_ValueChanged;
            //trackBar1.KeyDown += TrackBar1_KeyDown;

            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            //trackBar1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            //// axWindowsMediaPlayer1.uiMode = "none"; /* 外観のユーザインタフェースを消す */
            //axWindowsMediaPlayer1.settings.autoStart = true; /* 自動開始をオンにする */
            //axWindowsMediaPlayer1.Ctlenabled = true;            // ダブルクリックによるフルスクリーン出力を無効化
            //axWindowsMediaPlayer1.enableContextMenu = true;     // 右クリックによるコンテキストメニューの出力を無効化
            //MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();

            panel1.Dock = DockStyle.Fill;
            panel1.Controls.Add(this.MediaPlayer);

            MediaPlayer.Dock = DockStyle.Fill;

            // UIを無効化
            //MediaPlayer.uiMode = "none";

            // 右クリックによるコンテキストメニューの出力を無効化
            //MediaPlayer.enableContextMenu = false;
            SetWMPVolume(100);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            var curMedia = MediaPlayer.currentMedia;
            if (curMedia != null)
            {
                string sourceURL = curMedia.sourceURL;
                //Log(sourceURL, "sourceURL");
                string fileName = Path.GetFileName(sourceURL);
                //Log(fileName, "fileName");
                if (this.Text != fileName)
                {
                    this.Text = fileName;
                }
                int duration = (int)MediaPlayer.currentMedia.duration;
                int curPosition = (int)MediaPlayer.Ctlcontrols.currentPosition;
                TimeSpan span1 = new TimeSpan(0, 0, duration);
                TimeSpan span2 = new TimeSpan(0, 0, curPosition);
                toolStripLabel1.Text = String.Format("{0} / {1}  ", span2.ToString(), span1.ToString());
                toolStripLabel2.Text = sourceURL;
            }
            else
            {
                toolStripLabel1.Text = "";
                toolStripLabel2.Text = "";
            }
        }
        //private void TrackBar1_ValueChanged(object sender, EventArgs e)
        //{
        //    int misalignment = (int)Math.Abs(MediaPlayer.Ctlcontrols.currentPosition - trackBar1.Value);
        //    if (misalignment > 2)
        //    {
        //        SetCurrentPositionTrackBarValue();
        //    }
        //}
        //void SetCurrentPositionTrackBarValue()
        //{
        //    MediaPlayer.Ctlcontrols.currentPosition = trackBar1.Value;
        //    MediaPlayer.Ctlcontrols.play();
        //    MediaPlayer.Ctlcontrols.pause();
        //}
        //// 一時停止状態から再生状態に戻す手段も用意しておかなければなりません。スペースキーをおせば一時停止と再生を切り替えることができるようにします。
        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    // キーの本来の処理をさせたくないときは、trueを返す
        //    if ((keyData & Keys.KeyCode) == Keys.Space)
        //    {
        //        if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
        //            MediaPlayer.Ctlcontrols.play();
        //        else
        //            MediaPlayer.Ctlcontrols.pause();
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData & Keys.KeyCode) == Keys.Space)
            {
                if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                    MediaPlayer.Ctlcontrols.play();
                else
                    MediaPlayer.Ctlcontrols.pause();
                return true;
            }
            if ((keyData & Keys.KeyCode) == Keys.C)
                CopyMediaPlayerInfo();
            if ((keyData & Keys.KeyCode) == Keys.Left)
                OnKeyDownLeft();
            if ((keyData & Keys.KeyCode) == Keys.Right)
                OnKeyDownRight();

            return base.ProcessDialogKey(keyData);
        }
        void CopyMediaPlayerInfo()
        {
            var curMedia = MediaPlayer.currentMedia;
            if (curMedia != null)
            {
                string sourceURL = curMedia.sourceURL;
                int duration = (int)MediaPlayer.currentMedia.duration;
                int curPosition = (int)MediaPlayer.Ctlcontrols.currentPosition;
                TimeSpan span1 = new TimeSpan(0, 0, duration);
                TimeSpan span2 = new TimeSpan(0, 0, curPosition);
                string str = String.Format(
                    "ファイルパス：{0}\n長さ：{1}\n現在位置：{2}",
                    sourceURL, span1.ToString(), span2.ToString());
                Clipboard.SetText(str);
            }
        }
        void OnKeyDownLeft()
        {
            double value = MediaPlayer.Ctlcontrols.currentPosition;
            if (Control.ModifierKeys != Keys.Control)
                value--;
            else
                value -= 10;

            if (value > 0)
            {
                MediaPlayer.Ctlcontrols.currentPosition = value;
            }
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                MediaPlayer.Ctlcontrols.play();
        }
        void OnKeyDownRight()
        {
            double value = MediaPlayer.Ctlcontrols.currentPosition;
            if (Control.ModifierKeys != Keys.Control)
                value++;
            else
                value += 10;
            if (value < MediaPlayer.currentMedia.duration)
            {
                MediaPlayer.Ctlcontrols.currentPosition = value;
            }
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                MediaPlayer.Ctlcontrols.play();
        }
        //private void MediaPlayer_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        contextMenuStrip1.Show(axWindowsMediaPlayer1, e.Location);
        //    }
        //}
        // メニューが表示される直前に状態を更新する場合
        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 例: 再生状態に応じてメニュー項目を有効/無効にする
            //contextMenuStrip1.Items["再生ToolStripMenuItem"].Enabled = !(axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPlaying);
        }
        // メニュー項目クリック時の処理例
        private void SetWMPVolume(int volume)
        {
            // Ensure volume is within the valid range (0 to 100)
            if (volume >= 0 && volume <= 100)
            {
                MediaPlayer.settings.volume = volume;
            }
            else
            {
                // Handle invalid input if necessary
                Console.WriteLine("Volume must be between 0 and 100.");
            }
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    MediaPlayer.URL = @"C:\Users\user\Music\@1080p\[1080p]  Balo TikTok 【抖音背包】 『Everytime We Touch (Original Mix) - xxxCr3 ｜ 2022抖音最火的歌曲 ｜ Trending TikTok』 【ID：TQ_oIxIDKTA】.mp4";
        //    //axWindowsMediaPlayer1.Ctlcontrols.play();
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Media Files|*.mp3;*.m4a;*.wma;*.wav;*.mp4;*.wmv|All Files|*.*";
        //    openFileDialog.Multiselect = true; // Allow multiple selections
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        // 1. Create a new, empty playlist in the library
        //        IWMPPlaylist myPlayList = MediaPlayer.playlistCollection.newPlaylist("MyPlayList");
        //        // 2. Iterate through the selected files
        //        foreach (string file in openFileDialog.FileNames)
        //        {
        //            // Create a new media item from the file path
        //            IWMPMedia mediaItem = MediaPlayer.newMedia(file);

        //            // Add the media item to the playlist
        //            myPlayList.appendItem(mediaItem);
        //        }
        //        // 3. Set the newly created playlist as the current playlist to start playback
        //        MediaPlayer.currentPlaylist = myPlayList;
        //        // Optional: Start playback (it might start automatically depending on control settings)
        //        MediaPlayer.Ctlcontrols.play();
        //    }
        //}

        //private void 再生ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MediaPlayer.Ctlcontrols.play();
        //}

        //private void 一時停止ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MediaPlayer.Ctlcontrols.pause();
        //}
        //// ファイルがドラッグアンドドロップされようとしているときで、ファイルの拡張子が.mp4のときだけファイルのパスを返します。それ以外のときは空文字列を返します。
        //string GetMp4FilePath(DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        //        string filePath = files[0];
        //        FileInfo info = new FileInfo(filePath);
        //        if (info.Extension.ToLower() == ".mp4")
        //            return filePath;
        //    }
        //    return "";
        //}
        //private void Form1_DragOver(object sender, DragEventArgs e)
        //{
        //    if (GetMp4FilePath(e) != "")
        //        e.Effect = DragDropEffects.Copy;
        //    else
        //        e.Effect = DragDropEffects.None;
        //    base.OnDragOver(e);
        //}
        //private void Form1_DragDrop(object sender, DragEventArgs e)
        //{
        //    string filePath = GetMp4FilePath(e);
        //    if (filePath != "")
        //    {
        //        MediaPlayer.URL = filePath;
        //    }
        //    base.OnDragDrop(e);
        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MediaPlayer.URL = @"C:\Users\user\Music\@1080p\[1080p]  Balo TikTok 【抖音背包】 『Everytime We Touch (Original Mix) - xxxCr3 ｜ 2022抖音最火的歌曲 ｜ Trending TikTok』 【ID：TQ_oIxIDKTA】.mp4";
            //axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Media Files|*.mp3;*.wma;*.wav;*.mp4;*.wmv|All Files|*.*";
            openFileDialog.Filter = "Media Files|*.mp3;*.m4a;*.wma;*.wav;*.mp4;*.wmv|All Files|*.*";
            openFileDialog.Multiselect = true; // Allow multiple selections
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 1. Create a new, empty playlist in the library
                IWMPPlaylist myPlayList = MediaPlayer.playlistCollection.newPlaylist("MyPlayList");
                // 2. Iterate through the selected files
                foreach (string file in openFileDialog.FileNames)
                {
                    // Create a new media item from the file path
                    IWMPMedia mediaItem = MediaPlayer.newMedia(file);

                    // Add the media item to the playlist
                    myPlayList.appendItem(mediaItem);
                }
                // 3. Set the newly created playlist as the current playlist to start playback
                MediaPlayer.currentPlaylist = myPlayList;
                // Optional: Start playback (it might start automatically depending on control settings)
                MediaPlayer.Ctlcontrols.play();
            }
        }

    }
}
