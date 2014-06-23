using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using SysDrawing = System.Drawing;
using SysImagingg = System.Drawing.Imaging;
using XNADrawing = Microsoft.Xna.Framework;


namespace GCXNA
{
    public class Renderer
    {
        private int[] buffer;
        private GraphicsDevice device;
        private RenderTarget2D renderTarget;

        public Renderer(int width, int height, IntPtr hwindow)
        {
            PresentationParameters pp = new PresentationParameters();
            pp.BackBufferWidth = width;
            pp.BackBufferHeight = height;
            pp.BackBufferFormat = SurfaceFormat.Color;
            pp.DepthStencilFormat = DepthFormat.Depth24;
            pp.IsFullScreen = false;
            pp.DeviceWindowHandle = hwindow;

            device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, pp);

            renderTarget = new RenderTarget2D(device,width, height, false,
                pp.BackBufferFormat, pp.DepthStencilFormat,
                pp.MultiSampleCount, pp.RenderTargetUsage);

            buffer = new int[width * height];
        }

        public void Render()
        {
            device.SetRenderTarget(renderTarget);
            device.Clear(XNADrawing.Color.Red);

            //Draw

            device.SetRenderTarget(null);
        }

        public Bitmap RenderResultBitmap
        {
            get
            {
                renderTarget.GetData(buffer);
                Bitmap bitmap = new Bitmap(300, 300, PixelFormat.Format32bppArgb);
                BitmapData bitmapdata = bitmap.LockBits(
                    new SysDrawing.Rectangle(0, 0, 300, 300),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);
                Marshal.Copy(buffer, 0, bitmapdata.Scan0, buffer.Length);
                bitmap.UnlockBits(bitmapdata);
                return bitmap;
            }
        }
    }
}
