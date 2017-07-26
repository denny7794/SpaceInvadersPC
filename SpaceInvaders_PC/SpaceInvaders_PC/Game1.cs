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
        // Враги
        Texture2D txrEnemy;
        Rectangle rectEnemy = new Rectangle(0, 0, 50, 50);
        static int numberOfEnemies = 10;
        GameObj.Enemy[] enemies = new GameObj.Enemy[numberOfEnemies];
        // Каретка
        Texture2D txrKaretka;
        Rectangle rectKaretka = new Rectangle(0, 0, 100, 40);
        // Снаряд
        Texture2D txrBullet;
        Rectangle rectBullet = new Rectangle(0, 0, 10, 10);
        GameObj.Bullet bullet;
        // Признак того, что игра идет
        static public bool isGameRun;

        Microsoft.Xna.Framework.Audio.
        //Переменная для работы с аудиоустройством
        AudioEngine audioEngine;
        //Переменная для работы с Wave-банком
        WaveBank waveBank;
        //Переменная для работы с Sound-банком
        SoundBank soundBank;
        //Переменная для работы с фоновой музыкой игры
        Cue musicCue;


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

            isGameRun = true;

            //Загружаем аудиоресурсы для игры
            audioEngine = new AudioEngine("Content\\Audio\\SpaceInvaders.xgs");
            waveBank = new WaveBank(audioEngine, "Content\\Audio\\Sounds.xwb");
            soundBank = new SoundBank(audioEngine, "Content\\Audio\\SoundBank.xsb");
            //Присваиваем переменной ссылку на закладку с именем Music
            musicCue = soundBank.GetCue("1");
            //Включаем проигрывание фоновой музыки
            musicCue.Play();
            
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
            txrBullet = Content.Load<Texture2D>("bullet_prozr");
            //objEnemy = new spriteComp(this, ref txtEnemy, new Rectangle(0,0,50,50), new Vector2(100f, 150f));

            //Components.Add(objEnemy);


            //Вызываем процедуру расстановки объектов в игровом окне
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
            bullet = new GameObj.Bullet(this, ref txrBullet, new Vector2(this.Window.ClientBounds.Width / 2 - 2, this.Window.ClientBounds.Height  -rectKaretka.Height - rectBullet.Height / 2), rectBullet);
            Components.Add(bullet);
            Components.Add(new GameObj.Karetka(this, ref txrKaretka, new Vector2(this.Window.ClientBounds.Width/2-rectKaretka.Width/2, this.Window.ClientBounds.Height- rectKaretka.Height), rectKaretka, bullet));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            txrEnemy.Dispose();
            txrKaretka.Dispose();
            txrBullet.Dispose();
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


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //выведем фоновое изображение
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //Выведем игровые объекты
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
