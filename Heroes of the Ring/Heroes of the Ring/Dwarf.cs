using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class Dwarf : Character
    {
        public override void Initialize(Game game, GraphicsDeviceManager graphics)
        {
            CharacterSpeed = 2;
            CharacterFaction = "Evil";
            FacingRight = true;
            CharacterWeapon.Range = 1;
            CharacterWeapon.WeaponName = "Axe";

            AnimationIdleRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleRightSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 65
            }, 18);
            AnimationIdleRightSprite.Initialize(graphics);

            AnimationIdleLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleLeftSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 65
            }, 18);
            AnimationIdleLeftSprite.Initialize(graphics);

            AnimationIdleSelectedRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleSelectedRightSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 67
            }, 18);
            AnimationIdleSelectedRightSprite.Initialize(graphics);

            AnimationIdleSelectedLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleSelectedLeftSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 67
            }, 18);
            AnimationIdleSelectedLeftSprite.Initialize(graphics);

            AnimationIdleTargetableRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleTargetableRightSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 67
            }, 18);
            AnimationIdleTargetableRightSprite.Initialize(graphics);

            AnimationIdleTargetableLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleTargetableLeftSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 67
            }, 18);
            AnimationIdleTargetableLeftSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleTargetableMouseOverRightSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 67
            }, 18);
            AnimationIdleTargetableMouseOverRightSprite.Initialize(graphics);

            AnimationIdleTargetableMouseOverLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfIdleTargetableMouseOverLeftSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(6, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 67
            }, 18);
            AnimationIdleTargetableMouseOverLeftSprite.Initialize(graphics);

            AnimationWalkRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfWalkRightSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 65
            }, 18);
            AnimationWalkRightSprite.Initialize(graphics);

            AnimationWalkLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfWalkLeftSpriteSheet",
                FrameSize = new Point(61, 90),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = true,
                FeetToHead = 65
            }, 18);
            AnimationWalkLeftSprite.Initialize(graphics);

            AnimationStrikeDownLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfStrikeDownLeftSpriteSheet",
                FrameSize = new Point(81, 90),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = false,
                FeetToHead = 65,
                ReturnIdle = true
            }, 18);
            AnimationStrikeDownLeftSprite.Initialize(graphics);

            AnimationStrikeDownRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfStrikeDownRightSpriteSheet",
                FrameSize = new Point(81, 90),
                NbFrames = new Point(11, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = false,
                FeetToHead = 65,
                ReturnIdle = true
            }, 18);
            AnimationStrikeDownRightSprite.Initialize(graphics);

            AnimationStrikeFrontLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfStrikeFrontLeftSpriteSheet",
                FrameSize = new Point(91, 90),
                NbFrames = new Point(9, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = false,
                FeetToHead = 65,
                ReturnIdle = true
            }, 18);
            AnimationStrikeFrontLeftSprite.Initialize(graphics);

            AnimationStrikeFrontRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfStrikeFrontRightSpriteSheet",
                FrameSize = new Point(91, 90),
                NbFrames = new Point(9, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = false,
                FeetToHead = 65,
                ReturnIdle = true
            }, 18);
            AnimationStrikeFrontRightSprite.Initialize(graphics);

            AnimationStrikeUpLeftSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfStrikeUpLeftSpriteSheet",
                FrameSize = new Point(91, 90),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = false,
                FeetToHead = 65,
                ReturnIdle = true
            }, 18);
            AnimationStrikeUpLeftSprite.Initialize(graphics);

            AnimationStrikeUpRightSprite = new AnimationSprite(game, new AnimationDefinition
            {
                AssetName = "DwarfStrikeUpRightSpriteSheet",
                FrameSize = new Point(91, 90),
                NbFrames = new Point(8, 1),
                FrameRate = 7,
                StartPosition = new Vector2(0, 11),
                Loop = false,
                FeetToHead = 65,
                ReturnIdle = true
            }, 18);
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