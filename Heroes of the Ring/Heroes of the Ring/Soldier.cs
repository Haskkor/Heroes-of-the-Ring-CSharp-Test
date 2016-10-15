using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class Soldier : Character
    {
       public override void Initialize(Game game, GraphicsDeviceManager graphics)
        {
            CharacterSpeed = 4;
            CharacterFaction = "Good";
            FacingRight = false;
            CharacterWeapon.Range = 1;
            CharacterWeapon.WeaponName = "One Handed Sword";

            AnimationIdleRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleRightSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 75
            }, 10);
            AnimationIdleRightSprite.Initialize(graphics);

            AnimationIdleLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleLeftSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 75
            }, 10);
            AnimationIdleLeftSprite.Initialize(graphics);

            AnimationIdleSelectedRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleSelectedRightSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 77
            }, 10);
            AnimationIdleSelectedRightSprite.Initialize(graphics);

            AnimationIdleSelectedLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleSelectedLeftSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 77
            }, 10);
            AnimationIdleSelectedLeftSprite.Initialize(graphics);

            AnimationIdleTargetableRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleTargetableRightSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 77
            }, 10);
            AnimationIdleTargetableRightSprite.Initialize(graphics);

            AnimationIdleTargetableLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleTargetableLeftSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 77
            }, 10);
            AnimationIdleTargetableLeftSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleTargetableMouseOverRightSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 77
            }, 10);
            AnimationIdleTargetableMouseOverRightSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierIdleTargetableMouseOverLeftSpriteSheet",
                FrameSize = new Point(45, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 77
            }, 10);
            AnimationIdleTargetableMouseOverLeftSprite.Initialize(graphics);

            AnimationWalkRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierWalkRightSpriteSheet",
                FrameSize = new Point(57, 115),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 75
            }, 10);
            AnimationWalkRightSprite.Initialize(graphics);

            AnimationWalkLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierWalkLeftSpriteSheet",
                FrameSize = new Point(57, 115),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = true,
                FeetToHead = 75
            }, 10);
            AnimationWalkLeftSprite.Initialize(graphics);

            AnimationStrikeDownLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierStrikeDownLeftSpriteSheet",
                FrameSize = new Point(81, 115),
                NbFrames = new Point(5, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 10);
            AnimationStrikeDownLeftSprite.Initialize(graphics);

            AnimationStrikeDownRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierStrikeDownRightSpriteSheet",
                FrameSize = new Point(81, 115),
                NbFrames = new Point(5, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 10);
            AnimationStrikeDownRightSprite.Initialize(graphics);

            AnimationStrikeFrontLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierStrikeFrontLeftSpriteSheet",
                FrameSize = new Point(118, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 10);
            AnimationStrikeFrontLeftSprite.Initialize(graphics);

            AnimationStrikeFrontRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierStrikeFrontRightSpriteSheet",
                FrameSize = new Point(118, 115),
                NbFrames = new Point(7, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 10);
            AnimationStrikeFrontRightSprite.Initialize(graphics);

            AnimationStrikeUpLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierStrikeUpLeftSpriteSheet",
                FrameSize = new Point(78, 115),
                NbFrames = new Point(4, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 10);
            AnimationStrikeUpLeftSprite.Initialize(graphics);

            AnimationStrikeUpRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "SoldierStrikeUpRightSpriteSheet",
                FrameSize = new Point(78, 115),
                NbFrames = new Point(4, 1),
                FrameRate = 7,
                StartPosition = new Vector2(15, 0),
                Loop = false,
                FeetToHead = 75,
                ReturnIdle = true
            }, 10);
            AnimationStrikeUpRightSprite.Initialize(graphics);

            AnimationSprite = AnimationIdleSelectedLeftSprite;
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