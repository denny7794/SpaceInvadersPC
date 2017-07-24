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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class spriteClass { 
       public Texture2D spTexture;
        public Vector2 spPosition;

        public spriteClass(Texture2D newSpTexture, Vector2 newSpPosition)
        {
            spTexture = newSpTexture;
            spPosition = newSpPosition;
        }
    }
}
