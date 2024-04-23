using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    class BackGround
    {
        Texture2D texture;

        public BackGround(Game game) 
        {
            texture = game.Content.Load<Texture2D>("backGraound2");
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, Vector2.Zero,
                new Rectangle(80, 83, 450, 354), Color.White, 0, Vector2.Zero,
                2, SpriteEffects.None, 0);
        }

    }
}
