using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Psychokinesis
{
    class skillIcon : entity
    {
        public Texture2D image;
        public string spell;
        public Boolean visible;

        public void setLocation(int charX, int charY)
        {
            rectangle.X = charX;
            rectangle.Y = charY - 160;
        }

        public void placeSkill(int midX, int midY, String side)
        {
            if (side == "top")
            {
                rectangle.Y = midY - 10 - height;
                rectangle.X = midX;
            }

            if (side == "bottom")
            {
                rectangle.Y = midY + 10 + height;
                rectangle.X = midX;
            }

            if (side == "right")
            {
                rectangle.Y = midY;
                rectangle.X = midX + width + 10;
            }

            if (side == "left")
            {
                rectangle.Y = midY;
                rectangle.X = midX - width - 10;
            }
        }

        public void setVisible(Boolean isVisible)
        {
            visible = isVisible;
        }

        public Boolean getVisible()
        {
            return visible;
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(image, rectangle, Color.White);
        }
    }
}
