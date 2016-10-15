using Microsoft.Xna.Framework;

namespace Heroes_of_the_Ring
{
    public class AnimationDefinition
    {
        public string AssetName { get; set; } // Nom du content
        public Point FrameSize { get; set; } // Taille de la frame
        public Point NbFrames { get; set; } // Nombre de frames de l'animation
        public int FrameRate { get; set; } // Vitesse de l'animation
        public bool Loop { get; set; } // Animation en boucle
        public Vector2 StartPosition { get; set; } // Position de départ des frames
        public int FeetToHead { get; set; } // Distance du haut de la frame à la tête du personnage
        public bool ReturnIdle { get; set; } // Indique si l'animation doit retourner en idle une fois finie
    }
}
