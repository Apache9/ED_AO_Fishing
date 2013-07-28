using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.Drawing;

namespace Fishing
{
    class Capture
    {
        private PresentParameters presentParams;

        public Capture()
        {
            presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.PresentFlag = PresentFlag.LockableBackBuffer;
            presentParams.BackBufferWidth = Screen.PrimaryScreen.Bounds.Width;
            presentParams.BackBufferHeight = Screen.PrimaryScreen.Bounds.Height;
            presentParams.MultiSample = MultiSampleType.None;
        }

        private Bitmap captureScreen()
        {
            using (Device device = new Device(0, DeviceType.Hardware, null, CreateFlags.SoftwareVertexProcessing, presentParams))
            {
                Surface surface = device.CreateOffscreenPlainSurface(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, Format.A8R8G8B8, Pool.SystemMemory);
                try
                {
                    device.GetFrontBufferData(0, surface);
                    GraphicsStream stream = Microsoft.DirectX.Direct3D.SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, surface);
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
                finally
                {
                    surface.ReleaseGraphics();
                    surface.Dispose();
                }
            }
        }

        public bool hasColorInRect(Color colorThreshold, Rectangle rect)
        {
            using (Bitmap image = captureScreen())
            {
                for (int x = 0; x < rect.Width; x++)
                {
                    for (int y = 0; y < rect.Height; y++)
                    {
                        Color color = image.GetPixel(rect.Left + x, rect.Top + y);
                        if (color.R > colorThreshold.R && color.G > colorThreshold.G && color.B > colorThreshold.B)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
