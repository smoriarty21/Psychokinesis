using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Psychokinesis
{
    class background:entity
    {

        public Texture2D image;

        public void update(String direction)
        {
            if (direction == "right")
            {
                xVelocity = -4;
            }

            if (direction == "left")
            {
                xVelocity = 4;
            }

            if (x + xVelocity + width <= 900 || x + xVelocity > 0)
            {
                xVelocity = 0;
            }

            x += xVelocity;

            rectangle = new Rectangle(x, y, width, height);
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(image, rectangle, Color.White);
        }

    }
}
