using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class Paladin : Character
    {
        public override void Initialize(Game game, GraphicsDeviceManager graphics)
        {
            CharacterSpeed = 3;
            CharacterFaction = "Good";
            FacingRight = false;
            CharacterWeapon.Range = 2;
            CharacterWeapon.WeaponName = "Two Handed Sword";

            AnimationIdleLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleLeftSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 75
            }, 7);
            AnimationIdleLeftSprite.Initialize(graphics);

            AnimationIdleRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleRightSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 75
            }, 7);
            AnimationIdleRightSprite.Initialize(graphics);

            AnimationIdleSelectedRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleSelectedRightSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 77
            }, 7);
            AnimationIdleSelectedRightSprite.Initialize(graphics);

            AnimationIdleSelectedLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleSelectedLeftSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 77
            }, 7);
            AnimationIdleSelectedLeftSprite.Initialize(graphics);

            AnimationIdleTargetableRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleTargetableRightSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 77
            }, 7);
            AnimationIdleTargetableRightSprite.Initialize(graphics);

            AnimationIdleTargetableLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleTargetableLeftSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 77
            }, 7);
            AnimationIdleTargetableLeftSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleTargetableMouseOverRightSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 77
            }, 7);
            AnimationIdleTargetableMouseOverRightSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinIdleTargetableMouseOverLeftSpriteSheet",
                FrameSize = new Point(81, 125),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 77
            }, 7);
            AnimationIdleTargetableMouseOverLeftSprite.Initialize(graphics);

            AnimationWalkLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinWalkLeftSpriteSheet",
                FrameSize = new Point(80, 125),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 75
            }, 7);
            AnimationWalkLeftSprite.Initialize(graphics);

            AnimationWalkRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinWalkRightSpriteSheet",
                FrameSize = new Point(80, 125),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = true,
                FeetToHead = 75
            }, 7);
            AnimationWalkRightSprite.Initialize(graphics);

            AnimationStrikeDownLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinStrikeDownLeftSpriteSheet",
                FrameSize = new Point(121, 125),
                NbFrames = new Point(4, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 7);
            AnimationStrikeDownLeftSprite.Initialize(graphics);

            AnimationStrikeDownRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinStrikeDownRightSpriteSheet",
                FrameSize = new Point(121, 125),
                NbFrames = new Point(4, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 7);
            AnimationStrikeDownRightSprite.Initialize(graphics);

            AnimationStrikeFrontLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinStrikeFrontLeftSpriteSheet",
                FrameSize = new Point(121, 125),
                NbFrames = new Point(4, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 7);
            AnimationStrikeFrontLeftSprite.Initialize(graphics);

            AnimationStrikeFrontRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinStrikeFrontRightSpriteSheet",
                FrameSize = new Point(121, 125),
                NbFrames = new Point(4, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 7);
            AnimationStrikeFrontRightSprite.Initialize(graphics);

            AnimationStrikeUpLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinStrikeUpLeftSpriteSheet",
                FrameSize = new Point(131, 125),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 7);
            AnimationStrikeUpLeftSprite.Initialize(graphics);

            AnimationStrikeUpRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "PaladinStrikeUpRightSpriteSheet",
                FrameSize = new Point(131, 125),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 11),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 7);
            AnimationStrikeUpRightSprite.Initialize(graphics);

            AnimationSprite = AnimationIdleLeftSprite;
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
