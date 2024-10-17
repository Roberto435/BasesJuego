using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BasesJuego
{
    public class Game1 : Game
    {
        Texture2D menuTexture;
        Texture2D bolaTexture;
        Texture2D manzanaTexture;
        Vector2 bolaPosition;
        Vector2 menuPosition;
        private Random _random;
        Vector2 manzanaPosition;
        float bolaSpeed;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle _rectangulo1;
        private Rectangle _rectangulo2;
        private float _escalaTextura1;
        private long _puntuacion;
        public static bool menu = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _random = new Random();
            _escalaTextura1 = 1.0f;
            _puntuacion = 0;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            menuPosition = new Vector2(0, 0);
            bolaPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            bolaSpeed = 100f;
            manzanaPosition = new Vector2(_random.Next(_graphics.PreferredBackBufferWidth), _random.Next(_graphics.PreferredBackBufferHeight));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            menuTexture = Content.Load<Texture2D>("Menu");
            bolaTexture = Content.Load<Texture2D>("bola");
            manzanaTexture = Content.Load<Texture2D>("planeta1");

            //generar posicion aleatoria
            manzanaPosition = new Vector2(_random.Next(_graphics.PreferredBackBufferWidth), _random.Next( _graphics.PreferredBackBufferHeight ));
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (menu)
            {
                if (kstate.IsKeyDown(Keys.Space)) 
                {
                    menu = false;
                }
            }
            else 
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                _rectangulo1 = new Rectangle((int)bolaPosition.X, (int)bolaPosition.Y, (int)(bolaTexture.Width * _escalaTextura1), (int)(bolaTexture.Height * _escalaTextura1));
                _rectangulo2 = new Rectangle((int)manzanaPosition.X, (int)manzanaPosition.Y, manzanaTexture.Width, manzanaTexture.Height);
                if (_rectangulo1.Intersects(_rectangulo2))
                {
                    _escalaTextura1 += 0.1f;
                    // Genera una nueva posición aleatoria para la textura 1
                    manzanaPosition = new Vector2(
                        _random.Next(0, _graphics.PreferredBackBufferWidth - manzanaTexture.Width),
                        _random.Next(0, _graphics.PreferredBackBufferHeight - manzanaTexture.Height));
                    _puntuacion += 100;
                }
                // TODO: Add your update logic here
                //movimiento de la bola
                float updatedBolaSpeed = bolaSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


                if (kstate.IsKeyDown(Keys.Right))
                {
                    bolaPosition.X += updatedBolaSpeed;
                }

                if (bolaPosition.X > _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2)
                {
                    bolaPosition.X = _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2;
                }
                else if (bolaPosition.X < bolaTexture.Width / 2)
                {
                    bolaPosition.X = bolaTexture.Width / 2;
                }

                if (bolaPosition.Y > _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2)
                {
                    bolaPosition.Y = _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2;
                }
                else if (bolaPosition.Y < bolaTexture.Height / 2)
                {
                    bolaPosition.Y = bolaTexture.Height / 2;
                }

                if (kstate.IsKeyDown(Keys.Left))
                {
                    bolaPosition.X -= updatedBolaSpeed;
                }

                if (bolaPosition.X > _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2)
                {
                    bolaPosition.X = _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2;
                }
                else if (bolaPosition.X < bolaTexture.Width / 2)
                {
                    bolaPosition.X = bolaTexture.Width / 2;
                }

                if (bolaPosition.Y > _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2)
                {
                    bolaPosition.Y = _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2;
                }
                else if (bolaPosition.Y < bolaTexture.Height / 2)
                {
                    bolaPosition.Y = bolaTexture.Height / 2;
                }

                if (kstate.IsKeyDown(Keys.Up))
                {
                    bolaPosition.Y -= updatedBolaSpeed;
                }

                if (bolaPosition.X > _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2)
                {
                    bolaPosition.X = _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2;
                }
                else if (bolaPosition.X < bolaTexture.Width / 2)
                {
                    bolaPosition.X = bolaTexture.Width / 2;
                }

                if (bolaPosition.Y > _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2)
                {
                    bolaPosition.Y = _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2;
                }
                else if (bolaPosition.Y < bolaTexture.Height / 2)
                {
                    bolaPosition.Y = bolaTexture.Height / 2;
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    bolaPosition.Y += updatedBolaSpeed;
                }

                if (bolaPosition.X > _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2)
                {
                    bolaPosition.X = _graphics.PreferredBackBufferWidth - bolaTexture.Width / 2;
                }
                else if (bolaPosition.X < bolaTexture.Width / 2)
                {
                    bolaPosition.X = bolaTexture.Width / 2;
                }

                if (bolaPosition.Y > _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2)
                {
                    bolaPosition.Y = _graphics.PreferredBackBufferHeight - bolaTexture.Height / 2;
                }
                else if (bolaPosition.Y < bolaTexture.Height / 2)
                {
                    bolaPosition.Y = bolaTexture.Height / 2;
                }

                base.Update(gameTime);

            }
            
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (menu)
            {
                _spriteBatch.Draw(menuTexture, menuPosition, null, Color.White);
            }
            else 
            {
                _spriteBatch.Draw(bolaTexture, bolaPosition, null, Color.White, 0f, Vector2.Zero, _escalaTextura1, SpriteEffects.None, 0f);
                _spriteBatch.Draw(manzanaTexture, manzanaPosition, null, Color.White, 0f, new Vector2(manzanaTexture.Width / 2, manzanaTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
                var fuente = Content.Load<SpriteFont>("MiFuente");
                _spriteBatch.DrawString(fuente, $"Puntuacion: {_puntuacion}", new Vector2(10, 10), Color.White);

            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
