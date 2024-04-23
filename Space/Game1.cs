using Space;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Space
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        BackGround backGround;

        Ship ship;
        List<Enemy> listEnemys = new List<Enemy>();
        int lines = 3;
        int coluns = 13;
        int distanceX = 50;
        int distanceY = 55;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            backGround = new BackGround(this);

            ship = new Ship(this);
            ship.Position = new Vector2(350, 400);

            int posX = 0;
            int posY = distanceY;
            Random random = new Random();

            for(int l = 0; l <=  lines; l++) 
            {
                for (int c = 0; c <= coluns; c++)
                {
                    Enemy enemy = new Enemy(this);
                    posX += distanceX;
                    enemy.Position = new Vector2(posX, posY);
                    enemy.Time = random.Next(800, 15000);
                    listEnemys.Add(enemy);
                }

                posX = 0;
                posY += distanceY;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ship.Update(gameTime);

            for(int x = 0; x <= listEnemys.Count - 1; x++) 
            {
                listEnemys[x].Collide(ship.listShoot);

                if (listEnemys[x].Enabled == false)
                    listEnemys.RemoveAt(x);
                else
                {
                    listEnemys[x].Update(gameTime);
                    ship.Collide(listEnemys[x].listShoot);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            backGround.Draw(_spriteBatch);

            if(ship.Visible)
                ship.Draw(_spriteBatch,gameTime);   
            
            foreach(Enemy e in listEnemys)
            {
                e.Draw(_spriteBatch, gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
