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
    public class Bullet : gBaseClass
    {
        //Прямоугольник, представляющий игровое окно
        protected Rectangle scrBounds;
        //Скорость снаряда
        protected Vector2 speed;

        public bool isShot;

        public Bullet(Game game, ref Texture2D _sprTexture,
             Vector2 _sprPosition, Rectangle _sprRectangle)
             : base(game, ref _sprTexture, _sprPosition, _sprRectangle)
        {
             scrBounds = new Rectangle(0, 0,
              game.Window.ClientBounds.Width,
              game.Window.ClientBounds.Height);

            speed.X = 5;
            speed.Y = 0;

            isShot = false;
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

        void CheckBounds()
        {
            if (sprPosition.X < scrBounds.Left + 50 )
            {
                sprPosition.X = scrBounds.Left + 50;
            }
            if (sprPosition.X > scrBounds.Width - 50)
            {
                sprPosition.X = scrBounds.Width - 50;
            }
            //if (sprPosition.Y + sprRectangle.Height < 0)
            //{
            //    isShot = false;
            //    sprPosition.Y = scrBounds.Height - sprRectangle.Height;
            //    speed.Y = 0;
            //}
        }

        public void BeforeShot(Karetka karetka)
        {
            isShot = false;
            sprPosition.X = karetka.sprPosition.X + karetka.sprRectangle.Width / 2 - 2;
            sprPosition.Y = scrBounds.Height - karetka.sprRectangle.Height - sprRectangle.Height/2;
            speed.Y = 0;
        }

        void Move()
        {
            //KeyboardState kbState = Keyboard.GetState();
            //if (kbState.IsKeyDown(Keys.Left))
            //    sprPosition.X -= speed.X;
            //if (kbState.IsKeyDown(Keys.Right))
            //    sprPosition.X += speed.X;
            //if (kbState.IsKeyDown(Keys.Space) && !isShot)
            //{
            //    Shot();
            //}
            //sprPosition += speed;
            sprPosition.Y += speed.Y;
        }

        public void Shot(Karetka karetka)
        {
            isShot = true;
            sprPosition.X = karetka.sprPosition.X+karetka.sprRectangle.Width/2 - 2;
            //sprPosition.Y = karetka.sprPosition.Y + sprRectangle.Height / 2 - 4;
            sprPosition.Y = scrBounds.Height - karetka.sprRectangle.Height - sprRectangle.Height / 2;
            speed.X = 0;
            speed.Y = -5;
        }

        public bool isKillEnemy()
        {
            gBaseClass FindObj = null;
            foreach (gBaseClass spr in Game.Components)
            {
                if (spr.GetType() == (typeof(Enemy)))
                {
                    if(IsCollideWithObject(spr) && isShot)
                    {
                        //Если условие выполняется - сохраним ссылку на объект врага
                        FindObj = spr;
                    }
                }
            }
            //Если был удачный прыжок на врага
            //добавим игроку очков и уничтожим объект класса Enemy
            if (FindObj != null)
            {
                FindObj.Dispose();
                return true;
            }
            return false;
        }

        public bool isAllEnemiesKilled()
        {
            foreach (gBaseClass spr in Game.Components)
            {
                if (spr.GetType() == (typeof(Enemy)))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            CheckBounds();
            Move(); 

            base.Update(gameTime);
        }
    }
}
