using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class Elf : Character
    {
        public override void Initialize(Game game, GraphicsDeviceManager graphics)
        {
            CharacterSpeed = 5;
            CharacterFaction = "Evil";
            FacingRight = true;
            CharacterWeapon.Range = 6;
            CharacterWeapon.WeaponName = "Bow";

            AnimationIdleRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleRightSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 70
            }, 2);
            AnimationIdleRightSprite.Initialize(graphics);

            AnimationIdleLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleLeftSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 70
            }, 2);
            AnimationIdleLeftSprite.Initialize(graphics);

            AnimationIdleSelectedRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleSelectedRightSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 72
            }, 2);
            AnimationIdleSelectedRightSprite.Initialize(graphics);

            AnimationIdleSelectedLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleSelectedLeftSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 72
            }, 2);
            AnimationIdleSelectedLeftSprite.Initialize(graphics);

            AnimationIdleTargetableRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleTargetableRightSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 72
            }, 2);
            AnimationIdleTargetableRightSprite.Initialize(graphics);

            AnimationIdleTargetableLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleTargetableLeftSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 72
            }, 2);
            AnimationIdleTargetableLeftSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleTargetableMouseOverRightSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 72
            }, 2);
            AnimationIdleTargetableMouseOverRightSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfIdleTargetableMouseOverLeftSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 72
            }, 2);
            AnimationIdleTargetableMouseOverLeftSprite.Initialize(graphics);

            AnimationWalkRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfWalkRightSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 75
            }, 2);
            AnimationWalkRightSprite.Initialize(graphics);

            AnimationWalkLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfWalkLeftSpriteSheet",
                FrameSize = new Point(61, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = true,
                FeetToHead = 75
            }, 2);
            AnimationWalkLeftSprite.Initialize(graphics);

            AnimationStrikeDownLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfStrikeFrontLeftSpriteSheet",
                FrameSize = new Point(101, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 2);
            AnimationStrikeDownLeftSprite.Initialize(graphics);

            AnimationStrikeDownRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfStrikeFrontRightSpriteSheet",
                FrameSize = new Point(101, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 2);
            AnimationStrikeDownRightSprite.Initialize(graphics);

            AnimationStrikeFrontLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfStrikeFrontLeftSpriteSheet",
                FrameSize = new Point(101, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 2);
            AnimationStrikeFrontLeftSprite.Initialize(graphics);

            AnimationStrikeFrontRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfStrikeFrontRightSpriteSheet",
                FrameSize = new Point(101, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 2);
            AnimationStrikeFrontRightSprite.Initialize(graphics);

            AnimationStrikeUpLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfStrikeFrontLeftSpriteSheet",
                FrameSize = new Point(101, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 2);
            AnimationStrikeUpLeftSprite.Initialize(graphics);

            AnimationStrikeUpRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "ElfStrikeFrontRightSpriteSheet",
                FrameSize = new Point(101, 80),
                NbFrames = new Point(10, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 2);
            AnimationStrikeUpRightSprite.Initialize(graphics);

            AnimationSprite = AnimationIdleRightSprite;
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            AnimationWalkRightSprite.LoadContent(spriteBatch);
            AnimationWalkLeftSprite.LoadContent(spriteBatch);
            AnimationIdleRightSprite.LoadContent(spriteBatch);
            AnimationIdleLeftSprite.LoadContent(spriteBatch);
            AnimationIdleSelectedLeftSprite.LoadContent(spriteBatch);
            AnimationIdleSelectedRightSprite.LoadContent(spriteBatch);
            AnimationIdleTargetableLeftSprite.LoadContent(spriteBatch);
            AnimationIdleTargetableRightSprite.LoadContent(spriteBatch);
            AnimationIdleTargetableMouseOverLeftSprite.LoadContent(spriteBatch);
            AnimationIdleTargetableMouseOverRightSprite.LoadContent(spriteBatch);
            AnimationStrikeDownLeftSprite.LoadContent(spriteBatch);
            AnimationStrikeDownRightSprite.LoadContent(spriteBatch);
            AnimationStrikeFrontLeftSprite.LoadContent(spriteBatch);
            AnimationStrikeFrontRightSprite.LoadContent(spriteBatch);
            AnimationStrikeUpLeftSprite.LoadContent(spriteBatch);
            AnimationStrikeUpRightSprite.LoadContent(spriteBatch);
        }
    }
}