using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heroes_of_the_Ring
{
    class FightTilesSprite
    {
        public const int BlockWidth = 50;
        public const int BlockHeight = 40;
        public Vector2 Position = new Vector2(0, 0);
        public Texture2D Sprite { get; set; }

        public byte[,] FtMap =
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

        public void LoadContent(ContentManager theContentManager)
        {
            Sprite = theContentManager.Load<Texture2D>("CrossedSwordsTile");
        }


        public void Draw(SpriteBatch theSpriteBatch, GraphicsDeviceManager graphics)
        {
            for (var x = 0; x < FtMap.GetLength(1); x++)
            {
                for (var y = 0; y < FtMap.GetLength(0); y++)
                {
                    // ReSharper disable PossibleLossOfFraction
                    var pos = new Vector2(0, (graphics.PreferredBackBufferHeight - BlockHeight * 12 - 20) / 2);
                    // ReSharper restore PossibleLossOfFraction
                    switch (FtMap[y, x])
                    {
                        case 1:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight);
                            theSpriteBatch.Draw(Sprite, pos, Color.White);
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
        public void CharacterRangePoints(List<Character> characters, int count, GraphicsDeviceManager graphics)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            var posXTile = ((int)characters[count].AnimationSprite.Position.X +
                characters[count].AnimationSprite.Definition.FrameSize.X / 2) / BattlefieldBackgroundSprite.BlockWidth;
            var posYTile = ((int)characters[count].AnimationSprite.Position.Y - topBottomScreen +
                characters[count].AnimationSprite.Definition.FrameSize.Y) / BattlefieldBackgroundSprite.BlockHeight;
            var found = false;

            for (var i = posYTile - characters[count].CharacterWeapon.Range; i <= posYTile + characters[count].CharacterWeapon.Range; i++)
            {
                for (var j = posXTile - characters[count].CharacterWeapon.Range; j <= posXTile + characters[count].CharacterWeapon.Range; j++)
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
                            break;
                        }
                    }
                    if (!found)
                    {
                        FtMap[i, j] = 1;
                    }
                    else
                    {
                        FtMap[i, j] = 2;
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
                    FtMap[i, j] = 0;
                }
            }
        }
    }
}