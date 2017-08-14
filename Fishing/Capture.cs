using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Fishing
{
    class Capture : IDisposable
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

        private float GetScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int logicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float scalingFactor = (float)physicalScreenHeight / (float)logicalScreenHeight;

            return scalingFactor; // 1.25 = 125%
        }

        private readonly float scalingFactor;

        private readonly Rectangle cropRect;

        private readonly Device device;

        private readonly Surface surface;

        public Capture(Rectangle rect)
        {
            scalingFactor = GetScalingFactor();
            int screenWidth = (int)(Screen.PrimaryScreen.Bounds.Width * scalingFactor);
            int screenHeight = (int)(Screen.PrimaryScreen.Bounds.Height * scalingFactor);
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.PresentFlag = PresentFlag.LockableBackBuffer;
            presentParams.BackBufferWidth = screenWidth;
            presentParams.BackBufferHeight = screenHeight;
            presentParams.MultiSample = MultiSampleType.None;
            device = new Device(0, DeviceType.Hardware, null, CreateFlags.SoftwareVertexProcessing, presentParams);
            surface = device.CreateOffscreenPlainSurface(screenWidth, screenHeight, Format.A8R8G8B8, Pool.SystemMemory);
            cropRect = new Rectangle((int)(rect.Left * scalingFactor), (int)(rect.Top * scalingFactor), (int)(rect.Width * scalingFactor), (int)(rect.Height * scalingFactor));
        }

        private Bitmap CaptureScreen(Rectangle rect)
        {
            device.GetFrontBufferData(0, surface);
            GraphicsStream stream = Microsoft.DirectX.Direct3D.SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, surface, rect);
            try
            {
                return new Bitmap(stream);
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
        }

        // for finding the right rect to capture
        public Bitmap Crop()
        {
            using (Bitmap image = CaptureScreen(cropRect))
            {
                return new Bitmap(image);
            }
        }

        public bool HasColorInRect(Color colorThreshold)
        {
            int rLow = colorThreshold.R;
            int rHigh = colorThreshold.R + 30;
            int gLow = colorThreshold.G;
            int gHigh = colorThreshold.G + 30;
            int bLow = colorThreshold.B;
            int bHigh = colorThreshold.B + 30;
            using (Bitmap image = CaptureScreen(cropRect))
            {
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color color = image.GetPixel(x, y);
                        if (color.R > rLow && color.R < rHigh && color.G > gLow && color.G < gHigh && color.B > bLow && color.B < bHigh)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Dispose()
        {
            surface.ReleaseGraphics();
            surface.Dispose();
            device.Dispose();
        }
    }
}
