using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Psychokinesis
{
    class enemy : entity
    {

        public Texture2D image;
        public int HP;
        public string direction;

        public void update()
        {
            if (collision == false)
            {
                yVelocity = 3;
            }
            if (status == "fall")
            {
                yVelocity = 3;
            }

            rectangle.X += xVelocity;
            rectangle.Y += yVelocity;

            rectangle = new Rectangle(rectangle.X, rectangle.Y, width, height); 
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(image,rectangle,Color.White);
        }
       
    }
}
