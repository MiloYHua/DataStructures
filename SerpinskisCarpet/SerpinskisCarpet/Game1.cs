using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace SerpinskisCarpet
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D blankTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        List<Rectangle> allItems = new List<Rectangle>(100);

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = graphics.PreferredBackBufferHeight;
            graphics.ApplyChanges();
            allItems.Add((new Rectangle(new Point(GraphicsDevice.Viewport.Height / 3, GraphicsDevice.Viewport.Width / 3), new Point(GraphicsDevice.Viewport.Height / 3, GraphicsDevice.Viewport.Width / 3))));
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            blankTexture = new Texture2D(GraphicsDevice, 1, 1);
            blankTexture.SetData([Color.BlanchedAlmond]);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Chocolate);

            spriteBatch.Begin();



            Split(new ColoredRectangle(new Rectangle(new Point(GraphicsDevice.Viewport.Height / 3, GraphicsDevice.Viewport.Width / 3), new Point(GraphicsDevice.Viewport.Height / 3, GraphicsDevice.Viewport.Width / 3)), 0), Color.);

            for (int i = 0; i < allItems.Count; i++)
            {
                spriteBatch.Draw(blankTexture, allItems[i], Color.Black);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
        void Split(ColoredRectangle rectangle, int i)
        {
            if (i > 3) return;

            allItems.Add(rectangle);


            int x = rectangle.tangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;

            Rectangle top = new Rectangle(x + width / 3, rectangle.Top - 2 * height / 3, width / 3, height / 3);
            Rectangle topRight = new Rectangle(rectangle.Right + width / 3, rectangle.Top - 2 * height / 3, width / 3, height / 3);
            Rectangle right = new Rectangle(rectangle.Right + width / 3, y + height / 3, width / 3, height / 3);
            Rectangle bottomRight = new Rectangle(rectangle.Right + width / 3, rectangle.Bottom + height / 3, width / 3, height / 3);
            Rectangle bottom = new Rectangle(x + width / 3, rectangle.Bottom + height / 3, width / 3, height / 3);
            Rectangle bottomLeft = new Rectangle(x - 2 * width / 3, rectangle.Bottom + height / 3, width / 3, height / 3);
            Rectangle left = new Rectangle(rectangle.Left - 2 * width / 3, y + height / 3, width / 3, height / 3);
            Rectangle topLeft = new Rectangle(x - 2 * width / 3, y - 2 * height / 3, width / 3, height / 3);

            Split(top, i + 1);
            Split(topRight, i + 1);
            Split(right, i + 1);
            Split(bottomRight, i + 1);
            Split(bottom, i + 1);
            Split(bottomLeft, i + 1);
            Split(left, i + 1);
            Split(topLeft, i + 1);
        }
    }
}
