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

        private struct SellParams
        {
            public int pos;

            public Microsoft.DirectX.DirectInput.Key direction;

            public int times;
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
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);

        private Thread fishingThread;

        private volatile bool quitFishing = false;

        private Thread sellThread;

        private volatile bool quitSell = false;

        private readonly Config config = new Config();

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
                keyMapping = KeyMapping.load(config.GameInstallPath);
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
            quitFishing = false;
            fishingThread = new Thread(new ParameterizedThreadStart(this.Fishing));
            fishingThread.Start(param);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (fishingThread != null)
            {
                quitFishing = true;
                fishingThread.Join();
                fishingThread = null;
            }
        }

        public void Fishing(Object obj)
        {
            FishingParams param = (FishingParams)obj;
            richTextBox1.AppendText("钓鱼开始!\r\n");
            richTextBox1.ScrollToCaret();
            using (Capture capture = new Capture(param.rect))
            {
                for (int remaining = param.times; remaining > 0 && !quitFishing; remaining--)
                {
                    keyInput.pressKey(keyMapping.Button2);
                    string text = "鱼跑掉了\r\n";
                    DateTime start = DateTime.Now;
                    try
                    {
                        while (!quitFishing)
                        {
                            if (capture.HasColorInRect(COLOR_THRESHOLD))
                            {
                                keyInput.pressKey(keyMapping.Button2);
                                text = "HITS\r\n";
                                break;
                            }
                            if ((DateTime.Now - start).TotalMilliseconds > 15000)
                            {
                                break;
                            }
                            Thread.Yield();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        goto EndFishing;
                    }
                    richTextBox1.AppendText(remaining + ". " + text);
                    richTextBox1.ScrollToCaret();
                    Thread.Sleep(5000);
                    if (quitFishing)
                    {
                        return;
                    }
                    keyInput.pressKey(keyMapping.Button2);
                    Thread.Sleep(2000);
                    if (quitFishing)
                    {
                        return;
                    }
                    keyInput.pressKey(keyMapping.Button2);
                    Thread.Sleep(500);
                }
            }
        EndFishing:
            richTextBox1.AppendText("钓鱼结束!\r\n");
            richTextBox1.ScrollToCaret();
        }

        private IntPtr initWindowHandle()
        {
            Process[] ps = Process.GetProcessesByName(config.ProcessName);
            if (ps.Length == 0)
            {
                return IntPtr.Zero;
            }
            Process p = ps[0];
            return p.MainWindowHandle;
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            IntPtr edaoWnd = initWindowHandle();
            if (edaoWnd.Equals(IntPtr.Zero))
            {
                MessageBox.Show(this, "游戏没有启动");
                return;
            }
            Rect wndRect = new Rect();
            GetWindowRect(edaoWnd, out wndRect);
            int left = Int32.Parse(textBoxLeft.Text);
            int top = Int32.Parse(textBoxTop.Text);
            int length = Int32.Parse(textBoxLength.Text);
            Rectangle cropRect = new Rectangle(wndRect.Left + left, wndRect.Top + top, length, length);
            using (Capture capture = new Capture(cropRect))
            {
                Image oldImage = pictureBoxCapture.Image;
                pictureBoxCapture.Image = capture.Crop();
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            if (sellThread != null && sellThread.IsAlive)
            {
                MessageBox.Show(this, "已经在卖鱼");
                return;
            }
            try
            {
                keyMapping = KeyMapping.load(config.GameInstallPath);
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
            int pos;
            try
            {
                pos = Int32.Parse(textBoxPos.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "必须输入一个1-30之间的位置");
                return;
            }
            if (pos < 1 || pos > 30)
            {
                MessageBox.Show(this, "必须输入一个1-30之间的次数");
                return;
            }
            int times;
            try
            {
                times = Int32.Parse(textBoxSellTimes.Text);
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
            SellParams param = new SellParams();
            param.pos = pos;
            param.times = times;
            if (radioButtonUp.Checked)
            {
                param.direction = keyMapping.ButtonUp;
            }
            else if (radioButtonDown.Checked)
            {
                param.direction = keyMapping.ButtonDown;
            }
            else
            {
                MessageBox.Show(this, "请选择方向");
                return;
            }
            SetForegroundWindow(edaoWnd);
            Thread.Sleep(1000);
            quitSell = false;
            sellThread = new Thread(new ParameterizedThreadStart(this.Sell));
            sellThread.Start(param);
        }

        private void sellOne(SellParams param)
        {
            for (int i = 0; i < param.pos && !quitSell; i++)
            {
                keyInput.pressKey(param.direction);
                Thread.Sleep(200);
            }
            for (int i = 0; i < 4 && !quitSell; i++)
            {
                keyInput.pressKey(keyMapping.Button2);
                Thread.Sleep(i == 2 ? 2000 : 1000);
            }
        }
        public void Sell(Object obj)
        {
            SellParams param = (SellParams)obj;
            for (int i = 0; i < param.times && !quitSell; i++)
            {
                sellOne(param);
                textBoxSellTimes.Text = (param.times - i - 1).ToString();
            }
        }

        private void buttonStopSell_Click(object sender, EventArgs e)
        {
            if (sellThread != null)
            {
                quitSell = true;
                sellThread.Join();
                sellThread = null;
            }
        }
    }
}
