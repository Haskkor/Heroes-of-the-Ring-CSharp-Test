using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    public class AnimationSprite
    {
        public Vector2 Position { get; set; } // Position du sprite
        public Vector2 Direction { get; set; } // Direction du sprite pendant le mouvement
        protected Game Game;
        public AnimationDefinition Definition;
        protected SpriteBatch SpriteBatch;
        protected Texture2D Sprite;
        protected Point CurrentFrame;
        public bool FinishedAnimation = false;
        protected double TimeBetweenFrame = 16; // Temps entre les frames de l'animation
        protected double LastFrameUpdatedTime = 0;
        public float Speed { get; set; }
        private bool _movingSprite;
        public readonly int SpritePositionMod; // Modificateur de position pour le centrage de l'animation

        public AnimationSprite(Game game, AnimationDefinition definition, int spritePosMod)
        {
            Game = game;
            Definition = definition;
            CurrentFrame = new Point();
            SpritePositionMod = spritePosMod;
            Speed = 0.07f;
        }

        private int _framerate = 60;
        public int Framerate
        {
            get { return _framerate; }
            set
            {
                if (value <= 0)
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException(paramName: "Framerate can't be less or equal to 0");
                    // ReSharper restore NotResolvedInText
                if (_framerate == value) return;
                _framerate = value;
                TimeBetweenFrame = 1000.0d / _framerate;
            }
        }

        public void Initialize(GraphicsDeviceManager graphics)
        {
            Framerate = Definition.FrameRate;
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            Position = new Vector2(BattlefieldBackgroundSprite.BlockWidth * Definition.StartPosition.X + BattlefieldBackgroundSprite.BlockWidth / 2 -
            Definition.FrameSize.X / 2, BattlefieldBackgroundSprite.BlockHeight * Definition.StartPosition.Y + BattlefieldBackgroundSprite.BlockHeight / 2
            - Definition.FrameSize.Y + topBottomScreen + SpritePositionMod);
        }

        public void Reset()
        {
            CurrentFrame = new Point();
            FinishedAnimation = false;
            LastFrameUpdatedTime = 0;
        }

        public void LoadContent(SpriteBatch spritebatch = null)
        {
            Sprite = Game.Content.Load<Texture2D>(Definition.AssetName);
            SpriteBatch = spritebatch ?? new SpriteBatch(Game.GraphicsDevice);
        }

        public void Update(GameTime time)
        {
            if (_movingSprite)
            {
                Position += Vector2.Normalize(Direction - Position) * Speed * (float)time.ElapsedGameTime.TotalMilliseconds;
                var tempPosX = (int) Position.X;
                var tempDirX = (int) Direction.X;
                var tempPosY = (int)Position.Y;
                var tempDirY = (int)Direction.Y;
                if ((tempPosX > tempDirX - 2 && tempPosX < tempDirX + 2) &&
                    (tempPosY > tempDirY - 2 && tempPosY < tempDirY + 2))
                {
                    Position = Direction;
                    _movingSprite = false;
                }
            }
            if (FinishedAnimation) return;
            LastFrameUpdatedTime += time.ElapsedGameTime.Milliseconds;
            if (!(LastFrameUpdatedTime > TimeBetweenFrame)) return;
            LastFrameUpdatedTime = 0;
            if (Definition.Loop)
            {
                CurrentFrame.X++;
                if (CurrentFrame.X < Definition.NbFrames.X) return;
                CurrentFrame.X = 0;
                CurrentFrame.Y++;
                if (CurrentFrame.Y >= Definition.NbFrames.Y)
                    CurrentFrame.Y = 0;
            }
            else
            {
                CurrentFrame.X++;
                if (CurrentFrame.X < Definition.NbFrames.X) return;
                CurrentFrame.X = 0;
                CurrentFrame.Y++;
                if (CurrentFrame.Y < Definition.NbFrames.Y) return;
                CurrentFrame.X = Definition.NbFrames.X - 1;
                CurrentFrame.Y = Definition.NbFrames.Y - 1;
                FinishedAnimation = true;
            }
        }

        public void Draw(GameTime time, bool doBeginEnd = true)
        {
            if(doBeginEnd) SpriteBatch.Begin();

            SpriteBatch.Draw(Sprite,
                                  new Rectangle((int) Position.X, (int) Position.Y, Definition.FrameSize.X, Definition.FrameSize.Y),
                                  new Rectangle(CurrentFrame.X * Definition.FrameSize.X, CurrentFrame.Y * Definition.FrameSize.Y, Definition.FrameSize.X, 
                                      Definition.FrameSize.Y),
                                  Color.White);

            if (doBeginEnd) SpriteBatch.End();
        }

        // Restreint les positions possibles du sprite sur la fenêtre
        public void SpriteBattlefieldPosition(int destinationX, int destinationY, bool isMoving, GraphicsDeviceManager graphics, AnimationDefinition spriteDefinition)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            if (destinationX >= graphics.PreferredBackBufferWidth || destinationX < 0) return;
            if (destinationY < topBottomScreen ||
                destinationY > graphics.PreferredBackBufferHeight - topBottomScreen - 20) return;
            var modPosX = destinationX % BattlefieldBackgroundSprite.BlockWidth;
            var modPosY = (destinationY - topBottomScreen) % BattlefieldBackgroundSprite.BlockHeight;
            if ((modPosX < BattlefieldBackgroundSprite.BlockWidth / 2) || (modPosX > BattlefieldBackgroundSprite.BlockWidth / 2))
            {
                destinationX += BattlefieldBackgroundSprite.BlockWidth / 2 - modPosX;
            }
            if ((modPosY < BattlefieldBackgroundSprite.BlockHeight / 2) || (modPosY > BattlefieldBackgroundSprite.BlockHeight / 2))
            {
                destinationY += BattlefieldBackgroundSprite.BlockHeight / 2 - modPosY;
            }
            if (isMoving)
            {
                Direction = new Vector2(destinationX - spriteDefinition.FrameSize.X / 2, destinationY - spriteDefinition.FrameSize.Y + SpritePositionMod);
                _movingSprite = true;
            }
            else                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            {
                Position = new Vector2(destinationX - spriteDefinition.FrameSize.X / 2, destinationY - spriteDefinition.FrameSize.Y + SpritePositionMod);
            }
        }

        // Compare la position du clic et la position d'un personnage et renvoie true si il y a une égalité
        public bool ClicAndCharacter(float mouseX, float mouseY, GraphicsDeviceManager graphics)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            var posXTile = (int)(Position.X + Definition.FrameSize.X / 2) / BattlefieldBackgroundSprite.BlockWidth;
            var posYTile = ((int)(Position.Y + Definition.FrameSize.Y) - topBottomScreen) / BattlefieldBackgroundSprite.BlockHeight;
            var mouseXTile = (int)(mouseX) / BattlefieldBackgroundSprite.BlockWidth;
            var mouseYTile = ((int)(mouseY) - topBottomScreen) / BattlefieldBackgroundSprite.BlockHeight;

            return posXTile == mouseXTile && posYTile == mouseYTile;
        }

        // Vérifie que le clic ne soit pas hors des limites du champs de bataille
        public bool ClickOutOfBounds(float mouseX, float mouseY, GraphicsDeviceManager graphics)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;

            return mouseX > 16 * BattlefieldBackgroundSprite.BlockWidth || mouseY - topBottomScreen > 12 * 
                   BattlefieldBackgroundSprite.BlockHeight || mouseX < 0 || mouseY - topBottomScreen < 0;
        }
    }
}