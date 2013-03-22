using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Psychokinesis
{
    public class person:entity
    {
        public Texture2D image;
        public string direction, skill, skillImageChange;
        public int HP;

        public void getHit(int hp, int dmg)
        {
            HP = hp - dmg;
        }

        public string setSkillImage(string skill)
        {
            if (skill == "mind")
            {
                skillImageChange = "mind";
            }

            else if (skill == "fire")
            {
                skillImageChange = "fireBox";
            }

            else if (skill == "ice")
            {
                skillImageChange = "ice";
            }

            else if (skill == "light")
            {
                skillImageChange = "light";
            }

            return skillImageChange;
        }

    }
}
