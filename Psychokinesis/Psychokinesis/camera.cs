using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Psychokinesis
{
    class camera
    {
        public Matrix transform;
        Vector2 center;
        Viewport view;

        public camera(Viewport newView)
        {
            view = newView;
        }

        public void update(GameTime gametime, person mainChar)
        {
            
        }
    }
}
