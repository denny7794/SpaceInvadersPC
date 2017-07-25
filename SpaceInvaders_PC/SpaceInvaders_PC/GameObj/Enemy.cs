using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SpaceInvaders_PC.GameObj
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Enemy : gBaseClass
    {
        //Прямоугольник, представляющий игровое окно
        Rectangle scrBounds;
        //Скорость врага
        Vector2 speed;

        public Enemy(Game game, ref Texture2D _sprTexture,
             Vector2 _sprPosition, Rectangle _sprRectangle)
             : base(game, ref _sprTexture, _sprPosition, _sprRectangle)
        {
            scrBounds = new Rectangle(0, 0,
              game.Window.ClientBounds.Width,
              game.Window.ClientBounds.Height);

            speed.X = (float)(random.NextDouble() * 5 - random.NextDouble() * 5);
            speed.Y = (float)random.NextDouble()/2;

            color = new Color(
                (byte)random.Next(0, 256),
                (byte)random.Next(0, 256),
                (byte)random.Next(0, 256),
                125
                );
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }


        /// <summary>
        /// Проверка на левую и правую границы экрана
        /// </summary>
        void CheckBounds()
        {
            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;
                speed.X *= -1;
            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
                speed.X *= -1;
            }
        }

        /// <summary>
        /// Проверка на достижение низа
        /// </summary>
        void CheckBottom()
        {
            if (sprPosition.Y + sprRectangle.Height > scrBounds.Height)
            {
                speed *= 0;
            }
        }

        void Move()
        {
            sprPosition += speed;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            CheckBottom();
            CheckBounds();
            Move();

            base.Update(gameTime);
        }
    }
}
