using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Heroes_of_the_Ring
{
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private readonly BattlefieldBackgroundSprite _bfBgSprite = new BattlefieldBackgroundSprite(); // Champ de bataille
        private readonly MoveTilesSprite _moveTileSprite = new MoveTilesSprite(); // Symboles signalant les tuiles disponibles au mouvement
        private readonly FightTilesSprite _fightTilesSprite = new FightTilesSprite(); // Symboles signalant les tuiles à portée de l'arme du personnage

        private readonly FootPrintsButton _footPrintsButton = new FootPrintsButton(); // Bouton de déplacement
        private bool _footPrintsButtonClicked;
        private readonly HourGlassButton _hourGlassButton = new HourGlassButton(); // Bouton de fin de tour
        private CrossedSwordsButton _crossedSwordsButton; // Bouton de combat
        private bool _crossedSwordsButtonClicked;

        private readonly CharactersMoves _charactersMoves = new CharactersMoves(); // Déplacements des personnages

        public static List<Character> Characters = new List<Character>(); // Liste des personnages
        private List<Character> _charactersOrderedByPosision = new List<Character>(); // Liste des personnages triés par 
                                                                                      // décroissante pour l'affichage
		public static int Count;
        public static bool CharacterHasMoved;
        public static bool CharacterHasStriked;

        private readonly Soldier _soldierSprite = new Soldier();
        private readonly Paladin _paladinSprite = new Paladin();
        private readonly Elf _elfSprite = new Elf();
        private readonly Dwarf _dwarfSprite = new Dwarf();

        public static AnimationSprite AnimationTemp;

        public static Texture2D CursorTexture;
        private Vector2 _cursorPosition;
        private MouseState _mouseState;
        private MouseState _oldMouseState;
        private int _mouseX, _mouseY;

        public static bool RightMove = true;
        public static bool Moving;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();
            Window.Title = "Heroes of the Ring";
            Window.AllowUserResizing = true;
        }

        //////////////////////////////////////
        //////////  INITIALISATION  //////////
        //////////////////////////////////////
        
        protected override void Initialize()
        {
            _crossedSwordsButton = new CrossedSwordsButton(Content);

            Characters.Add(_soldierSprite);
            Characters.Add(_elfSprite);
            Characters.Add(_paladinSprite);
            Characters.Add(_dwarfSprite);

			foreach (var t in Characters)
			{
			    t.Initialize(this, _graphics);
			}

            AnimationTemp = new AnimationSprite(this, new AnimationDefinition(), 0)
            {
                Direction = new Vector2(0, 0),
                Position = new Vector2(10, 10)
            };

            base.Initialize();
        }

        //////////////////////////////////////////////
        //////////  CHARGEMENT DES CONTENT  //////////
        //////////////////////////////////////////////
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            CursorTexture = Content.Load<Texture2D>("BattleCursor");

            _bfBgSprite.LoadContent(Content, "BattlefieldBackground");
            _moveTileSprite.LoadContent(Content);
            _fightTilesSprite.LoadContent(Content);
            _footPrintsButton.LoadContent(Content, _graphics); 
            _hourGlassButton.LoadContent(Content, _graphics);
            _crossedSwordsButton.LoadContent(Content, _graphics);
			
			foreach (var t in Characters)
			{
			    t.LoadContent(_spriteBatch);
			}
        }

        //////////////////////////////////////////
        //////////  MISE A JOUR DU JEU  //////////
        //////////////////////////////////////////

        protected override void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState();
            _mouseX = _mouseState.X;
            _mouseY = _mouseState.Y;
            _cursorPosition = new Vector2(_mouseX, _mouseY);

            // Survol du bouton de déplacement
            if (!_footPrintsButtonClicked)
            {
                if (_mouseX >= _footPrintsButton.Position.X && _mouseX < _footPrintsButton.Position.X +
                    _footPrintsButton.SpriteWidth && _mouseY >= _footPrintsButton.Position.Y && _mouseY <
                    _footPrintsButton.Position.Y + _footPrintsButton.SpriteHeight)
                {
                    _footPrintsButton.Sprite = _footPrintsButton.SpriteMouseOver;
                }
                else
                {
                    _footPrintsButton.Sprite = _footPrintsButton.SpriteMouseOut;
                }
            }

            // Survol du bouton de combat
            if (!_crossedSwordsButtonClicked)
            {
                if (_mouseX >= _crossedSwordsButton.Position.X && _mouseX < _crossedSwordsButton.Position.X +
                    _crossedSwordsButton.SpriteWidth && _mouseY >= _crossedSwordsButton.Position.Y && _mouseY <
                    _crossedSwordsButton.Position.Y + _crossedSwordsButton.SpriteHeight)
                {
                    _crossedSwordsButton.Sprite = _crossedSwordsButton.SpriteMouseOver;
                }
                else
                {
                    _crossedSwordsButton.Sprite = _crossedSwordsButton.SpriteMouseOut;
                }
            }
            // Survol des personnages ciblables
            else
            {
                if (!CharacterHasStriked)
                {
                    _crossedSwordsButton.MouseOverTargetableCharacters(_mouseX, _mouseY, _fightTilesSprite, _graphics, false);
                }
                else
                {
                    _crossedSwordsButton.MouseOverTargetableCharacters(_mouseX, _mouseY, _fightTilesSprite, _graphics, true);
                }
            }

            // Survol du bouton de fin de tour
            if (_mouseX >= _hourGlassButton.Position.X && _mouseX < _hourGlassButton.Position.X +
                    _hourGlassButton.SpriteWidth && _mouseY >= _hourGlassButton.Position.Y && _mouseY <
                    _hourGlassButton.Position.Y + _hourGlassButton.SpriteHeight)
            {
                _hourGlassButton.Sprite = _hourGlassButton.SpriteMouseOver;
            }
            else
            {
                _hourGlassButton.Sprite = _hourGlassButton.SpriteMouseOut;
            }

            /*..........CLIC..........*/
            
            if (_mouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
            {
                // Clic sur le bouton de déplacement
                if (_mouseX >= _footPrintsButton.Position.X && _mouseX < _footPrintsButton.Position.X +
                _footPrintsButton.SpriteWidth && _mouseY >= _footPrintsButton.Position.Y && _mouseY <
                _footPrintsButton.Position.Y + _footPrintsButton.SpriteHeight)
                {
                    if (_footPrintsButtonClicked)
                    {
                        _footPrintsButtonClicked = false;
                    }
                    else
                    {
                        _footPrintsButtonClicked = true;
                        _footPrintsButton.Sprite = _footPrintsButton.SpriteClicked;
                        _crossedSwordsButtonClicked = false;
                    }
                }

                // Clic sur le bouton de combat
                if (_mouseX >= _crossedSwordsButton.Position.X && _mouseX < _crossedSwordsButton.Position.X +
                _crossedSwordsButton.SpriteWidth && _mouseY >= _crossedSwordsButton.Position.Y && _mouseY <
                _crossedSwordsButton.Position.Y + _crossedSwordsButton.SpriteHeight)
                {
                    if (_crossedSwordsButtonClicked)
                    {
                        _crossedSwordsButtonClicked = false;
                    }
                    else
                    {
                        _crossedSwordsButtonClicked = true;
                        _crossedSwordsButton.Sprite = _crossedSwordsButton.SpriteClicked;
                        _crossedSwordsButton.CharactersTargetable(true);
                        _footPrintsButtonClicked = false;
                    }
                }

                // Clic sur le bouton de fin de tour
                if (_mouseX >= _hourGlassButton.Position.X && _mouseX < _hourGlassButton.Position.X +
                    _hourGlassButton.SpriteWidth && _mouseY >= _hourGlassButton.Position.Y && _mouseY <
                    _hourGlassButton.Position.Y + _hourGlassButton.SpriteHeight &&!Moving)
                {
                    _hourGlassButton.Sprite = _hourGlassButton.SpriteClicked;
                    _hourGlassButton.NextCharacter(_moveTileSprite, _fightTilesSprite, _crossedSwordsButton, _crossedSwordsButtonClicked);
                }

                // Déplacement d'un personnage
                if (_footPrintsButtonClicked && !Moving && !CharacterHasMoved)
                {
                    _charactersMoves.MoveOnClick(_mouseX, _mouseY, _graphics, _moveTileSprite);
                }

                // Clic sur un personnage attaquable
                if (_crossedSwordsButtonClicked && !Moving && !CharacterHasStriked)
                {
                    _crossedSwordsButton.ClicOnTargetableCharacter(_mouseX, _mouseY, _fightTilesSprite, _graphics);
                }
            }

            /*..........FIN CLIC..........*/

            _oldMouseState = _mouseState;

            // Mise en place des symboles désignant les tuiles disponibles au mouvement
            _moveTileSprite.CharacterWayPoints(Characters, Count, _graphics);

            // Mise en place des symboles désignant les tuiles disponibles au mouvement
            if (_crossedSwordsButtonClicked)
            {
                _fightTilesSprite.CharacterRangePoints(Characters, Count, _graphics);
            }

            // Fin du mouvement d'un personnage
            _charactersMoves.MoveEnds(_moveTileSprite, _fightTilesSprite);

            if (!_crossedSwordsButtonClicked)
            {
                _crossedSwordsButton.CharactersTargetable(false);
            }

            // Remet les personnages en Idle si l'animation le demandant est terminée
            foreach (var t in Characters)
            {
                _charactersMoves.BackToIdle(t);
                t.AnimationSprite.Update(gameTime);
            }

            base.Update(gameTime);
        }

        //////////////////////////////////////////
        //////////  DESSIN DES SPRITES  //////////
        //////////////////////////////////////////

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            _spriteBatch.Begin();

            _bfBgSprite.Draw(_spriteBatch, _graphics);
            _footPrintsButton.Draw(_spriteBatch);
            _hourGlassButton.Draw(_spriteBatch);
            _crossedSwordsButton.Draw(_spriteBatch);
            
            // Dessin des tuiles de mouvement si le personnage n'a pas bougé et n'est pas en mouvement
            if (!Moving && _footPrintsButtonClicked && !CharacterHasMoved)
            {
                _moveTileSprite.Draw(_spriteBatch, _graphics);
            }

            // Dessin des truiles de mouvement si le personnage n'a pas frappé et n'est pas en mouvement
            if (!CharacterHasStriked && !Moving && _crossedSwordsButtonClicked)
            {
                _fightTilesSprite.Draw(_spriteBatch, _graphics);
            }
            
            // Vide le tableau d'affichage des personnages, place les personnages dedans, les trie et les affiche
            _charactersOrderedByPosision.Clear();
            foreach (var character in Characters)
            {
                _charactersOrderedByPosision.Add(character);
            }
            _charactersOrderedByPosision = _charactersMoves.OrderCharactersAscending(_charactersOrderedByPosision, _graphics);
            foreach (var t in _charactersOrderedByPosision)
            {
                t.AnimationSprite.Draw(gameTime, false);
            }

            // Dessin de la souris
            _spriteBatch.Draw(CursorTexture, _cursorPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}