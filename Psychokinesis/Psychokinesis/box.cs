using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Psychokinesis
{
    public class box:entity
    {
        public Texture2D image;

        public Boolean pointerOnBox(box obj)
        {
            if (rectangle.X > obj.rectangle.X && rectangle.X < obj.rectangle.X + obj.rectangle.Width && rectangle.Y > obj.rectangle.Y && rectangle.Y < obj.rectangle.Y + obj.rectangle.Height)
                return true;
            else
                return false;
        }
    } 
}
