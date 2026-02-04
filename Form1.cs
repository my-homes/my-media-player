using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AxWMPLib;
using Global;
using static Global.EasyObject;

namespace MyMediaPlayer
{
    public partial class Form1 : Form
    {
        //WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            ReallocConsole();
            Log("ハロー©");
            // axWindowsMediaPlayer1.uiMode = "none"; /* 外観のユーザインタフェースを消す */
            axWindowsMediaPlayer1.settings.autoStart = true; /* 自動開始をオンにする */
            //this.mediaPlayer.settings.autoStart = true; /* 自動開始をオンにする */
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\user\Music\@1080p\[1080p]  Balo TikTok 【抖音背包】 『Everytime We Touch (Original Mix) - xxxCr3 ｜ 2022抖音最火的歌曲 ｜ Trending TikTok』 【ID：TQ_oIxIDKTA】.mp4";
            //axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var pl = axWindowsMediaPlayer1.playlistCollection.newPlaylist(@"C:\Users\user\Music\mine.m3u");
            //Echo(pl.count);
            //this.mediaPlayer.URL = @"C:\Users\user\Music\@1080p\[1080p]  Balo TikTok 【抖音背包】 『Everytime We Touch (Original Mix) - xxxCr3 ｜ 2022抖音最火的歌曲 ｜ Trending TikTok』 【ID：TQ_oIxIDKTA】.mp4";
            //this.mediaPlayer.controls.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
        }
    }
}
