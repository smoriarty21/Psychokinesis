using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Psychokinesis
{
    public class entity
    {

        public int x, y, xVelocity, yVelocity, height, width;
        public string name;
        public Rectangle rectangle;
        public Boolean collision;
        public string status;
        public Boolean visible, hit, oldHit;

        public int throwNum = 0;

        public void Throw(string direction)
        {
           
            if (throwNum <= 20)
            {
                if (direction == "right")
                {
                    rectangle.X += 10;
                    rectangle.Y -= 7;
                    collision = false;
                    throwNum += 1;
                }

                if (direction == "left")
                {
                    rectangle.X -= 10;
                    rectangle.Y -= 7;
                    collision = false;
                    throwNum += 1;
                }
            }
            else
            {
                status = "fall";
                throwNum = 0;
            }

        }
 

        public void Collide(entity obj)
        {
            collision = false;
            hit = false;

            //Collision on top of obj
            if ((rectangle.Y + rectangle.Height) >= obj.rectangle.Y && (rectangle.Y + rectangle.Height) <= (obj.rectangle.Y + (obj.rectangle.Height/2)) && (rectangle.X + rectangle.Width) >= obj.rectangle.X && rectangle.X <= (obj.rectangle.X + obj.rectangle.Width))
            {
                collision = true;
                rectangle.Y = obj.rectangle.Y - rectangle.Height;
                if (name == "mainChar")
                    status = "run";

                if (name == "box" && obj.name == "enemy")
                {
                    obj.visible = false;  
                }
                if (name == "mainChar" && obj.name == "enemy")
                {
                    hit = true;
                }
                

            }

            //Collision on right of Obj
            if (rectangle.X <= obj.rectangle.X + obj.rectangle.Width && rectangle.X  >= obj.rectangle.X + obj.rectangle.Width - 3 && rectangle.Y < obj.rectangle.Y + obj.rectangle.Height && rectangle.Y + rectangle.Height > obj.rectangle.Y)
            {
                if (name == "mainChar" && obj.name == "box" && status != "jump" || name == "mainChar" && obj.name == "key" && status != "jump")
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        obj.rectangle.Y = rectangle.Y - obj.rectangle.Height;
                        obj.rectangle.X = rectangle.X + (rectangle.Width / 4);
                        obj.collision = true;
                        obj.status = "up";
                    }
                    else
                    {
                        obj.rectangle.X -= 3;
                    }
                }

                else if (name == "box" && obj.name == "enemy")
                {
                    obj.xVelocity = -3;
                }

                else if (name == "enemy" && obj.name == "platform")
                {
                    xVelocity = 3;
                }

                else if (name == "mainChar" && obj.name == "enemy")
                {
                    hit = true;
                    obj.xVelocity = -3;
                }

                else
                {
                    rectangle.X -= 25;
                    status = "fall";
                }
            }

            //Collision on left of obj
            if (rectangle.X + rectangle.Width >= obj.rectangle.X && rectangle.X + rectangle.Width <= obj.rectangle.X + 3 && rectangle.Y < obj.rectangle.Y + obj.rectangle.Height && rectangle.Y + rectangle.Height > obj.rectangle.Y)
            {
                if (name == "mainChar" && obj.name == "box" && status != "jump" || name == "mainChar" && obj.name == "key" && status != "jump")
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        obj.rectangle.Y = rectangle.Y - obj.rectangle.Height;
                        obj.rectangle.X = rectangle.X + (rectangle.Width / 4);
                        obj.collision = true;
                        obj.status = "up";
                    }
                    else
                    {
                        obj.rectangle.X += 3;
                    }
                }

                else if (name == "box" && obj.name == "enemy")
                {
                    obj.xVelocity = 3;
                }

                else if (name == "enemy" && obj.name == "platform")
                {
                    xVelocity = -3;
                }

                else if (name == "mainChar" && obj.name == "enemy")
                {
                    hit = true;
                    obj.xVelocity = 3;
                }
                else
                {
                    rectangle.X += 25;
                    status = "fall";
                }
            }

        }

    }

    
}
