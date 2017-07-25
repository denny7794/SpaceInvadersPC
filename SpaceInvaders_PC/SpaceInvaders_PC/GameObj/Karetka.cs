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
    public class Karetka : gBaseClass
    {
        //Прямоугольник, представляющий игровое окно
        protected Rectangle scrBounds;
        //Скорость каретки
        protected Vector2 speed;
        // Переменная для снаряда
        Bullet bullet;
        // Переменная для хранения очков
        int scores;

        public Karetka(Game game, ref Texture2D _sprTexture,
             Vector2 _sprPosition, Rectangle _sprRectangle, Bullet _bullet)
             : base(game, ref _sprTexture, _sprPosition, _sprRectangle)
        {
            scrBounds = new Rectangle(0, 0,
              game.Window.ClientBounds.Width,
              game.Window.ClientBounds.Height);

            speed.X = 5;

            bullet = _bullet;

            scores = 0;
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
            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
            }
            if (bullet.sprPosition.Y + bullet.sprRectangle.Height < 0)
            {
                bullet.BeforeShot(this);
            }
        }

        void Move()
        {
            KeyboardState kbState = Keyboard.GetState();
            //MouseState msState = Mouse.GetState();
            if (kbState.IsKeyDown(Keys.Left))// || (msState.X < sprPosition.X + sprRectangle.Width/2))
            {
                sprPosition.X -= speed.X;
                if (!bullet.isShot) 
                    bullet.sprPosition.X -= speed.X;
            }
            if (kbState.IsKeyDown(Keys.Right))// || (msState.X > sprPosition.X + sprRectangle.Width/2))
            {
                sprPosition.X += speed.X;
                if (!bullet.isShot)
                    bullet.sprPosition.X += speed.X;
            }
            if (kbState.IsKeyDown(Keys.Space) && !bullet.isShot)
            {
                bullet.Shot(this);
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (Game1.isGameRun)
            {
                CheckBounds();
                if (bullet.isKillEnemy())
                {
                    scores += 50;
                    bullet.BeforeShot(this);
                    Game.Window.Title = "Вы набрали " + scores + " очков";
                }
                if (bullet.isAllEnemiesKilled())
                {
                    Game.Window.Title = "ВЫ ПОБЕДИЛИ!!!";
                }
                Move();
            }
            else
            {
                Game.Window.Title = "ВЫ ПРОИГРАЛИ...";
            }
            base.Update(gameTime);
        }
    }
}
