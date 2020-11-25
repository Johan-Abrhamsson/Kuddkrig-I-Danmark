using System;
using Raylib_cs;

namespace Kuddkrig
{
    class Program
    {

        public enum mapSelect
        {
            map1
        }

        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "");

            int mapTarget = 0;
            int mapDisplay = 1;
            char[] mapo = { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', '_', '_', '_', '_', '_', '_', '_', '_', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' };
            while (!Raylib.WindowShouldClose())
            {
                mapSelect map = mapSelect.map1;
                if (mapTarget != 1)
                {
                    mapDisplay++;
                    switch (mapDisplay)
                    {
                        case 1:
                            map = mapSelect.map1;
                            break;
                        case 2:
                            //map = mapSelect.map2;
                            break;


                    }
                }
                Raylib.BeginDrawing();


                Raylib.ClearBackground(Color.WHITE);

                for (int i = 0; i < 30; i++)
                {
                    int K = 1;
                    int secY = 10;
                    int secX = 0;
                    switch (K)
                    {
                        case 1:
                            secX = i * 10;
                            break;
                        case 2:
                            secX = i * 10 - 10;
                            break;
                        case 3:
                            secX = i * 10 - 20;
                            break;
                    }
                    if (i > 10 * K)
                    {
                        K++;
                        secY = secY + 10;
                        secX = 10;
                    }


                    if (mapo[i] == 'B')
                    {
                        Raylib.DrawRectangle(secX, secY, 10, 10, Color.BLACK);
                    }
                    else
                    {

                    }
                }

                Raylib.EndDrawing();
            }
        }
    }
}
