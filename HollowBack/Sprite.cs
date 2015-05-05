using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HollowBack
{
    class Sprite
    {
        #region Fields

        private GraphicsDevice device;
        private Texture2D texture;
        private Vector2 size;
        private Vector2 position;
        private Vector2 velocity;
        private Point matrixPosition;
        private byte direction;
        private Boolean isActive;
        private Boolean isAlive;
        private SpriteEffects Effect;
        private float rotation;
        private Rectangle tangle;
        private Scene SceneA;
        private Vector2 origin;
        private float scale;
        #endregion

        #region Properties

        public GraphicsDevice Device
        {
            get { return device; }
            set { device = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            private set { texture = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            private set { size = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Point MatrixPosition
        {
            get { return matrixPosition; }
            set { matrixPosition = value; }
        }

        public byte Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Boolean IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Boolean IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public SpriteEffects Effects
        {
            get { return Effect; }
            set { Effect = value; }
        }

        public float angle
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public Rectangle Tangle
        {
            get { return tangle; }
            set { tangle = value; }
        }
        public Scene scene
        {
            get { return this.SceneA; }
            set { this.SceneA = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        #endregion

        public Sprite(ContentManager pContent, string pAssetName, Scene Cene)
        {
            scene = Cene;
            Effect = SpriteEffects.None;
            Texture = pContent.Load<Texture2D>(pAssetName);
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            MatrixPosition = Point.Zero;
            Direction = 0;
            angle = 0;
            Tangle = new Rectangle(1, 1, this.Texture.Width, this.Texture.Height);
            origin = Vector2.Zero;
            Scale = 1;
            this.scene = Cene;
        }

        public virtual void Update(GameTime pGameTime)
        {
        }

        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture,Position, Tangle, Color.White,
                angle,Origin,Scale,Effect, 1f); 
        }
    }
}
