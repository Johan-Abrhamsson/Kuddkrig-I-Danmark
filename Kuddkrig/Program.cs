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
            float[,] playerPos = {
            { playerY},
            { playerX},
        };
            float playerXSpeed = 0f;
            float playerYSpeed = 0f;
            float playerSpeedIncr = 0.0001f;
            float playerSpeedDecr = 0.0001f;
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
                            Raylib.DrawRectangle((int)playerX + 2, (int)playerY + 2, 6, 6, Color.RED);
                        }
                        else
                        {

                        }
                    }
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    playerX = playerX + playerXSpeed;
                    if (playerXSpeed > -0.05)
                    {
                        playerXSpeed = playerXSpeed - playerSpeedIncr;
                    }

                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    playerX = playerX + playerXSpeed;
                    if (playerXSpeed < 0.05)
                    {
                        playerXSpeed = playerXSpeed + playerSpeedIncr;
                    }

                }
                else
                {
                    if (playerXSpeed > 0)
                    {
                        playerX = playerX + playerXSpeed;
                        playerXSpeed = playerXSpeed - playerSpeedDecr;
                    }
                    if (playerXSpeed < 0)
                    {
                        playerX = playerX + playerXSpeed;
                        playerXSpeed = playerXSpeed + playerSpeedDecr;
                    }
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    playerY = playerY + playerYSpeed;
                    if (playerYSpeed < 0.05)
                    {
                        playerYSpeed = playerYSpeed + playerSpeedIncr;
                    }

                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    playerY = playerY + playerYSpeed;
                    if (playerYSpeed > -0.05)
                    {
                        playerYSpeed = playerYSpeed - playerSpeedIncr;
                    }
                }
                else
                {
                    if (playerYSpeed > 0)
                    {
                        playerY = playerY + playerYSpeed;
                        playerYSpeed = playerYSpeed - playerSpeedDecr;
                    }
                    if (playerYSpeed < 0)
                    {
                        playerY = playerY + playerYSpeed;
                        playerYSpeed = playerYSpeed + playerSpeedDecr;
                    }
                }
                Raylib.DrawText(playerSpeedIncr.ToString(), 600, 400, 30, Color.RED);
                Raylib.DrawText(playerSpeedDecr.ToString(), 600, 500, 30, Color.RED);
                Raylib.DrawText(playerXSpeed.ToString(), 300, 400, 30, Color.GREEN);
                Raylib.DrawText(playerYSpeed.ToString(), 300, 500, 30, Color.GREEN);
                Raylib.DrawText(playerX.ToString(), 0, 400, 50, Color.BLACK);
                Raylib.DrawText(playerY.ToString(), 0, 500, 50, Color.BLACK);


                Raylib.EndDrawing();
            }
        }
    }
}
