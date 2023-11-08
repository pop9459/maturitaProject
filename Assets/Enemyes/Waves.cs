using System.Collections.Generic;
using UnityEngine;
internal class Waves : MonoBehaviour {
    public static List<Wave> waves = new List<Wave> {
        //new Wave(0.1f, new float[,] { { 10, 10}, }), //test waves
        //new Wave(0.25f, new float[,] { { 1, 200 } }), //moab

        //r1 b2 g3 y4 p5 b6 w7 p7
        new Wave(1f, new float[,] { { 20, 1}, }),
        new Wave(0.5f, new float[,] { { 35, 1}, }),
        new Wave(0.5f, new float[,] { { 25, 1 }, {5, 2 }, }),
        new Wave(0.5f, new float[,] { { 35, 1 }, {18, 2 }, }),
        new Wave(0.5f, new float[,] { { 5, 1 }, {27, 2 }, }),

        new Wave(0.5f, new float[,] { { 15, 1 }, {15, 2 }, { 4, 3} }),
        new Wave(0.5f, new float[,] { { 20, 1 }, {20, 2 }, { 5, 3} }),
        new Wave(0.5f, new float[,] { { 10, 1 }, {10, 2 }, { 14, 3} }),
        new Wave(0.5f, new float[,] { { 30, 3} }),
        new Wave(0.1f, new float[,] { { 102, 2} }),

        new Wave(0.5f, new float[,] { { 10, 1 }, {10, 2 }, { 12, 3}, { 3, 4} }),
        new Wave(0.5f, new float[,] { { 15, 2 }, {10, 3 }, { 5, 4} }),
        new Wave(0.25f, new float[,] { { 50, 2 }, {23, 3 } }),
        new Wave(0.5f, new float[,] { { 49, 1 }, {15, 2 }, {10, 3 }, {9, 4 } }),
        new Wave(0.5f, new float[,] { { 20, 1 }, {15, 2 }, {12, 3 }, {10, 4 }, {5, 5 } }),

        new Wave(0.25f, new float[,] { {40, 3 }, {8, 4 } }),
        new Wave(0.25f, new float[,] { {24, 4 } }),
        new Wave(0.25f, new float[,] { {80, 3 } }),
        new Wave(0.5f, new float[,] { { 10, 3 }, {20, 4 }, {15, 5 } }),
        new Wave(1f, new float[,] { { 6, 6 }, }),

        new Wave(0.25f, new float[,] { { 40, 4 }, {14, 5 } }),
        new Wave(0.35f, new float[,] { { 16, 7 } }),
        new Wave(0.35f, new float[,] { { 7, 6 }, {7, 7 } }),
        new Wave(0.5f, new float[,] { { 20, 2 }, {1, 8}}),
        new Wave(0.25f, new float[,] { { 35, 4}, { 10, 8} }), //25
        
        //r1 b2 g3 y4 p5 b6 w7 p8 z9 l10 r11 b12
        new Wave(0.5f, new float[,] { { 23, 8}, { 4, 9 } }),
        new Wave(0.1f, new float[,] { { 100, 1}, {60, 2 }, { 45, 3}, { 45, 4} }),
        new Wave(0.5f, new float[,] { { 6, 10}, }),
        new Wave(0.1f, new float[,] { { 100, 4}, }),
        new Wave(0.25f, new float[,] { { 10, 10}, }),

        new Wave(0.25f, new float[,] { { 8, 6}, { 8, 7}, { 12, 9} }),
        new Wave(0.25f, new float[,] { { 12, 6}, { 20, 7}, { 10, 8} , }),
        new Wave(0.05f, new float[,] { { 50, 1}, { 20, 4} }),
        new Wave(0.1f, new float[,] { { 160, 4 }, { 6, 9} }),
        new Wave(0.25f, new float[,] { { 35, 5}, { 30, 6}, { 35, 7}, { 5, 11}, }),

        new Wave(0.1f, new float[,] { { 140, 5 }, { 40, 3} }),
        new Wave(0.5f, new float[,] { { 25, 6 }, { 35, 7}, { 10, 9 }, { 25, 6 }, { 15,10 }, }),
        new Wave(0.5f, new float[,] { { 42, 5 }, { 17, 7}, { 10, 9 }, { 14, 10 }, { 2, 12 },  }),
        new Wave(0.3f, new float[,] { { 10, 6 }, { 10, 7}, { 20, 9 }, { 25, 11} }),
        new Wave(0.25f, new float[,] { { 1, 200 } }), //moab
    };
}

