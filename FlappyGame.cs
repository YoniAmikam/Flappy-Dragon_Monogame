using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyDragon
{

    public class FlappyGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screens.Screen currentScreen;


        public FlappyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Statics.CONTENT = Content;
            Statics.GRAPHICSDEVICE = GraphicsDevice;



            this.graphics.PreferredBackBufferHeight = Statics.GAME_HEIGHT;
            this.graphics.PreferredBackBufferWidth = Statics.GAME_WIDTH;
            this.Window.Title = Statics.GAME_TITLE;
            this.graphics.ApplyChanges();

            Managers.InputManager input = new Managers.InputManager();
        }

        protected override void Initialize()
        {


            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Statics.SPRITEBATCH = spriteBatch;
            Statics.PIXEL = Content.Load<Texture2D>("Textures/Pixel");
            currentScreen = new Screens.GameScreen();

            currentScreen.LoadContent();
        }


        protected override void Update(GameTime gameTime)
        {
            Statics.GAMETIME = gameTime;
            Statics.INPUT.Update();

            currentScreen.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentScreen.Draw();

            base.Draw(gameTime);
        }
    }
}
