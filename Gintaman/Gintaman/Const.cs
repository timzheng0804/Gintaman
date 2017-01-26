using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Gintaman
{
    class Const
    {
        public static int screenWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
        public static int screenHeight = GraphicsDeviceManager.DefaultBackBufferHeight;
        public static int mapWidth = 992 - screenWidth - 5;
        public static int mapHeight = 1088 - screenHeight;
        public static int tile_size = 32;
        public static int map_x_tiles = 31;
        public static int map_y_tiles = 34;
        public static float characterSpeed = 2.7f;
        public static float hypeSpeed = 4.0f;
        public static Vector2 origin = new Vector2(0, 0);
        public static Rectangle upperBound = new Rectangle(0, 0, 970, 5);
        public static Rectangle lowerBound = new Rectangle(0, 1070, 970, 5);
        public static Rectangle leftBound = new Rectangle(0, 0, 5, 1088);
        public static Rectangle rightBound = new Rectangle(960, 0, 5, 1088);
        public static int frameCount = 4;
        public static int frameTime = 140;
        public static int characterWidth = 17;
        public static int characterHeight = 40;
        public static int hypeTime = 7000;
        public static Vector2 ginsanBornPos = new Vector2(490, 790);
        public static Vector2 shinsenBornPos = new Vector2(480, 480);
        public static int deathTimer = 1000;

        #region wall Array
        public static List<List<int>> wallPos = new List<List<int>>()
        {
            new List<int>() { },
            new List<int>() { },
            new List<int>() { 2, 5, 6, 7, 8, 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23 ,27 },
            new List<int>() { 2, 5, 6, 7, 8, 11, 18, 21, 22, 23, 27 },
            new List<int>() { 2, 11, 18, 27 },
            new List<int>() { 2, 11, 15, 18,27 },
            new List<int>() { 2, 3 , 4, 8, 11, 15, 18, 21, 25, 26, 27 },
            new List<int>() { 8, 15,21 },
            new List<int>() { 8, 15, 21 },
            new List<int>() { 8, 15, 21 },
            new List<int>() { 0, 1, 4, 5,6,7,8,9,10,11, 18,19, 20,21,22,23,24,25,28,29 },
            new List<int>() { 0, 1,8, 21, 28, 29 },
            new List<int>() { 0, 1,8, 21, 28, 29 },
            new List<int>() { 4, 8, 21,25 },
            new List<int>() { 4, 25 },
            new List<int>() { 0,1,2,3,4,25,26,27,28,29 },
            new List<int>() { 4,8, 25 },
            new List<int>() { 4,8, 21, 25 },
            new List<int>() { 0,1,8,21, 28,29 },
            new List<int>() { 0, 1, 8, 21, 28, 29},
            new List<int>() { 0,1,8,9,10,11, 15, 18,19, 20, 21, 28,29 },
            new List<int>() { 0,1,4,15, 25,28,29 },
            new List<int>() { 0,1,4,15, 25,28,29 },
            new List<int>() { 0,1,4,5,6,7, 8, 11, 15, 18, 21,22,23,24,25, 28,29 },
            new List<int>() { 11,18 },
            new List<int>() { 11,18 },
            new List<int>() { 11,12,13,14,15,16, 17 ,18},
            new List<int>() { 2, 3, 4, 8, 11,12,13,14,15,16, 17, 18, 21, 25, 26, 27 },
            new List<int>() { 2,8, 21, 27 },
            new List<int>() { 2, 8, 21, 27},
            new List<int>() { 2, 6,7,8,9,10, 11, 14, 15, 18,19, 20, 21,22,23, 27 },
            new List<int>() { 14, 15 },
            new List<int>() { 14, 15 }
        };
        #endregion

        #region item Array

        public static List<List<int>> itemPos = new List<List<int>>
        {
            new List<int>() {  },
            new List<int>() { 1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            new List<int>() { 1,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,1,1,1,0,0,1,1,1,1,0,2,1,0},
            new List<int>() { 1,0,0,1,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,0,1,1,0},
            new List<int>() { 1,0,0,1,0,1,1,1,1,1,0,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,0},
            new List<int>() { 1,0,1,1,0,0,0,0,0,0,0,1,1,0,1,1,1,0,1,1,0,0,0,0,0,0,0,1,1,0},
            new List<int>() { 1,0,0,0,0,1,0,1,1,1,0,1,1,0,1,0,1,0,1,1,0,1,1,1,2,1,1,1,1,0},
            new List<int>() { 1,0,1,1,1,1,0,1,1,1,0,1,1,0,1,0,1,0,1,1,0,1,1,1,0,1,1,1,1,0},
            new List<int>() { 1,0,1,1,1,1,0,1,1,1,0,1,1,0,1,1,1,0,1,1,0,1,1,1,0,1,1,1,1,0},
            new List<int>() { 1,0,0,0,0,0,0,1,1,1,0,0,0,0,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0,0},
            new List<int>() { 1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0},
            new List<int>() { 1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0},
            new List<int>() { 1,1,1,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1},
            new List<int>() { 1,1,1,0,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,0},
            new List<int>() { 1,1,1,0,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,0},
            new List<int>() { 1,1,1,2,1,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1 },
            new List<int>() { 1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1 },
            new List<int>() { 1,1,1,0,1,1,0,1,2,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1 },
            new List<int>() { 1,1,1,0,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,0 },
            new List<int>() { 1,1,1,0,1,1,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,1,1,0 },
            new List<int>() { 1,1,1,0,0,0,0,1,1,1,1,1,1,0,1,0,1,0,1,0,1,1,1,1,2,0,0,0 },
            new List<int>() { 1,1,1,0,1,1,0,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,0,1,1,0},
            new List<int>() { 1,1,1,0,0,1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,1,0 },
            new List<int>() { 1,1,1,0,1,1,1,1,1,1,0,1,1,0,1,1,1,0,1,1,0,1,0,1,1,1,1,0 },
            new List<int>() { 1,1,1,0,1,1,1,1,1,1,0,1,1,0,1,1,1,0,1,1,0,1,1,1,1,1,1,0 },
            new List<int>() { 1,1,1,0,1,1,1,1,1,1,0,1,1,0,1,1,1,0,1,1,0,1,1,1,1,1,1,0,1,0},
            new List<int>() { 1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0},
            new List<int>() { 1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0},
            new List<int>() { 1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0},
            new List<int>() { 1,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,0},
            new List<int>() { 1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0},
            new List<int>() { 1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0},
            new List<int>() { 1,2,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };
        #endregion
    }
}
