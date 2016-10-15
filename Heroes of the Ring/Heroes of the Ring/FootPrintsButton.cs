using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class FootPrintsButton
    {
        public Texture2D Sprite { get; set; }
        public Texture2D SpriteMouseOut { get; set; }
        public Texture2D SpriteMouseOver { get; set; }
        public Texture2D SpriteClicked { get; set; }
        public Vector2 Position = new Vector2(0,0);
        public int SpriteWidth = 80;
        public int SpriteHeight = 80;

        public void LoadContent(ContentManager theContentManager, GraphicsDeviceManager graphics)
        {
            SpriteMouseOut = theContentManager.Load<Texture2D>("FootPrints");
            SpriteMouseOver = theContentManager.Load<Texture2D>("FootPrintsMouseOver");
            SpriteClicked = theContentManager.Load<Texture2D>("FootPrintsClicked");

            var topScreen = BattlefieldBackgroundSprite.BlockHeight * 12 + 20 + 
                (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            Position = new Vector2(SpriteWidth, topScreen + ((graphics.PreferredBackBufferHeight - topScreen) / 2) -
                SpriteHeight / 2);

            Sprite = SpriteMouseOut;
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(Sprite, Position, Color.White);
        }
    }
}