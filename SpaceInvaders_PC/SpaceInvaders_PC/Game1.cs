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

namespace SpaceInvaders_PC
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D txrEnemy;
        Texture2D txrKaretka;
        Rectangle rectEnemy = new Rectangle(0, 0, 50, 50);
        Rectangle rectKaretka = new Rectangle(0, 0, 100, 40);
        static int numberOfEnemies = 10;
        GameObj.Enemy[] enemies = new GameObj.Enemy[numberOfEnemies];


        //spriteComp objEnemy;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            //txtEnemy = Content.Load<Texture2D>("enemy_prozr");
            txrEnemy = Content.Load<Texture2D>("enemy_white");
            txrKaretka = Content.Load<Texture2D>("karetka_prozr");
            //objEnemy = new spriteComp(this, ref txtEnemy, new Rectangle(0,0,50,50), new Vector2(100f, 150f));

            //Components.Add(objEnemy);


            //�������� ��������� ����������� �������� � ������� ����
            AddSprites();
        }

        void AddSprites()
        {
            //Components.Add(new GameObj.Enemy(this, ref txrEnemy, new Vector2(0, 0), recEnemy));
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies[i] = new GameObj.Enemy(this, ref txrEnemy, new Vector2(100 + i*52, 50), rectEnemy);
                Components.Add(enemies[i]);

            }
            Components.Add(new GameObj.Karetka(this, ref txrKaretka, new Vector2(this.Window.ClientBounds.Width/2-rectKaretka.Width/2, this.Window.ClientBounds.Height- rectKaretka.Height), rectKaretka));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            txrEnemy.Dispose();
            spriteBatch.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //������� ������� �����������
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //������� ������� �������
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
