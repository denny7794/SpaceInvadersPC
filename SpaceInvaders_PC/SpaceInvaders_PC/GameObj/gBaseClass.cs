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
    public class gBaseClass : Microsoft.Xna.Framework.DrawableGameComponent
    {
        static public Random random = new Random();

        Texture2D sprTexture;
        public Vector2 sprPosition;
        public Rectangle sprRectangle;
        public Color color;

        public gBaseClass(Game game, ref Texture2D _sprTexture,
            Vector2 _sprPosition, Rectangle _sprRectangle)
            : base(game)
        {
            sprTexture = _sprTexture;
            //������ ����� ������������ ������� ������� �������� �������
            //� ���������� �� ������� ������
            // sprPosition = _sprPosition * 64;
            sprPosition = _sprPosition;
            sprRectangle = _sprRectangle;

            color = new Color(255, 255, 255, 125);
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

        //������� ������������ ��� ���������������
        //��� ���������, ������������ �� ��� ������ � ��������
        //������ gBaseClass � ���������� True ���� ������������ ����
        protected bool IsCollideWithObject(gBaseClass spr)
        {
            return (this.sprPosition.X + this.sprRectangle.Width > spr.sprPosition.X &&
                        this.sprPosition.X < spr.sprPosition.X + spr.sprRectangle.Width &&
                        this.sprPosition.Y + this.sprRectangle.Height > spr.sprPosition.Y &&
                        this.sprPosition.Y < spr.sprPosition.Y + spr.sprRectangle.Height);


        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            //sprBatch.Draw(sprTexture, sprPosition, Color.White);
            sprBatch.Draw(sprTexture, sprPosition, color);
            base.Draw(gameTime);
        }
    }
}
