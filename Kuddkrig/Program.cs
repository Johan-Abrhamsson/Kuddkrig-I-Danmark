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
            char[,] mapp = {
                {'B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ','P',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B'},
                };
            float playerY = 0;
            float playerX = 0;
            float playerXSpeed = 0.1f;
            float playerYSpeed = 0.1f;
            int playerLock = 0;
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
                int mapScale = 10;

                int offsetX = 50;
                int offsetY = 50;


                for (int y = 0; y < mapp.GetLength(0); y++)
                {
                    for (int x = 0; x < mapp.GetLength(1); x++)
                    {
                        if (mapp[y, x] == 'B')
                        {
                            Raylib.DrawRectangle(offsetX + x * mapScale, offsetY + y * mapScale, 10, 10, Color.BLACK);
                        }
                        else if (mapp[y, x] == 'P')
                        {
                            if (playerLock == 0)
                            {
                                playerY = offsetY + y * mapScale;
                                playerX = offsetX + x * mapScale;
                            }
                            playerLock = 1;
                            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                            {
                                if (playerXSpeed < 1.05f)
                                {
                                    playerXSpeed = playerXSpeed * (1.01f);
                                    playerX = playerX - playerXSpeed;
                                }
                                else
                                {
                                    playerX = playerX - playerXSpeed;
                                }
                            }
                            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                            {
                                if (playerXSpeed < 1.05f)
                                {
                                    playerXSpeed = playerXSpeed * 1.01f;
                                    playerX = playerX + playerXSpeed;
                                }
                                else
                                {
                                    playerX = playerX + playerXSpeed;
                                }
                            }
                            Raylib.DrawRectangle((int)playerX + 2, (int)playerY + 2, 6, 6, Color.RED);
                        }
                        else
                        {

                        }
                    }
                }


                Raylib.EndDrawing();
            }
        }
    }
}
