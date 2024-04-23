﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    class ShootEnemy : Entity
    {
        public ShootEnemy(Game game) : base(game)
        {
            Texture = game.Content.Load<Texture2D>("shoot");
        }

        public ShootEnemy(ShootEnemy se) : base(se) { }

        public override void Update(GameTime gameTime)
        {
            Position += new Vector2(0, 5);

            if (Position.Y < 0)
                Enabled = false;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }

    }
    
}  

