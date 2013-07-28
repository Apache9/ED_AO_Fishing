using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Diagnostics;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Runtime.InteropServices;

namespace Fishing
{
    public partial class Form1 : Form
    {
        private static readonly Color COLOR_THRESHOLD = Color.FromArgb(250, 50, 40);

        private struct FishingParams
        {
            public int times;

            public Rectangle rect;
        }
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);

        private volatile bool quit = false;

        private Thread fishingThread;

        private Config config = new Config();

        private KeyMapping keyMapping;

        private readonly FishingPlace fishingPlace;

        private readonly KeyInput keyInput = new KeyInput();

        private readonly List<RadioButton> fishingPlaceRadioButtons;

        private List<RadioButton> initFishingPlaceRadioButton()
        {
            List<RadioButton> rbs = new List<RadioButton>();
            foreach (string s in fishingPlace.allPlace())
            {
                RadioButton rb = new RadioButton();
                rb.AutoSize = true;
                rb.Location = new System.Drawing.Point(18, 22 * (rbs.Count + 1));
                rb.Name = s;
                rb.Size = new System.Drawing.Size(50, 16);
                rb.TabStop = false;
                rb.Text = s;
                rb.UseVisualStyleBackColor = true;
                rbs.Add(rb);
                this.flowLayoutPanel.Controls.Add(rb);
            }
            return rbs;
        }

        public Form1()
        {
            InitializeComponent();
            fishingPlace = new FishingPlace();
            fishingPlaceRadioButtons = initFishingPlaceRadioButton();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (fishingThread != null && fishingThread.IsAlive)
            {
                MessageBox.Show(this, "已经在钓鱼");
                return;
            }
            try
            {
                string gameInstallDirectory = config.getGameInstallPath();
                keyMapping = KeyMapping.load(gameInstallDirectory);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "加载按键配置错误，请重新指定游戏安装路径");
                return;
            }
            IntPtr edaoWnd = initWindowHandle();
            if (edaoWnd.Equals(IntPtr.Zero))
            {
                MessageBox.Show(this, "游戏没有启动");
                return;
            }
            int times;
            try
            {
                times = Int32.Parse(textBoxTimes.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "必须输入一个1-99之间的次数");
                return;
            }
            if (times < 1 || times > 99)
            {
                MessageBox.Show(this, "必须输入一个1-99之间的次数");
                return;
            }
            FishingParams param = new FishingParams();
            param.times = times;
            bool selected = false;
            foreach (RadioButton rb in fishingPlaceRadioButtons)
            {
                if (rb.Checked)
                {
                    Rect wndRect = new Rect();
                    GetWindowRect(edaoWnd, out wndRect);
                    Rectangle captureRect = fishingPlace.getRect(rb.Name);
                    param.rect = new Rectangle(wndRect.Left + captureRect.Left, wndRect.Top + captureRect.Top, captureRect.Width, captureRect.Height);
                    selected = true;
                    break;
                }
            }
            if (!selected)
            {
                MessageBox.Show(this, "请选择钓鱼地点");
                return;
            }
            SetForegroundWindow(edaoWnd);
            Thread.Sleep(1000);
            quit = false;
            fishingThread = new Thread(new ParameterizedThreadStart(this.fishing));
            fishingThread.Start(param);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (fishingThread != null)
            {
                quit = true;
                fishingThread.Join();
                fishingThread = null;
            }
        }

        public void fishing(Object obj)
        {
            FishingParams param = (FishingParams)obj;
            int interval = config.getCaptureInterval();
            int maxRound = config.getMaxWait() / interval;
            richTextBox1.AppendText("钓鱼开始!\r\n");
            richTextBox1.ScrollToCaret();
            Capture capture = new Capture();
            for (int remaining = param.times; remaining > 0 && !quit; remaining--)
            {
                keyInput.pressKey(keyMapping.getButton2Key());
                string text = "鱼跑掉了\r\n";
                for (int round = 0; round < maxRound && !quit; round++)
                {
                    if (capture.hasColorInRect(COLOR_THRESHOLD, param.rect))
                    {
                        keyInput.pressKey(keyMapping.getButton2Key());
                        text = "HITS\r\n";
                        break;
                    }
                    Thread.Sleep(interval);
                }
                richTextBox1.AppendText(remaining + ". " + text);
                richTextBox1.ScrollToCaret();
                Thread.Sleep(5000);
                keyInput.pressKey(keyMapping.getButton2Key());
                Thread.Sleep(2000);
                keyInput.pressKey(keyMapping.getButton2Key());
                Thread.Sleep(500);
            }

            richTextBox1.AppendText("钓鱼结束!\r\n");
            richTextBox1.ScrollToCaret();
        }

        private IntPtr initWindowHandle()
        {
            Process[] ps = Process.GetProcessesByName("ED_AO");
            if (ps.Length == 0)
            {
                return IntPtr.Zero;
            }
            Process p = ps[0];
            return p.MainWindowHandle;
        }
    }
}
