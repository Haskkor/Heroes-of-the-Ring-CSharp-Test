using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heroes_of_the_Ring
{
    class CrossedSwordsButton
    {
        public Texture2D Sprite { get; set; }
        public Texture2D SpriteMouseOut { get; set; }
        public Texture2D SpriteMouseOver { get; set; }
        public Texture2D SpriteClicked { get; set; }
        public Vector2 Position = new Vector2(0, 0);
        public int SpriteWidth = 80;
        public int SpriteHeight = 80;
        private readonly List<int> _tempCharacters = new List<int>(); // Liste des index des personnages pouvant être ciblés
        private readonly ContentManager _content;
        private int _characterStrikableIndex;

        public CrossedSwordsButton(ContentManager content)
        {
            _content = content;
        }

        public void LoadContent(ContentManager theContentManager, GraphicsDeviceManager graphics)
        {
            SpriteMouseOut = theContentManager.Load<Texture2D>("CrossedSwords");
            SpriteMouseOver = theContentManager.Load<Texture2D>("CrossedSwordsMouseOver");
            SpriteClicked = theContentManager.Load<Texture2D>("CrossedSwordsClicked");

            var topScreen = BattlefieldBackgroundSprite.BlockHeight * 12 + 20 +
                (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            Position = new Vector2(SpriteWidth * 3, topScreen + ((graphics.PreferredBackBufferHeight - topScreen) / 2) -
                SpriteHeight / 2);

            Sprite = SpriteMouseOut;
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(Sprite, Position, Color.White);
        }

        public void CharactersTargetable(bool targetable)
        {
            for (var t = 0; t < Game1.Characters.Count; t++)
            {
                if (!Game1.Characters[t].CharacterFaction.Equals(Game1.Characters[Game1.Count].CharacterFaction))
                {
                    if (Game1.Characters[t].FacingRight)
                    {
                        if (targetable)
                        {
                            Game1.Characters[t].AnimationIdleTargetableRightSprite.Position = new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                (Game1.Characters[t].AnimationIdleTargetableRightSprite.Definition.FrameSize.X - Game1.Characters[t].AnimationSprite.Definition.FrameSize.X) / 2,
                                Game1.Characters[t].AnimationSprite.Position.Y);
                            Game1.Characters[t].AnimationSprite = Game1.Characters[t].AnimationIdleTargetableRightSprite;
                            _tempCharacters.Add(t);
                        }
                        else
                        {
                            Game1.Characters[t].AnimationIdleRightSprite.Position = new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                (Game1.Characters[t].AnimationIdleRightSprite.Definition.FrameSize.X - Game1.Characters[t].AnimationSprite.Definition.FrameSize.X) / 2,
                                Game1.Characters[t].AnimationSprite.Position.Y);
                            Game1.Characters[t].AnimationSprite = Game1.Characters[t].AnimationIdleRightSprite;
                        }
                    }
                    else
                    {
                        if (targetable)
                        {
                            Game1.Characters[t].AnimationIdleTargetableLeftSprite.Position = new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                (Game1.Characters[t].AnimationIdleTargetableLeftSprite.Definition.FrameSize.X - Game1.Characters[t].AnimationSprite.Definition.FrameSize.X) / 2,
                                Game1.Characters[t].AnimationSprite.Position.Y);
                            Game1.Characters[t].AnimationSprite = Game1.Characters[t].AnimationIdleTargetableLeftSprite;
                            _tempCharacters.Add(t);
                        }
                        else
                        {
                            Game1.Characters[t].AnimationIdleLeftSprite.Position = new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                (Game1.Characters[t].AnimationIdleLeftSprite.Definition.FrameSize.X - Game1.Characters[t].AnimationSprite.Definition.FrameSize.X) / 2,
                                Game1.Characters[t].AnimationSprite.Position.Y);
                            Game1.Characters[t].AnimationSprite = Game1.Characters[t].AnimationIdleLeftSprite;
                        }
                    }
                }
            }
        }

        // Surligne en rouge les ennemis survolés par la souris et étant attaquables
        public void MouseOverTargetableCharacters(int mouseX, int mouseY, FightTilesSprite fightTileSprite, GraphicsDeviceManager graphics, bool hasStriked)
        {
            var found = false;
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            // Trie les personnages dans l'ordre décroissant de leur position en Y
            var orderedList = OrderCharactersDescending(_tempCharacters);
            foreach (var t in orderedList)
            {
                var posYTile = ((int)(Game1.Characters[t].AnimationSprite.Position.Y + Game1.Characters[t].AnimationSprite.Definition.FrameSize.Y) -
                    topBottomScreen)/BattlefieldBackgroundSprite.BlockHeight;
                if (!hasStriked &&
                    mouseX >
                    Game1.Characters[t].AnimationSprite.Position.X +
                    Game1.Characters[t].AnimationSprite.Definition.FrameSize.X/2
                    - BattlefieldBackgroundSprite.BlockWidth/2 &&
                    mouseX < Game1.Characters[t].AnimationSprite.Position.X +
                    Game1.Characters[t].AnimationSprite.Definition.FrameSize.X/2 +
                    BattlefieldBackgroundSprite.BlockWidth/2 && mouseY >
                    posYTile*BattlefieldBackgroundSprite.BlockHeight + BattlefieldBackgroundSprite.BlockHeight/2 +
                    topBottomScreen -
                    Game1.Characters[t].AnimationSprite.Definition.FeetToHead &&
                    mouseY < posYTile*BattlefieldBackgroundSprite.BlockHeight +
                    BattlefieldBackgroundSprite.BlockHeight/2 + topBottomScreen)
                {
                    if (!found)
                    {
                        // Remet tous les autres personnages en mode non-mouseOver quand on sélectionne un nouveau personnage
                        foreach (var c in orderedList)
                        {
                            if (Game1.Characters[c].TargetableMouseOver)
                            {
                                if (Game1.Characters[c].FacingRight)
                                {
                                    Game1.Characters[c].AnimationIdleTargetableRightSprite.Position =
                                        new Vector2(Game1.Characters[c].AnimationSprite.Position.X -
                                                    (Game1.Characters[c].AnimationIdleTargetableRightSprite.Definition
                                                        .FrameSize.X -
                                                     Game1.Characters[c].AnimationSprite.Definition.FrameSize.X)/2,
                                            Game1.Characters[c].AnimationSprite.Position.Y);
                                    Game1.Characters[c].AnimationSprite =
                                        Game1.Characters[c].AnimationIdleTargetableRightSprite;
                                }
                                else
                                {
                                    Game1.Characters[c].AnimationIdleTargetableLeftSprite.Position =
                                        new Vector2(Game1.Characters[c].AnimationSprite.Position.X -
                                                    (Game1.Characters[c].AnimationIdleTargetableLeftSprite.Definition
                                                        .FrameSize.X -
                                                     Game1.Characters[c].AnimationSprite.Definition.FrameSize.X)/2,
                                            Game1.Characters[c].AnimationSprite.Position.Y);
                                    Game1.Characters[c].AnimationSprite =
                                        Game1.Characters[c].AnimationIdleTargetableLeftSprite;
                                }
                                Game1.Characters[c].TargetableMouseOver = false;
                            }
                        }
                        found = true;
                        var tempPosXTile = ((int) Game1.Characters[t].AnimationSprite.Position.X +
                                            Game1.Characters[t].AnimationSprite.Definition.FrameSize.X/2)/
                                           BattlefieldBackgroundSprite.BlockWidth;
                        var tempPosYTile = ((int) Game1.Characters[t].AnimationSprite.Position.Y - topBottomScreen +
                                            Game1.Characters[t].AnimationSprite.Definition.FrameSize.Y)/
                                           BattlefieldBackgroundSprite.BlockHeight;
                        if (fightTileSprite.FtMap[tempPosYTile, tempPosXTile] == 2)
                        {
                            // Change le curseur lors du survol
                            Game1.CursorTexture = _content.Load<Texture2D>("BattleCursorMouseOverTargetableCharacter");
                            // Bascule le personnage survolé en mode mouseOver
                            _characterStrikableIndex = t;
                            if (Game1.Characters[t].FacingRight)
                            {
                                Game1.Characters[t].AnimationIdleTargetableMouseOverRightSprite.Position =
                                    new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                                (Game1.Characters[t].AnimationIdleTargetableMouseOverRightSprite
                                                    .Definition.FrameSize.X -
                                                 Game1.Characters[t].AnimationSprite.Definition.FrameSize.X)/2,
                                        Game1.Characters[t].AnimationSprite.Position.Y);
                                Game1.Characters[t].AnimationSprite =
                                    Game1.Characters[t].AnimationIdleTargetableMouseOverRightSprite;
                            }
                            else
                            {
                                Game1.Characters[t].AnimationIdleTargetableMouseOverLeftSprite.Position =
                                    new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                                (Game1.Characters[t].AnimationIdleTargetableMouseOverLeftSprite
                                                    .Definition.FrameSize.X -
                                                 Game1.Characters[t].AnimationSprite.Definition.FrameSize.X)/2,
                                        Game1.Characters[t].AnimationSprite.Position.Y);
                                Game1.Characters[t].AnimationSprite =
                                    Game1.Characters[t].AnimationIdleTargetableMouseOverLeftSprite;
                            }
                            Game1.Characters[t].TargetableMouseOver = true;
                        }
                    }
                }
                    // Remet les autres personnages en mode non-mouseOver quand on sort des zones de sélection 
                else
                {
                    if (Game1.Characters[t].FacingRight)
                    {
                        Game1.Characters[t].AnimationIdleTargetableRightSprite.Position =
                            new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                        (Game1.Characters[t].AnimationIdleTargetableRightSprite.Definition.FrameSize.X -
                                         Game1.Characters[t].AnimationSprite.Definition.FrameSize.X)/2,
                                Game1.Characters[t].AnimationSprite.Position.Y);
                        Game1.Characters[t].AnimationSprite = Game1.Characters[t].AnimationIdleTargetableRightSprite;
                    }
                    else
                    {
                        Game1.Characters[t].AnimationIdleTargetableLeftSprite.Position = 
                            new Vector2(Game1.Characters[t].AnimationSprite.Position.X -
                                        (Game1.Characters[t].AnimationIdleTargetableLeftSprite.Definition.FrameSize.X -
                                         Game1.Characters[t].AnimationSprite.Definition.FrameSize.X)/2,
                                Game1.Characters[t].AnimationSprite.Position.Y);
                        Game1.Characters[t].AnimationSprite = Game1.Characters[t].AnimationIdleTargetableLeftSprite;
                    }
                    Game1.Characters[t].TargetableMouseOver = false;
                    Game1.CursorTexture = _content.Load<Texture2D>("BattleCursor");
                }
            }
        }

        public void ResetList()
        {
            _tempCharacters.Clear();
        }

        // Ordonne les personnages selon la valeur de leur position en Y (décroissant)
        public List<int> OrderCharactersDescending(List<int> characters)
        {
            var charactersTmp = characters;
            var count = charactersTmp.Count;
            bool permut;

            do
            {
                permut = false;
                for (var i = 0; i < count - 1; i++)
                {
                    if (Game1.Characters[charactersTmp[i]].AnimationSprite.Position.Y < Game1.Characters[charactersTmp[i + 1]].AnimationSprite.Position.Y)
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
        
        // Clic sur un personnage ciblable
        public void ClicOnTargetableCharacter(int mouseX, int mouseY, FightTilesSprite fightTileSprite, GraphicsDeviceManager graphics)
        {
            var topBottomScreen = (graphics.PreferredBackBufferHeight - BattlefieldBackgroundSprite.BlockHeight * 12 - 20) / 2;
            var tempPosXTileCharCount = ((int)Game1.Characters[Game1.Count].AnimationSprite.Position.X + Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X / 2) /
                            BattlefieldBackgroundSprite.BlockWidth;
            var tempPosYTileCharCount = ((int)Game1.Characters[Game1.Count].AnimationSprite.Position.Y - topBottomScreen +
                            Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.Y) / BattlefieldBackgroundSprite.BlockHeight;
            var tempPosXTileCharStrikable = ((int)Game1.Characters[_characterStrikableIndex].AnimationSprite.Position.X + Game1.Characters[_characterStrikableIndex].AnimationSprite.Definition.FrameSize.X / 2) / 
                            BattlefieldBackgroundSprite.BlockWidth;
            var tempPosYTileCharStrikable = ((int)Game1.Characters[_characterStrikableIndex].AnimationSprite.Position.Y - topBottomScreen +
                            Game1.Characters[_characterStrikableIndex].AnimationSprite.Definition.FrameSize.Y) / BattlefieldBackgroundSprite.BlockHeight;
            if (fightTileSprite.FtMap[tempPosYTileCharStrikable, tempPosXTileCharStrikable] == 2)
            {
                if (mouseX > Game1.Characters[_characterStrikableIndex].AnimationSprite.Position.X + Game1.Characters[_characterStrikableIndex].AnimationSprite.Definition.FrameSize.X / 2
                    - BattlefieldBackgroundSprite.BlockWidth / 2 && mouseX < Game1.Characters[_characterStrikableIndex].AnimationSprite.Position.X +
                    Game1.Characters[_characterStrikableIndex].AnimationSprite.Definition.FrameSize.X / 2 + BattlefieldBackgroundSprite.BlockWidth / 2 && mouseY >
                    tempPosYTileCharStrikable * BattlefieldBackgroundSprite.BlockHeight + BattlefieldBackgroundSprite.BlockHeight / 2 + topBottomScreen -
                    Game1.Characters[_characterStrikableIndex].AnimationSprite.Definition.FeetToHead && mouseY < tempPosYTileCharStrikable * BattlefieldBackgroundSprite.BlockHeight +
                    BattlefieldBackgroundSprite.BlockHeight / 2 + topBottomScreen)
                {
                    Game1.CharacterHasStriked = true;

                    // Ennemi à gauche
                    if (tempPosXTileCharCount > tempPosXTileCharStrikable)
                    {
                        // Ennemi au dessus
                        if (tempPosYTileCharCount > tempPosYTileCharStrikable)
                        {
                            Game1.Characters[Game1.Count].AnimationStrikeUpLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                    (Game1.Characters[Game1.Count].AnimationStrikeUpLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeUpLeftSprite;
                        }
                        // Ennemi en dessous
                        else if (tempPosYTileCharCount < tempPosYTileCharStrikable)
                        {
                            Game1.Characters[Game1.Count].AnimationStrikeDownLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                    (Game1.Characters[Game1.Count].AnimationStrikeDownLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeDownLeftSprite;
                        }
                        // Ennemi sur la même position en Y
                        else if (tempPosYTileCharCount == tempPosYTileCharStrikable)
                        {
                            Game1.Characters[Game1.Count].AnimationStrikeFrontLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                    (Game1.Characters[Game1.Count].AnimationStrikeFrontLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeFrontLeftSprite;
                        }
                        Game1.Characters[Game1.Count].FacingRight = false;
                    }
                    // Ennemi à droite
                    else if (tempPosXTileCharCount < tempPosXTileCharStrikable)
                    {
                        // Ennemi au dessus
                        if (tempPosYTileCharCount > tempPosYTileCharStrikable)
                        {
                            Game1.Characters[Game1.Count].AnimationStrikeUpRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                    (Game1.Characters[Game1.Count].AnimationStrikeUpRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeUpRightSprite;
                        }
                        // Ennemi en dessous
                        else if (tempPosYTileCharCount < tempPosYTileCharStrikable)
                        {
                            Game1.Characters[Game1.Count].AnimationStrikeDownRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                    (Game1.Characters[Game1.Count].AnimationStrikeDownRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeDownRightSprite;
                        }
                        // Ennemi sur la même position en Y
                        else if (tempPosYTileCharCount == tempPosYTileCharStrikable)
                        {
                            Game1.Characters[Game1.Count].AnimationStrikeFrontRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                    (Game1.Characters[Game1.Count].AnimationStrikeFrontRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                    Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                            Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeFrontRightSprite;
                        }
                        Game1.Characters[Game1.Count].FacingRight = true;
                    }
                    // Ennemi sur la même position en X
                    else if (tempPosXTileCharCount == tempPosXTileCharStrikable)
                    {
                        // Ennemi au dessus
                        if (tempPosYTileCharCount > tempPosYTileCharStrikable)
                        {
                            if (Game1.Characters[_characterStrikableIndex].FacingRight == false)
                            {
                                Game1.Characters[Game1.Count].AnimationStrikeUpRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                            (Game1.Characters[Game1.Count].AnimationStrikeUpRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                            Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeUpRightSprite;
                            }
                            else
                            {
                                Game1.Characters[Game1.Count].AnimationStrikeUpLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                            (Game1.Characters[Game1.Count].AnimationStrikeUpLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                            Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeUpLeftSprite;
                            }
                        }
                        // Ennemi en dessous
                        else if (tempPosYTileCharCount < tempPosYTileCharStrikable)
                        {
                            if (Game1.Characters[_characterStrikableIndex].FacingRight == false)
                            {
                                Game1.Characters[Game1.Count].AnimationStrikeDownRightSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                            (Game1.Characters[Game1.Count].AnimationStrikeDownRightSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                            Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeDownRightSprite;
                            }
                            else
                            {
                                Game1.Characters[Game1.Count].AnimationStrikeDownLeftSprite.Position = new Vector2(Game1.Characters[Game1.Count].AnimationSprite.Position.X -
                                            (Game1.Characters[Game1.Count].AnimationStrikeDownLeftSprite.Definition.FrameSize.X - Game1.Characters[Game1.Count].AnimationSprite.Definition.FrameSize.X) / 2,
                                            Game1.Characters[Game1.Count].AnimationSprite.Position.Y);
                                Game1.Characters[Game1.Count].AnimationSprite = Game1.Characters[Game1.Count].AnimationStrikeDownLeftSprite;
                            }
                        }
                        if (Game1.Characters[_characterStrikableIndex].FacingRight == true)
                        {
                            Game1.Characters[Game1.Count].FacingRight = false;
                        }
                        else
                        {
                            Game1.Characters[Game1.Count].FacingRight = true;
                        }
                    }
                }
            }
        }
    }
}