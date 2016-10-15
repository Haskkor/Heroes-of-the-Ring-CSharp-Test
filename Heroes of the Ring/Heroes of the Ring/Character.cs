using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heroes_of_the_Ring
{
    public abstract class Character
    {
        public AnimationSprite AnimationIdleRightSprite;
        public AnimationSprite AnimationIdleLeftSprite;
        public AnimationSprite AnimationIdleSelectedRightSprite;
        public AnimationSprite AnimationIdleSelectedLeftSprite;
        public AnimationSprite AnimationIdleTargetableRightSprite;
        public AnimationSprite AnimationIdleTargetableLeftSprite;
        public AnimationSprite AnimationIdleTargetableMouseOverRightSprite;
        public AnimationSprite AnimationIdleTargetableMouseOverLeftSprite;
        public AnimationSprite AnimationWalkRightSprite;
        public AnimationSprite AnimationWalkLeftSprite;
        public AnimationSprite AnimationStrikeDownRightSprite;
        public AnimationSprite AnimationStrikeDownLeftSprite;
        public AnimationSprite AnimationStrikeFrontRightSprite;
        public AnimationSprite AnimationStrikeFrontLeftSprite;
        public AnimationSprite AnimationStrikeUpLeftSprite;
        public AnimationSprite AnimationStrikeUpRightSprite;
        public AnimationSprite AnimationSprite;

        public bool FacingRight;

        public int CharacterSpeed; // Vitesse de déplacement propre à chaque personnage
        
        public string CharacterFaction; // Faction du personnage

        public Weapon CharacterWeapon = new Weapon(); // Arme du personnage

        public bool TargetableMouseOver; // Indique si le personnage est survolé par la souris et est ciblable

        public virtual void Initialize(Game game, GraphicsDeviceManager graphics) { }

        public virtual void LoadContent(SpriteBatch spriteBatch) { }

        public AnimationSprite CharacterSelectedSprite(List<Character> characters, int count)
        {
            if (characters[count].FacingRight)
            {
                characters[count].AnimationIdleSelectedRightSprite.Position =
                    characters[count].AnimationSprite.Position;
                characters[count].AnimationIdleSelectedRightSprite.Position = new Vector2(
                    characters[count].AnimationIdleSelectedRightSprite.Position.X,
                    characters[count].AnimationIdleSelectedRightSprite.Position.Y);
                characters[count].AnimationSprite = characters[count].AnimationIdleSelectedRightSprite;
            }
            else
            {
                characters[count].AnimationIdleSelectedLeftSprite.Position =
                    characters[count].AnimationSprite.Position;
                characters[count].AnimationIdleSelectedLeftSprite.Position = new Vector2(
                    characters[count].AnimationIdleSelectedLeftSprite.Position.X,
                    characters[count].AnimationIdleSelectedLeftSprite.Position.Y);
                characters[count].AnimationSprite = characters[count].AnimationIdleSelectedLeftSprite;
            }
            return characters[count].AnimationSprite;
        }
    }
}
