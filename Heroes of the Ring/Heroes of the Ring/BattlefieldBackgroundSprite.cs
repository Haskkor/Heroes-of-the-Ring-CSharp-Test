using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Heroes_of_the_Ring
{
    class BattlefieldBackgroundSprite
    {
        public const int BlockWidth = 50;
        public const int BlockHeight = 40;
        public string AssetName;  
        public Vector2 Position = new Vector2(0,0);

        readonly byte[,] _bfBgMap =
        {  
            {2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},  
            {2,2,2,2,2,2,2,8,6,6,6,4,2,1,1,1},  
            {2,2,2,2,2,2,2,9,13,19,17,5,2,1,1,1},  
            {2,2,2,2,2,2,2,9,14,11,18,5,2,1,1,1},  
            {2,2,2,2,2,2,2,9,12,15,16,5,2,1,1,1},
            {2,2,2,2,2,2,2,7,10,10,10,3,2,1,1,1},
            {2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},  
            {6,4,2,2,2,2,2,2,2,2,2,2,2,1,1,1},  
            {0,5,2,2,2,2,2,2,2,2,2,2,2,1,1,1},  
            {0,5,2,2,2,2,2,2,2,2,2,2,2,1,1,1},  
            {0,5,2,2,2,2,2,2,2,2,2,2,2,1,1,1},  
            {0,5,2,2,2,2,2,2,2,2,2,2,2,1,1,1}
        };

        readonly Texture2D[] _t2DTiles = new Texture2D[20];

        public Texture2D Texture { get; set; }

        public void LoadContent(ContentManager theContentManager, string theAssetName)  
        {  
            Texture = theContentManager.Load<Texture2D>(theAssetName); 
            AssetName = theAssetName;
            _t2DTiles[0] = theContentManager.Load<Texture2D>("DirtBlock");
            _t2DTiles[1] = theContentManager.Load<Texture2D>("StoneBlock");
            _t2DTiles[2] = theContentManager.Load<Texture2D>("GrassBlock");
            _t2DTiles[3] = theContentManager.Load<Texture2D>("Dirt_Grass_D_BBlock");
            _t2DTiles[4] = theContentManager.Load<Texture2D>("Dirt_Grass_D_HBlock");
            _t2DTiles[5] = theContentManager.Load<Texture2D>("Dirt_Grass_HBlock");
            _t2DTiles[6] = theContentManager.Load<Texture2D>("Dirt_Grass_VBlock");
            _t2DTiles[7] = theContentManager.Load<Texture2D>("Grass_Dirt_D_BBlock");
            _t2DTiles[8] = theContentManager.Load<Texture2D>("Grass_Dirt_D_HBlock");
            _t2DTiles[9] = theContentManager.Load<Texture2D>("Grass_Dirt_HBlock");
            _t2DTiles[10] = theContentManager.Load<Texture2D>("Grass_Dirt_VBlock");
            _t2DTiles[11] = theContentManager.Load<Texture2D>("WaterBlock");
            _t2DTiles[12] = theContentManager.Load<Texture2D>("Dirt_Water_D_BBlock");
            _t2DTiles[13] = theContentManager.Load<Texture2D>("Dirt_Water_D_HBlock");
            _t2DTiles[14] = theContentManager.Load<Texture2D>("Dirt_Water_HBlock");
            _t2DTiles[15] = theContentManager.Load<Texture2D>("Dirt_Water_VBlock");
            _t2DTiles[16] = theContentManager.Load<Texture2D>("Water_Dirt_D_BBlock");
            _t2DTiles[17] = theContentManager.Load<Texture2D>("Water_Dirt_D_HBlock");
            _t2DTiles[18] = theContentManager.Load<Texture2D>("Water_Dirt_HBlock");
            _t2DTiles[19] = theContentManager.Load<Texture2D>("Water_Dirt_VBlock"); 
        }  
 
 
        public void Draw(SpriteBatch theSpriteBatch, GraphicsDeviceManager graphics)  
        {
            theSpriteBatch.Draw(Texture, new Vector2(0, 0), Color.White);
            for (var x = 0; x < _bfBgMap.GetLength(1); x++)  
            {  
                for (var y = 0; y < _bfBgMap.GetLength(0); y++)
                {
                    // ReSharper disable PossibleLossOfFraction
                    var pos = new Vector2(0, (graphics.PreferredBackBufferHeight - BlockHeight * 12 - 20) / 2);
                    // ReSharper restore PossibleLossOfFraction
                    switch (_bfBgMap[y, x])
                    {
                        case 1:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 1);
                            break;
                        case 2:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 5);
                            break;
                        case 3:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 5);
                            break;
                        case 4:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 5);
                            break;
                        case 6:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 5);
                            break;
                        case 7:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 5);
                            break;
                        case 8:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight - 5);
                            break;
                        default:
                            pos += new Vector2(x * BlockWidth, y * BlockHeight);
                            break;
                    }
                    theSpriteBatch.Draw(_t2DTiles[_bfBgMap[y, x]], pos, Color.White);
                }
            }    
        }
    }
}
