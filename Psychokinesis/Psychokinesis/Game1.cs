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
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Mouse Status
        MouseState currentMouse;
        MouseState previousMouse;

        //Keyboard State
        KeyboardState currentKeyboard;
        KeyboardState previousKeyboard;

        //Game World
        background background = new background();

        person mainChar = new person();
        person enemy = new person();
        enviroment floor = new enviroment();
        box box = new box();
        box pointer = new box();
        ui hpBar = new ui();
        ui inventory = new ui();
        ui potion = new ui();
        ui spell = new ui();
        ui spellMenu = new ui();
        enviroment door = new enviroment();
        enviroment key = new enviroment();

        person spider = new person();
  
        //Portal
        enviroment portal = new enviroment();

        //Spell Menu
        skillIcon middleSpellMenu = new skillIcon();
        skillIcon topSpellMenu = new skillIcon();
        skillIcon leftSpellMenu = new skillIcon();
        skillIcon rightSpellMenu = new skillIcon();
        skillIcon bottomSpellMenu = new skillIcon();

        //Lists For Enviroment
        List<enviroment> plat = new List<enviroment>();
        List<enviroment> floorBox = new List<enviroment>();

        //Font
        SpriteFont basicFont;

        //Lightning
        skills lightning = new skills();

        //Variables for jump
        int jumpHeight = 0;

        //Variable for Throw
        int throwNum = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 900;
        }

   
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Mouse and Keyboard State
            currentKeyboard = Keyboard.GetState();
            previousMouse = currentMouse;

            currentMouse = Mouse.GetState();
            previousMouse = currentMouse;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Font
            basicFont = Content.Load<SpriteFont>("basicFont");

            //Main Char
            mainChar.image = Content.Load<Texture2D>("right");
            mainChar.height = 40;
            mainChar.width = 40;
            mainChar.name = "mainChar";
            mainChar.status = "fall";
            mainChar.rectangle = new Rectangle(0, 400, mainChar.width, mainChar.height);
            mainChar.HP = 100;
            mainChar.skill = "lightning";

            //TEST Spider From Portal
            spider.height = 50;
            spider.width = 50;
            spider.rectangle = new Rectangle(0, 0, spider.width, spider.height);
            spider.visible = false;
            spider.image = Content.Load<Texture2D>("blockspider");

            //Skills
            lightning.visible = false;
            lightning.image = Content.Load<Texture2D>("lbolt");
            lightning.height = 100;
            lightning.width = 15;

            //HP && XP Bars
            hpBar.image = Content.Load<Texture2D>("bars");
            hpBar.height = 15;
            hpBar.width = 150;
            hpBar.rectangle = new Rectangle(10, 10, hpBar.width, hpBar.height);

            //Spell Image Bar
            spell.image = Content.Load<Texture2D>(mainChar.setSkillImage("light"));
            spell.height = 50;
            spell.width = 50;
            spell.rectangle = new Rectangle(hpBar.rectangle.X, (hpBar.rectangle.Y + hpBar.height + 5), spell.width, spell.height);

            //Spell Menu
            /*spellMenu.image = Content.Load<Texture2D>("spellmenu");
            spellMenu.height = 200;
            spellMenu.width = 200;
            spellMenu.rectangle = new Rectangle(500, 200, spellMenu.width, spellMenu.height);
            spellMenu.visible = false;*/

            //New Spell Menu
            bottomSpellMenu.image = Content.Load<Texture2D>("mind");
            bottomSpellMenu.width = 50;
            bottomSpellMenu.height = 50;
            bottomSpellMenu.rectangle.X = mainChar.rectangle.X;
            bottomSpellMenu.rectangle.Y = mainChar.rectangle.Y - bottomSpellMenu.height - 10;
            bottomSpellMenu.rectangle = new Rectangle(bottomSpellMenu.rectangle.X, bottomSpellMenu.rectangle.Y, bottomSpellMenu.width, bottomSpellMenu.height);
            bottomSpellMenu.visible = false;
            bottomSpellMenu.spell = "mind";

            middleSpellMenu.image = Content.Load<Texture2D>("50pxBlackBox");
            middleSpellMenu.width = 50;
            middleSpellMenu.height = 50;
            middleSpellMenu.rectangle.X = bottomSpellMenu.rectangle.X;
            middleSpellMenu.rectangle.Y = bottomSpellMenu.rectangle.Y - 10 - middleSpellMenu.height;
            middleSpellMenu.rectangle = new Rectangle(middleSpellMenu.rectangle.X, middleSpellMenu.rectangle.Y, middleSpellMenu.width, middleSpellMenu.height);
            middleSpellMenu.visible = false;

            topSpellMenu.image = Content.Load<Texture2D>("fireBox");
            topSpellMenu.height = 50;
            topSpellMenu.width = 50;
            topSpellMenu.rectangle.X = bottomSpellMenu.rectangle.X;
            topSpellMenu.rectangle.Y = middleSpellMenu.rectangle.Y - 10 - topSpellMenu.height;
            topSpellMenu.rectangle = new Rectangle(topSpellMenu.rectangle.X, topSpellMenu.rectangle.Y, topSpellMenu.width, topSpellMenu.height);
            topSpellMenu.visible = false;
            topSpellMenu.spell = "fire";

            leftSpellMenu.image = Content.Load<Texture2D>("ice");
            leftSpellMenu.height = 50;
            leftSpellMenu.width = 50;
            leftSpellMenu.rectangle.X = middleSpellMenu.rectangle.X - 10 - leftSpellMenu.width;
            leftSpellMenu.rectangle.Y = middleSpellMenu.rectangle.Y;
            leftSpellMenu.rectangle = new Rectangle(leftSpellMenu.rectangle.X, leftSpellMenu.rectangle.Y, leftSpellMenu.width, leftSpellMenu.height);
            leftSpellMenu.visible = false;
            leftSpellMenu.spell = "ice";

            rightSpellMenu.image = Content.Load<Texture2D>("light");
            rightSpellMenu.height = 50;
            rightSpellMenu.width = 50;
            rightSpellMenu.rectangle.X = middleSpellMenu.rectangle.X + 10;
            rightSpellMenu.rectangle.Y = middleSpellMenu.rectangle.Y;
            rightSpellMenu.rectangle = new Rectangle(topSpellMenu.rectangle.X, topSpellMenu.rectangle.Y, topSpellMenu.width, topSpellMenu.height);
            rightSpellMenu.visible = false;
            rightSpellMenu.spell = "lightning";

            //Portal
            portal.image = Content.Load<Texture2D>("portal");
            portal.rectangle.X = 700;
            portal.rectangle.Y = 170;
            portal.width = 75;
            portal.height = 150;
            portal.rectangle = new Rectangle(portal.rectangle.X, portal.rectangle.Y, portal.width, portal.height);
            portal.portalTime = 0;


            //Mouse Pointer
            pointer.image = Content.Load<Texture2D>("pointer");
            pointer.height = 5;
            pointer.width = 5;
            pointer.name = "pointer";
            pointer.rectangle = new Rectangle(640, 300, pointer.width, pointer.height);

            //Box
            box.image = Content.Load<Texture2D>("box");
            box.height = 20;
            box.width = 20;
            box.status = "stopped";
            box.rectangle = new Rectangle(450, 0, box.width, box.height);
            box.collision = false;
            box.name = "box";

            //Background Image
            background.image = Content.Load<Texture2D>("bkg");
            background.x = 0;
            background.y = 0;
            background.xVelocity = 0;

            //Enemy
            enemy.image = Content.Load<Texture2D>("enemy");
            enemy.height = 75;
            enemy.width = 60;
            enemy.collision = false;
            enemy.name = "enemy";
            enemy.rectangle = new Rectangle(800, 400, enemy.width, enemy.height);
            enemy.visible = true;
            enemy.xVelocity = -3;

            //Inventory
            inventory.image = Content.Load<Texture2D>("inventory");
            inventory.height = 500;
            inventory.width = 500;
            inventory.visible = false;
            inventory.rectangle = new Rectangle(300, 40, inventory.width, inventory.height);

            //Potion
            potion.image = Content.Load<Texture2D>("potion");
            potion.rectangle = new Rectangle(inventory.rectangle.X + 70, inventory.rectangle.Y + 70, 60, 60);
            potion.amount = 1;
            potion.amountLocation = new Vector2(inventory.rectangle.X + 130, inventory.rectangle.Y + 130);

            //Initialize platform List
            for (int i = 0; i <=3; i++)
            {
                plat.Add(new enviroment());
                plat[i].image = Content.Load<Texture2D>("grassBlock");
                plat[i].x = 200;
                plat[i].y = 375;
                plat[i].width = 35;
                plat[i].height = 35;
                plat[i].rectangle =new Rectangle((plat[i].x + (plat[i].width * i)), plat[i].y, plat[i].width, plat[i].height);
                plat[i].name = "platform";
            }

            //Initialize Floor List
            double floorSz = (graphics.GraphicsDevice.Viewport.Width / 35);
            int floorSize = (int)floorSz + 1;

            for (int i = 0; i < floorSize; i++)
            {
                floorBox.Add(new enviroment());
                floorBox[i].image = Content.Load<Texture2D>("grassBlock");
                floorBox[i].x = 0;
                floorBox[i].width = 35;
                floorBox[i].height = 35;
                floorBox[i].y = graphics.GraphicsDevice.Viewport.Height - floorBox[i].height;
                floorBox[i].rectangle = new Rectangle((floorBox[i].x + (floorBox[i].width * i)), floorBox[i].y, floorBox[i].width, floorBox[i].height);
                floorBox[i].name = "platform";
            }

            //Door
            door.height = 150;
            door.width = 100;
            door.rectangle.Y = floorBox[0].rectangle.Y - door.height;
            door.rectangle.X = 1160;
            door.rectangle = new Rectangle(door.rectangle.X, door.rectangle.Y, door.width, door.height);
            door.image = Content.Load<Texture2D>("door");

            //Key
            key.image = Content.Load<Texture2D>("key");
            key.width = 20;
            key.height = 40;
            key.rectangle.Y = plat[0].rectangle.Y - key.height;
            key.rectangle.X = plat[0].rectangle.X + 25;
            key.rectangle = new Rectangle(key.rectangle.X, key.rectangle.Y, key.width, key.height);
            key.name = "key";

        }
       
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            //Mouse and Keyboard Input 
            MouseState mState = Mouse.GetState();
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            previousKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();

            pointer.rectangle.X = mState.X;
            pointer.rectangle.Y = mState.Y;

            //Screen Parameters
            int screenWidth = graphics.GraphicsDevice.Viewport.Width;
            int screenHeight = graphics.GraphicsDevice.Viewport.Height;

            //Background Image Parameters
            background.height = screenHeight - floor.height;
            background.width = 1300;
            background.rectangle = new Rectangle(background.x, 0, background.width, background.height);

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            //Keys For Movement
            if (Keyboard.GetState().IsKeyDown(Keys.D) && mainChar.status != "jump" && mainChar.status != "fall")
            {
                if ((mainChar.rectangle.X + mainChar.width) >= screenWidth)
                {
                    background.update("right");
                    mainChar.rectangle.X -= 3;

                    for (int i = 0; i < plat.Count; i++)
                    {
                        plat[i].update("right", background.rectangle.X, background.width, screenWidth, i);
                    }
                }

                mainChar.rectangle.X += 3;
                mainChar.image = Content.Load<Texture2D>("right");
                mainChar.status = "run";
                mainChar.direction = "right";
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && mainChar.status != "jump" && mainChar.status != "fall")
            {
                if (mainChar.rectangle.X <= 1)
                {
                    background.update("left");
                    mainChar.rectangle.X += 3;

                    for (int i = 0; i < plat.Count; i++)
                    {
                        plat[i].update("left", background.rectangle.X, background.width, screenWidth, i);
                    }
                }

                mainChar.rectangle.X -= 3;
                mainChar.image = Content.Load<Texture2D>("left");
                mainChar.status = "run";
                mainChar.direction = "left";

            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && mainChar.status != "jump" && mainChar.status != "fall")
            {
                mainChar.status = "jump";
            }

            //Inventory Key 
            if (Keyboard.GetState().IsKeyDown(Keys.I) && previousKeyboard.IsKeyDown(Keys.I) == false) 
            {
                if(inventory.visible == false)
                    inventory.visible = true;
                else if(inventory.visible == true)
                    inventory.visible = false;
            }

            //Spells menu
            if (Keyboard.GetState().IsKeyDown(Keys.Tab) && previousKeyboard.IsKeyDown(Keys.Tab) == false)
            {
                /*if (spellMenu.visible == false)
                    spellMenu.visible = true;
                else if (spellMenu.visible == true)
                    spellMenu.visible = false;*/
                if (middleSpellMenu.visible == false)
                {
                    //middleSpellMenu.setLocation(mainChar.rectangle.X, mainChar.rectangle.Y);
                    middleSpellMenu.setVisible(true);
                    topSpellMenu.setVisible(true);
                    bottomSpellMenu.setVisible(true);
                    leftSpellMenu.setVisible(true);
                    rightSpellMenu.setVisible(true);
                }

                else if (middleSpellMenu.visible == true)
                {
                    middleSpellMenu.setVisible(false);
                    topSpellMenu.setVisible(false);
                    bottomSpellMenu.setVisible(false);
                    leftSpellMenu.setVisible(false);
                    rightSpellMenu.setVisible(false);
                }
            }

            //Change spells: TO DO switch to ricks mouse idea
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && middleSpellMenu.visible == true)
            {
                mainChar.skill = rightSpellMenu.spell;
                spell.image = Content.Load<Texture2D>(mainChar.setSkillImage("light"));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && middleSpellMenu.visible == true)
            {
                mainChar.skill = leftSpellMenu.spell;
                spell.image = Content.Load<Texture2D>(mainChar.setSkillImage("ice"));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && middleSpellMenu.visible == true)
            {
                mainChar.skill = topSpellMenu.spell;
                spell.image = Content.Load<Texture2D>(mainChar.setSkillImage("fire"));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && middleSpellMenu.visible == true)
            {
                mainChar.skill = bottomSpellMenu.spell;
                spell.image = Content.Load<Texture2D>(mainChar.setSkillImage("mind"));
            }


            if (box.status == "up" && !Keyboard.GetState().IsKeyDown(Keys.Space))
                box.status = "throw";

            if (key.status == "up" && !Keyboard.GetState().IsKeyDown(Keys.Space))
                key.status = "throw";

            //Portal Timing
            if (portal.visible == true)
            {
                portal.portalTime += 1;

                if (portal.portalTime > 100)
                {
                    portal.spawnEnemy(spider);
                }

            }
            
            //Spider Fall
            if (spider.status == "fall")
            {
                spider.rectangle.Y += 3;
                spider.rectangle = new Rectangle(spider.rectangle.X, spider.rectangle.Y, spider.width, spider.height);
            }

            //Stop From going out of screen bounds

            //Gravity
            if (mainChar.collision == false && mainChar.status != "jump")
                mainChar.status = "fall";

            //Jumping
            if (mainChar.status == "jump")
            {
                if (jumpHeight <= 30)
                {
                    if (mainChar.direction == "right")
                    {
                        mainChar.rectangle.Y -= 6;
                        mainChar.rectangle.X += 2;
                        jumpHeight += 1;
                    }
                    if (mainChar.direction == "left")
                    {
                        mainChar.rectangle.Y -= 6;
                        mainChar.rectangle.X -= 2;
                        jumpHeight += 1;
                    }
                }
                else
                {
                    mainChar.status = "fall";
                    jumpHeight = 0;
                }
            }

            //Fall Status
            if (mainChar.status == "fall")
            {
                mainChar.rectangle.Y += 7;
            }

            //Key Physics
            if (key.collision == false)
                key.rectangle.Y += 5;

            if (key.status == "throw")
            {
                if (mainChar.direction == "right")
                {
                    key.Throw("right");
                }
            }

            //Box Physics
            if (box.collision == false)
                box.rectangle.Y += 5;

            if (box.status == "throw")
            {
                if (throwNum <= 20)
                {
                    if (mainChar.direction == "right")
                    {
                        box.rectangle.X += 10;
                        box.rectangle.Y -= 7;
                        box.collision = false;
                        throwNum += 1;
                    }

                    if (mainChar.direction == "left")
                    {
                        box.rectangle.X -= 10;
                        box.rectangle.Y -= 7;
                        box.collision = false;
                        throwNum += 1;
                    }
                }
                else
                {
                    box.status = "fall";
                    throwNum = 0;
                }
            }

            //Enemy Physics
            if (enemy.collision == false)
                enemy.rectangle.Y += 4;

            //Enemy Hits edge of screen(fix later)
            if (enemy.rectangle.X + enemy.rectangle.Width > screenWidth)
                enemy.xVelocity = -3;

            enemy.rectangle.X += enemy.xVelocity;


            //Collision Checks 
            mainChar.Collide(box);
            mainChar.Collide(key);
            key.Collide(box);

            //Collide With Platforms From List
            for (int i = 0; i < plat.Count; i++)
            {
                mainChar.Collide(plat[i]);
                box.Collide(plat[i]);
                key.Collide(plat[i]);

                if (enemy.visible == true)
                {
                    enemy.Collide(plat[i]);
                }
            }

            //Collide With Floor List
            for (int i = 0; i < floorBox.Count; i++)
            {
                mainChar.Collide(floorBox[i]);
                box.Collide(floorBox[i]);
                key.Collide(floorBox[i]);
             
                if (enemy.visible == true)
                {
                    enemy.Collide(floorBox[i]);
                }
            }

            if (enemy.visible == true)
            {
                box.Collide(enemy);
                mainChar.Collide(enemy);
            }

            //Cursor Is Over box
            if (pointer.pointerOnBox(box) == true && currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released && mainChar.skill == "mind")
            {
                box.status = "mindUp";
            }

            //Lightning
            if (mainChar.skill == "lightning" && currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
            {
                System.Console.WriteLine("BAM!");
                lightning.visible = true;
                lightning.rectangle.X = mState.X;
                lightning.rectangle.Y = 0;
                lightning.rectangle = new Rectangle(lightning.rectangle.X, lightning.rectangle.Y, lightning.width, lightning.height); 
            }
          
              
            //Set Box to be picked up if collides while holding space bar
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                box.Collide(mainChar);
            }

            //Box Picked Up Action
            if(box.status == "up")
            {
                box.rectangle.X = mainChar.rectangle.X;
            }

            if (box.status == "mindUp")
            {
                box.rectangle.Y = mState.Y;
                box.rectangle.X = mState.X;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Released)
                {
                    box.collision = false;
                    box.status = null;
                }
            }

            //Key Picked Up
            if (key.status == "up")
            {
                key.rectangle.X = mainChar.rectangle.X;
                key.rectangle.Y = mainChar.rectangle.Y - key.height;
            }

            //Fix HP Bar According To Hit
            if (mainChar.hit == true)
            {
                mainChar.getHit(mainChar.HP, 10);
            }

            //Inventory Opened
            if (inventory.visible == true)
           { 
                if (Keyboard.GetState().IsKeyDown(Keys.D1) && previousKeyboard.IsKeyDown(Keys.D1) == false)
                {
                    if (potion.amount > 0)
                    {
                        mainChar.HP += 25;
                        potion.amount -= 1;
                    }

                    if (mainChar.HP > 100)
                        mainChar.HP = 100;
                }
            }

            base.Update(gameTime);
        }

        private void drawHp(Rectangle cords, Color color)
        {
            var rect = new Texture2D(GraphicsDevice, 1, 1);
            rect.SetData(new[] { color });
            spriteBatch.Draw(rect, cords, color);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Draw Backgrounds
            //spriteBatch.Draw(background.image, background.rectangle, Color.White);
            background.draw(spriteBatch);

            //Draw Door
            spriteBatch.Draw(door.image, door.rectangle, Color.White);

            //Draw Key
            spriteBatch.Draw(key.image, key.rectangle, Color.White);

            //Draw UI Bars
            spriteBatch.Draw(hpBar.image, hpBar.rectangle, Color.White);
            float len = mainChar.HP / 100f;
            float hpBarLength = ((hpBar.width * len) - 2);
            drawHp(new Rectangle(hpBar.rectangle.X + 1, hpBar.rectangle.Y + 1, (int)hpBarLength, hpBar.height - 2), Color.Red);

            //Draw Spell UI Image
            spriteBatch.Draw(spell.image, spell.rectangle, Color.White);

            //Draw Main Char
            spriteBatch.Draw(mainChar.image, mainChar.rectangle, Color.White);

            //Draw Portal
            if (background.rectangle.X + background.width < 1000)
            {
                portal.draw(spriteBatch);
                portal.visible = true;
            }
           
            //Draw Enemy
            if(enemy.visible == true)
                spriteBatch.Draw(enemy.image, enemy.rectangle, Color.White);

            //Draw Box
            spriteBatch.Draw(box.image, box.rectangle, Color.White);

            //Draw All Platforms From List
            for (int i = 0; i < plat.Count; i++)
            {
                plat[i].draw(spriteBatch);
            }

            //Draw Floor
            for (int i = 0; i < floorBox.Count; i++)
            {
                spriteBatch.Draw(floorBox[i].image, floorBox[i].rectangle, Color.White);
            }

            //Draw Mouse Pointer
            spriteBatch.Draw(pointer.image, pointer.rectangle, Color.White);

            //If Inventory Is Called Draw It
            if (inventory.visible == true)
            {
                spriteBatch.Draw(inventory.image, inventory.rectangle, Color.White);
                spriteBatch.Draw(potion.image, potion.rectangle, Color.White);
                spriteBatch.DrawString(basicFont,"" + potion.amount, potion.amountLocation,Color.White);
            }

            //Open Spell Menu
            /*if (spellMenu.visible == true)
            {
                spriteBatch.Draw(spellMenu.image, spellMenu.rectangle, Color.White);
            }*/
            if (middleSpellMenu.visible == true)
            {
                middleSpellMenu.setLocation(mainChar.rectangle.X, mainChar.rectangle.Y);
                topSpellMenu.placeSkill(middleSpellMenu.rectangle.X, middleSpellMenu.rectangle.Y, "top");
                bottomSpellMenu.placeSkill(middleSpellMenu.rectangle.X, middleSpellMenu.rectangle.Y, "bottom");
                rightSpellMenu.placeSkill(middleSpellMenu.rectangle.X, middleSpellMenu.rectangle.Y, "right");
                leftSpellMenu.placeSkill(middleSpellMenu.rectangle.X, middleSpellMenu.rectangle.Y, "left");

                middleSpellMenu.draw(spriteBatch);
                topSpellMenu.draw(spriteBatch);
                leftSpellMenu.draw(spriteBatch);
                rightSpellMenu.draw(spriteBatch);
                bottomSpellMenu.draw(spriteBatch);
            }

            //Portal Enemy
            if (spider.visible == true)
            {
                spriteBatch.Draw(spider.image, spider.rectangle, Color.White);
            }

            //Draw Lightning
            if (lightning.visible == true && (lightning.rectangle.Y + lightning.height) <= floorBox[0].rectangle.Y)
            {
                spriteBatch.Draw(lightning.image, lightning.rectangle, Color.White);
                lightning.rectangle.Y += lightning.height / 2;
            }
            else
                lightning.visible = false;
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
