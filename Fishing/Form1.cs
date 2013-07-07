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

namespace Capture
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern UInt32 SendInput(UInt32 nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public Int32 type;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 mouseData;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }

        private const int INPUT_KEYBOARD = 1;
        private const int KEYEVENTF_KEYUP = 0x0002;
        private const int KEYEVENTF_SCANCODE = 0x0008;

        private static INPUT initKeyDown(Microsoft.DirectX.DirectInput.Key key)
        {
            INPUT keyDown = new INPUT();
            keyDown.type = INPUT_KEYBOARD;
            keyDown.ki.wScan = (Int16)key;
            keyDown.ki.dwFlags = KEYEVENTF_SCANCODE;
            return keyDown;
        }

        private static INPUT initKeyUp(Microsoft.DirectX.DirectInput.Key key)
        {
            INPUT keyUp = new INPUT();
            keyUp.type = INPUT_KEYBOARD;
            keyUp.ki.wScan = (Int16)key;
            keyUp.ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
            return keyUp;
        }
        private static INPUT[] J_DOWN = new INPUT[1] { initKeyDown(Microsoft.DirectX.DirectInput.Key.J) };

        private static INPUT[] J_UP = new INPUT[1] { initKeyUp(Microsoft.DirectX.DirectInput.Key.J) };

        private static INPUT[] W_DOWN = new INPUT[1] { initKeyDown(Microsoft.DirectX.DirectInput.Key.W) };

        private static INPUT[] W_UP = new INPUT[1] { initKeyUp(Microsoft.DirectX.DirectInput.Key.W) };

        private static Point POINT_FANCY_CARP = new Point(325, 275);

        private static Point POINT_RAINBOW_TROUT = new Point(250, 300);

        private static Size RECTANGLE_SIZE = new Size(50, 40);

        public struct FishingParams
        {
            public int times;

            public int baitPos;

            public Point point;

            public Size size;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private IntPtr edaoWnd;

        private volatile bool quit = false;

        private Thread fishingThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!initWindowHandle())
            {
                MessageBox.Show(this, "ED_AO not started");
                return;
            }
            if (fishingThread != null)
            {
                MessageBox.Show(this, "Already start");
                return;
            }
            int times;
            try
            {
                times = Int32.Parse(textBoxTimes.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.ToString());
                return;
            }
            if (times <= 0)
            {
                MessageBox.Show(this, "times must be positive");
                return;
            }
            int baitPos;
            try
            {
                baitPos = Int32.Parse(textBoxBaitPos.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.ToString());
                return;
            }
            if (baitPos <= 0)
            {
                MessageBox.Show(this, "baitPos must be positive");
                return;
            }
            FishingParams param = new FishingParams();
            param.times = times;
            param.baitPos = baitPos;
            param.size = RECTANGLE_SIZE;
            if (radioButtonFancyCarp.Checked)
            {
                param.point = POINT_FANCY_CARP;
            }
            else
            {
                param.point = POINT_RAINBOW_TROUT;
            }
            SetForegroundWindow(edaoWnd);
            Thread.Sleep(1000);
            quit = false;
            fishingThread = new Thread(new ParameterizedThreadStart(this.fishing));
            fishingThread.Start(param);
        }

        private void button2_Click(object sender, EventArgs e)
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
            richTextBox1.AppendText("Starting!\r\n");
            richTextBox1.ScrollToCaret();
            FishingParams param = (FishingParams)obj;
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.PresentFlag = PresentFlag.LockableBackBuffer;
            presentParams.BackBufferWidth = 1600;
            presentParams.BackBufferHeight = 900;
            presentParams.MultiSample = MultiSampleType.None;
            presentParams.DeviceWindowHandle = this.Handle;

            for (int i = 0; i < 4; i++)
            {
                pressKeyJ();
                Thread.Sleep(2000);
            }
            pressKeyW();
            Thread.Sleep(2000);
            for (int i = 0; i < 2; i++)
            {
                pressKeyJ();
                Thread.Sleep(2000);
            }
            for (int i = 0; i < param.baitPos; i++)
            {
                pressKeyW();
                Thread.Sleep(500);
            }

            for (int i = param.times; i > 0 && !quit; i--)
            {
                pressKeyJ();
                string text = "Missing!\r\n";
                for (int j = 0; j < 200 && !quit; j++)
                {
                    Device device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
                    Surface surface = device.CreateOffscreenPlainSurface(1600, 900, Format.A8R8G8B8, Pool.SystemMemory);
                    device.GetFrontBufferData(0, surface);   //copy   frontsurface   to   mySurface
                    GraphicsStream gStr = Microsoft.DirectX.Direct3D.SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, surface);
                    Bitmap image = (Bitmap)Bitmap.FromStream(gStr);
                    gStr.Close();
                    gStr.Dispose();
                    surface.ReleaseGraphics();
                    surface.Dispose();
                    device.Dispose();
                    for (int x = 0; x < param.size.Width; x++)
                    {
                        for (int y = 0; y < param.size.Height; y++)
                        {
                            Color color = image.GetPixel(param.point.X + x, param.point.Y + y);
                            if (color.R > 250 && color.G > 50 && color.B > 40)
                            {
                                pressKeyJ();
                                text = "Hitting!\r\n";
                                image.Dispose();
                                goto outer;
                            }
                        }
                    }
                    image.Dispose();
                    Thread.Sleep(50);
                }
            outer:
                richTextBox1.AppendText(i + ". " + text);
                richTextBox1.ScrollToCaret();
                Thread.Sleep(5000);
                pressKeyJ();
                Thread.Sleep(2000);
                pressKeyJ();
                Thread.Sleep(500);
            }
            richTextBox1.AppendText("Quiting!\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void pressKeyJ()
        {
            SendInput(1, J_DOWN, Marshal.SizeOf(J_DOWN[0]));
            Thread.Sleep(100);
            SendInput(1, J_UP, Marshal.SizeOf(J_UP[0]));
        }

        private void pressKeyW()
        {
            SendInput(1, W_DOWN, Marshal.SizeOf(W_DOWN[0]));
            Thread.Sleep(100);
            SendInput(1, W_UP, Marshal.SizeOf(W_UP[0]));
        }

        private bool initWindowHandle()
        {
            Process[] ps = Process.GetProcessesByName("ED_AO");
            if (ps.Length == 0)
            {
                return false;
            }
            Process p = ps[0];
            edaoWnd = p.MainWindowHandle;
            return true;
        }

    }
}
