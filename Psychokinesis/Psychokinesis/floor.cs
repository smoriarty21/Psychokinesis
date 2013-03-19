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
    class floor : entity
    {
        public Texture2D image;
        private int random, moveLen, oldY;

        //Creates Array of solid non-moving blocks
        public void createBlockArray(List<floor> blocks, int width, int y)
        {
            for (int i = 0; i < width; i++)
            {
                blocks.Add(new floor());
                blocks[i].rectangle.X = 1 + i;
                blocks[i].rectangle.Y = y;
            }
        }

        //Adds Points To Array On Every Update
        public void moveBlocks(List<floor> blocks, int width, int height)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                random = makeRandom(1, 10);

                if (random == 10 || random == 9)
                {
                    moveLen = 3;
                }
                else if (random >= 6 && random <= 8)
                {
                    moveLen = 1;
                }
                else if (random >= 1 && random <= 5)
                {
                    moveLen = 2;
                }

                blocks[i].rectangle.Y += moveLen;
            }
        }

        public void addBlocks(int x, int y)
        {
            
        }

        //Draw Blocks After Changes Are Made
        public void draw(SpriteBatch sb)
        {

        }
    }
}
