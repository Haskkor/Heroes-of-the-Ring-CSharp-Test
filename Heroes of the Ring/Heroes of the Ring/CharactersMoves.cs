using System.Linq;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Heroes_of_the_Ring
{
    class CharactersMoves
    {
        // Déplacement du personnage sur le champ de bataille
        public void MoveOnClick(int mouseX, int mouseY, GraphicsDeviceManager graphics,
            MoveTilesSprite moveTileSprite)
        {
            // Si le clic n'est pas en dehors du champ de bataille
            if (Game1.AnimationTemp.ClickOutOfBounds(mouseX, mouseY, graphics))
            {
                return;
            }
            Game1.Moving = true;

            // Si le clic n'est pas sur une case occupée par un autre personnage 
            if (Game1.Characters.Any(t => t.AnimationSprite.ClicAndCharacter(mouseX, mouseY, graphics)))
            {
                Game1.Moving = false;
                return;
            }

            // Si le clic n'est pas sur une case disponible au mouvement
            if (!(moveTileSprite.ClicOnMovingTile(mouseX, mouseY, graphics)))
            {
                Game1.Moving = false;
                return;
            }

            // Déplacement vers la droite ou vers la gauche
            var tempPosXTileChar = ((int)Game1.Characters[Game1.Count].AnimationSprite.Position.X + Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X / 2) /
                            BattlefieldBackgroundSprite.BlockWidth;
            var tempPosXTileMouse = mouseX / BattlefieldBackgroundSprite.BlockWidth;

            if (tempPosXTileMouse < tempPosXTileChar)
            {
                Game1.Characters[Game1.Count].AnimationWalkLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationWalkLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationWalkLeftSprite;
                Game1.Characters[Game1.Count].AnimationSprite.SpriteBattlefieldPosition(mouseX, mouseY, true, graphics,
                    Game1.Characters[Game1.Count].AnimationIdleLeftSprite.Definition);
                Game1.RightMove = false;
            }
            else if (tempPosXTileMouse > tempPosXTileChar)
            {
                Game1.Characters[Game1.Count].AnimationWalkRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationWalkRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationWalkRightSprite;
                Game1.Characters[Game1.Count].AnimationSprite.SpriteBattlefieldPosition(mouseX, mouseY, true, graphics,
                    Game1.Characters[Game1.Count].AnimationIdleRightSprite.Definition);
                Game1.RightMove = true;
            }
            else if (tempPosXTileMouse == tempPosXTileChar)
            {
                if (Game1.Characters[Game1.Count].FacingRight)
                {
                    Game1.Characters[Game1.Count].AnimationWalkRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationWalkRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                    Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationWalkRightSprite;
                    Game1.Characters[Game1.Count].AnimationSprite.SpriteBattlefieldPosition(mouseX, mouseY, true, graphics,
                        Game1.Characters[Game1.Count].AnimationIdleRightSprite.Definition);
                    Game1.RightMove = true;
                }
                else
                {
                    Game1.Characters[Game1.Count].AnimationWalkLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationWalkLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                    Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationWalkLeftSprite;
                    Game1.Characters[Game1.Count].AnimationSprite.SpriteBattlefieldPosition(mouseX, mouseY, true, graphics,
                        Game1.Characters[Game1.Count].AnimationIdleLeftSprite.Definition);
                    Game1.RightMove = false;
                }
            }

            Game1.AnimationTemp = Game1.Characters[Game1.Count].AnimationSprite;
            Game1.CharacterHasMoved = true;
        }

        // Fin de mouvement du personnage
        public void MoveEnds(MoveTilesSprite moveTileSprite, FightTilesSprite fightTilesSprite)
        {
            if (((int)Game1.AnimationTemp.Direction.X == (int)Game1.AnimationTemp.Position.X) &&
                ((int)Game1.AnimationTemp.Direction.Y == (int)Game1.AnimationTemp.Position.Y) && Game1.RightMove)
            {
                Game1.Characters[Game1.Count].AnimationIdleSelectedRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationIdleSelectedRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationIdleSelectedRightSprite;
                Game1.AnimationTemp.Position = new Vector2(-10, -10);
                moveTileSprite.ResetMap();
                fightTilesSprite.ResetMap();
                Game1.Characters[Game1.Count].FacingRight = true;
                Game1.Moving = false;
            }
            else if (((int)Game1.AnimationTemp.Direction.X == (int)Game1.AnimationTemp.Position.X) &&
                ((int)Game1.AnimationTemp.Direction.Y == (int)Game1.AnimationTemp.Position.Y) && !Game1.RightMove)
            {
                Game1.Characters[Game1.Count].AnimationIdleSelectedLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                    (Game1.Characters[Game1.Count].AnimationIdleSelectedLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationIdleSelectedLeftSprite;
                Game1.AnimationTemp.Position = new Vector2(-10, -10);
                moveTileSprite.ResetMap();
                fightTilesSprite.ResetMap();
                Game1.Characters[Game1.Count].FacingRight = false;
                Game1.Moving = false;
            }
        }

        // Ordonne les personnages selon la valeur de leur position en Y (croissant)
        public List<Character> OrderCharactersAscending(List<Character> characters, GraphicsDeviceManager graphics)
        {
            var charactersTmp = characters;
            var count = charactersTmp.Count;
            bool permut;

            do
            {
                permut = false;
                for (var i = 0; i < count - 1; i++)
                {
                    if (charactersTmp[i].AnimationSprite.Position.Y + charactersTmp[i].AnimationSprite.Definition.FrameSize.Y - 
                        charactersTmp[i].AnimationSprite.Definition.FeetToHead > charactersTmp[i + 1].AnimationSprite.Position.Y +
                        charactersTmp[i + 1].AnimationSprite.Definition.FrameSize.Y - charactersTmp[i + 1].AnimationSprite.Definition.FeetToHead)
                    {
                        var tmpChar = charactersTmp[i];
                        charactersTmp[i] = charactersTmp[i + 1];
                        charactersTmp[i + 1] = tmpChar;
                        permut = true;
                    }
                }
            }
            while (permut);

            return charactersTmp;
        }

        // Retourne sur l'animation de Idle Selected à la fin d'une animation le nécessitant
        public void BackToIdle(Character c)
        {
            if (c.AnimationSprite.FinishedAnimation && c.AnimationSprite.Definition.ReturnIdle)
            {
                c.AnimationSprite.Reset();
                if (c.FacingRight)
                {
                    c.AnimationIdleSelectedRightSprite.Position = new Vector2(c.AnimationSprite.Position.X -
                (c.AnimationIdleSelectedRightSprite.Definition.FrameSize.X - c.AnimationSprite.Definition.FrameSize.X) / 2,
                c.AnimationSprite.Position.Y);
                    c.AnimationSprite = c.AnimationIdleSelectedRightSprite;
                }
                else
                {
                    c.AnimationIdleSelectedLeftSprite.Position = new Vector2(c.AnimationSprite.Position.X -
                (c.AnimationIdleSelectedLeftSprite.Definition.FrameSize.X - c.AnimationSprite.Definition.FrameSize.X) / 2,
                c.AnimationSprite.Position.Y);
                    c.AnimationSprite = c.AnimationIdleSelectedLeftSprite;
                }
            }
        }
    }
}
