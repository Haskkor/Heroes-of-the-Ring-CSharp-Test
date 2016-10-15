using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heroes_of_the_Ring
{
    class MoveTilesSprite
    {
        public const int BlockWidth = 50;
        public const int BlockHeight = 40;
        public Vector2 Position = new Vector2(0, 0);

        public byte[,] MtMap =
        {  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };

        readonly Texture2D[] _t2DTiles = new Texture2D[3];

        public Texture2D Texture { get; set; }

        public void LoadContent(ContentManager theContentManager)
        {
            _t2DTiles[1] = theContentManager.Load<Texture2D>("OneRingTile");
            _t2DTiles[2] = theContentManager.Load<Texture2D>("GreatEyeTile");
        }


        public void Draw(SpriteBatch theSpriteBatch, GraphicsDeviceManager graphics)
        {
            for (var x = 0; x < MtMap.GetLength(1); x++)
            {
                for (var y = 0; y < MtMap.GetLength(0); y++)
                {
                    // ReSharper disable PossibleLossOfFraction
                    var pos = new Vector2(0, (graphics.PreferredBackBufferHeight - BlockHeight * 12 - 20) / 2);
                    // ReSharper restore PossibleLossOfFraction
                    switch (MtMap[y, x])
                    {
                        case 1:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight);
                            theSpriteBatch.Draw(_t2DTiles[MtMap[y, x]], pos, Color.White);
                            break;
                        case 2:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight);
                            theSpriteBatch.Draw(_t2DTiles[MtMap[y, x]], pos, Color.White);
                            break;
                        default:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight);
                            break;
                    }
                }
            }
        }

        // Transforme la position du personnage en coordonnées en nombre de blocs sur le champs de bataille et modifie le 
        // MoveTilesMap en fonction
        public void CharacterWayPoints(List<Character> characters, int count, GraphicsDeviceManager graphics)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            var posXTile = ((int)characters[count].AnimationSprite.Position.X + 
                characters[count].AnimationSprite.Definition.FrameSize.X / 2) / BattlefieldBackgroundSprite.BlockWidth;
            var posYTile = ((int)characters[count].AnimationSprite.Position.Y - topBottomScreen + 
                characters[count].AnimationSprite.Definition.FrameSize.Y) / BattlefieldBackgroundSprite.BlockHeight;
            var found = false;

            for (var i = posYTile - characters[count].CharacterSpeed; i <= posYTile + characters[count].CharacterSpeed; i++)
            {
                for (var j = posXTile - characters[count].CharacterSpeed; j <= posXTile + characters[count].CharacterSpeed; j++)
                {
                    if (i < 0 || j < 0 || i >= 12 || j >= 16) continue;
                    foreach (var t in characters)
                    {
                        var tempPosXTile = ((int)t.AnimationSprite.Position.X + 
                                            t.AnimationSprite.Definition.FrameSize.X / 2) / 
                                           BattlefieldBackgroundSprite.BlockWidth;
                        var tempPosYTile = ((int)t.AnimationSprite.Position.Y - topBottomScreen + 
                                            t.AnimationSprite.Definition.FrameSize.Y) / 
                                           BattlefieldBackgroundSprite.BlockHeight;
                        if (i == tempPosYTile && j == tempPosXTile)
                        {
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        switch (characters[count].CharacterFaction)
                        {
                            case "Good":
                                MtMap[i, j] = 1;
                                break;
                            case "Evil":
                                MtMap[i, j] = 2;
                                break;
                        }
                    }
                    found = false;
                }
            }
        }

        // Remet la map à zéro
        public void ResetMap()
        {
            for (var i = 0; i < 12; i++)
            {
                for (var j = 0; j < 16; j++)
                {
                    MtMap[i, j] = 0;
                }
            }
        }

        // Indique si le clic a été fait sur une des cases de déplacement autorisées pour le personnage
        public bool ClicOnMovingTile(float mouseX, float mouseY, GraphicsDeviceManager graphics)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            var mouseXTile = (int)(mouseX) / BattlefieldBackgroundSprite.BlockWidth;
            var mouseYTile = ((int)(mouseY) - topBottomScreen) / BattlefieldBackgroundSprite.BlockHeight;

            return MtMap[mouseYTile, mouseXTile] != 0;
        }
    }
}