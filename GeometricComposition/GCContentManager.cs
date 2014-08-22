using GeometricComposition.DisplayControl;
using GeometricComposition.XNALibrary;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GeometricComposition
{
    public class GCContentManager
    {
        public static string ContentDirectory { set; get; }

        public GraphicsDeviceService GraphicsDeviceService { set; get; }

        public ServiceContainer Services { private set; get; }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                if (GraphicsDeviceService != null)
                    return GraphicsDeviceService.GraphicsDevice;
                return null;
            }
        }

        private ContentManager contentManager = null;

        private GCModel defaultModel = null;
        public GCModel DefaultModel
        {
            private set { defaultModel = value; }
            get
            {
                if (defaultModel == null)
                    defaultModel = new GCModel(contentManager.Load<Model>("HexagonalPrism"));
                return defaultModel;
            }
        }
        private GCModel defaultPointModel = null;
        public GCModel DefaultPointModel
        {
            private set { defaultPointModel = value; }
            get
            {
                if (defaultPointModel == null)
                    defaultPointModel = new GCModel(contentManager.Load<Model>("Point"));
                return defaultPointModel;
            }
        }
        private SpriteFont defaultFont = null;
        public SpriteFont DefaultFont
        {
            private set { defaultFont = value; }
            get
            {
                if (defaultFont == null)
                    defaultFont = contentManager.Load<SpriteFont>("Font");
                return defaultFont;
            }
        }

        public GCContentManager(IntPtr window)
        {
            ContentDirectory = Path.Combine(Application.StartupPath, "PrecompiledContent/DefaultContent");
            GraphicsDeviceService = GraphicsDeviceService.AddRef(window, 1, 1);
            Services = new ServiceContainer();
            Services.AddService<IGraphicsDeviceService>(GraphicsDeviceService);
            contentManager = new ContentManager(Services, ContentDirectory);
        }

        ~GCContentManager()
        {
            contentManager.Unload();
            GraphicsDeviceService.Release(false);
        }

        public T LoadXNB<T>(string res)
        {
            return default(T);
        }

        public T LoadRaw<T>(string res)
        {
            return default(T);
        }
    }
}
