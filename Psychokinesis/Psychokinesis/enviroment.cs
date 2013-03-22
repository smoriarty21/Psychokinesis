using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Psychokinesis
{
    public class enviroment:entity
    {
        public Texture2D image;
        public int id;
        public int portalTime;

        //Update For Platforms to move with Background
        public void update(String direction, int bkgX, int bkgWidth, int screenWidth, int i)
        {
            if (direction == "right")
            {
                xVelocity = -4;
            }

            if (direction == "left")
            {
                xVelocity = 4;
            }

            if (bkgX >= 0 || bkgX + bkgWidth <= screenWidth + 5)
            {
                xVelocity = 0;
            }

            x += xVelocity;
            
            rectangle = new Rectangle(x + 35 * i, y, width, height);
        }

        public void spawnEnemy(person enemy)
        {
            enemy.visible = true;
            enemy.status = "fall";
            enemy.rectangle.X = rectangle.X + (width / 2);
            enemy.rectangle.Y = rectangle.Y + (height / 2);
        }

        //Draw Enviroment Sprite 
        public void draw(SpriteBatch sb)
        {
            sb.Draw(image, rectangle, Color.White);
        }
    }


}
