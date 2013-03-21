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


namespace Psychokinesis
{
    class vidar : entity
    {
        
        public Texture2D image;
        public List<vidar> vi;
        private int widthBlock;
        public List<int> top;
        public List<int> bottom;

        public void set(int startX, int startY)
        {
            //Top of head
            for (int i = 0; i < 15; i++)
            {
                widthBlock = 5;
                vi.Add(new vidar());
                vi[i].rectangle.X = startX + (widthBlock * i);
                vi[i].rectangle.Y = startY;
                vi[i].width = widthBlock;
                vi[i].height = widthBlock;

            }
        }

        public vidar get(vidar vi)
        {
            return vi;
        }



        public void draw(SpriteBatch sb)
        {
            sb.Draw(image, rectangle, Color.White);
        }
    }
}
