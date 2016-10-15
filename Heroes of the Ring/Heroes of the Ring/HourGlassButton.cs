using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class HourGlassButton
    {
        public Texture2D Sprite { get; set; }
        public Texture2D SpriteMouseOut { get; set; }
        public Texture2D SpriteMouseOver { get; set; }
        public Texture2D SpriteClicked { get; set; }
        public Vector2 Position = new Vector2(0, 0);
        public int SpriteWidth = 80;
        public int SpriteHeight = 80;

        public void LoadContent(ContentManager theContentManager, GraphicsDeviceManager graphics)
        {
            SpriteMouseOut = theContentManager.Load<Texture2D>("HourGlass");
            SpriteMouseOver = theContentManager.Load<Texture2D>("HourGlassMouseOver");
            SpriteClicked = theContentManager.Load<Texture2D>("HourGlassClicked");

            var topScreen = BattlefieldBackgroundSprite.BlockHeight * 12 + 20 +
                (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            Position = new Vector2(graphics.PreferredBackBufferWidth - SpriteWidth, topScreen + ((graphics.PreferredBackBufferHeight
                - topScreen) / 2) - SpriteHeight / 2);

            Sprite = SpriteMouseOut;
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(Sprite, Position, Color.White);
        }

        // Passage au prochain personnage
        public void NextCharacter(MoveTilesSprite moveTileSprite, FightTilesSprite fightTilesSprite, CrossedSwordsButton crossedSwordsButton,
            bool crossedSwordsButtonClicked)
        {
            crossedSwordsButton.ResetList();
            crossedSwordsButton.CharactersTargetable(false);
            if (Game1.Characters[Game1.Count].FacingRight)
            {
                Game1.Characters[Game1.Count].AnimationIdleRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationIdleRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationIdleRightSprite;
            }
            else
            {
                Game1.Characters[Game1.Count].AnimationIdleLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationIdleLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationIdleLeftSprite;
            }
            Game1.Count++;
            if (Game1.Count == Game1.Characters.Count)
            {
                Game1.Count = 0;
            }
            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].CharacterSelectedSprite(Game1.Characters,
                Game1.Count);
            Game1.CharacterHasMoved = false;
            Game1.CharacterHasStriked = false;
            if (crossedSwordsButtonClicked)
            {
                crossedSwordsButton.CharactersTargetable(true);
            }
            moveTileSprite.ResetMap();
            fightTilesSprite.ResetMap();
        }
    }
}
