using System;
using Raylib_cs;

namespace Kuddkrig
{
    class Program
    {
        public class player
        {
            float playerY = 0;
            float playerX = 0;
        }
        public class block
        {
            int blockid = 0;
            int blockX = 0;
            int blockY = 0;
        }
        public class enemy
        {
            float eY = 0;
            float eX = 0;
        }

        public enum mapSelect
        {
            map0,
            map1,
            map2,
            map3
        }

        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "");

            int mapTarget = 0;
            int mapDisplay = 1;
            char[,] mapP1 = {
                {'B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ','E',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','E',' ',' ','B',' ',' ','B'},
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
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ','E',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B'},
                };
            char[,] mapP2 = {
                {'B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B'},
                {'B','P',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ','B',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ','B',' ','B',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ','E',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ','E','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B','E',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B',' ',' ',' ',' ',' ','B',' ',' ',' ',' ',' ',' ',' ',' ',' ','B',' ',' ','B'},
                {'B',' ',' ',' ',' ','B','B','B',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','B'},
                {'B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B','B'},
                };

            //Ska jag värkligen göra en raycasting och inte bara top down?
            float playerY = 5;
            float playerX = 5;
            int mapScale = 10;
            float screenWidth = 800;
            float screenHeight = 600;
            //ska användas för distans.
            // float edX = eX - playerX;
            // float edY = eY - playerY;
            // float ed = rt(edX * edX + edY * edY);

            float[,] playerPos = {
            { playerY},
            { playerX},
            };
            float playerXSpeed = 0f;
            float playerYSpeed = 0f;
            float playerSpeedIncr = 0.0001f;
            float playerSpeedDecr = 0.0001f;
            bool playerLock = false;
            int playerStill = 0;
            mapSelect map = mapSelect.map0;
            while (!Raylib.WindowShouldClose())
            {
                //Map selector
                if (mapTarget == 0)
                {
                    switch (mapDisplay)
                    {
                        case 1:
                            map = mapSelect.map1;

                            break;
                        case 2:
                            map = mapSelect.map2;
                            break;
                        default:
                            Raylib.DrawText("Text Not found.", 200, 100, 50, Color.RED);
                            break;
                    }
                    mapDisplay++;
                    mapTarget = 1;
                }
                //Drawing begins
                Raylib.BeginDrawing();


                Raylib.ClearBackground(Color.WHITE);

                int offsetX = 50;
                int offsetY = 50;

                //map writeing
                for (int y = 0; y < mapP1.GetLength(0); y++)
                {
                    for (int x = 0; x < mapP1.GetLength(1); x++)
                    {
                        if (map == mapSelect.map1)
                        {
                            //Blocks
                            if (mapP1[y, x] == 'B')
                            {
                                block B1 = new block();

                                Raylib.DrawRectangle(offsetX + x * mapScale, offsetY + y * mapScale, 10, 10, Color.BLACK);
                            }
                            //Player
                            else if (mapP1[y, x] == 'P')
                            {
                                if (playerLock == false)
                                {
                                    playerY = offsetY + y * mapScale;
                                    playerX = offsetX + x * mapScale;
                                }
                                playerLock = true;
                                Raylib.DrawCircle((int)playerX + 2, (int)playerY + 2, 3, Color.RED);
                            }
                            //Enemy
                            else if (mapP1[y, x] == 'E')
                            {
                                Raylib.DrawCircle(offsetX + x * mapScale, offsetY + y * mapScale, 3, Color.YELLOW);
                            }
                            else
                            {

                            }
                        }
                        else if (map == mapSelect.map2)
                        {
                            //Blocks
                            if (mapP2[y, x] == 'B')
                            {
                                Raylib.DrawRectangle(offsetX + x * mapScale, offsetY + y * mapScale, 10, 10, Color.BLACK);
                            }
                            //Player
                            else if (mapP2[y, x] == 'P')
                            {
                                if (playerLock == false)
                                {
                                    playerY = offsetY + y * mapScale;
                                    playerX = offsetX + x * mapScale;
                                }
                                playerLock = true;
                                Raylib.DrawCircle((int)playerX + 3, (int)playerY + 3, 3, Color.RED);
                            }
                            //Enemy
                            else if (mapP2[y, x] == 'E')
                            {
                                Raylib.DrawCircle(offsetX + x * mapScale + 3, offsetY + y * mapScale + 3, 3, Color.YELLOW);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            Raylib.DrawText("Map Not found.", 200, 200, 50, Color.RED);
                        }
                    }
                }


                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    playerStill = 0;
                    playerX = playerX + playerXSpeed;
                    if (playerXSpeed > -0.05)
                    {
                        playerXSpeed = playerXSpeed - playerSpeedIncr;
                    }

                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    playerStill = 0;
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
                        playerStill++;
                        playerX = playerX + playerXSpeed;
                        playerXSpeed = playerXSpeed - playerSpeedDecr;
                        if (playerStill > 1000)
                        {
                            playerXSpeed = 0;
                        }
                    }
                    if (playerXSpeed < 0)
                    {
                        playerStill++;
                        playerX = playerX + playerXSpeed;
                        playerXSpeed = playerXSpeed + playerSpeedDecr;
                        if (playerStill > 1000)
                        {
                            playerXSpeed = 0;
                        }
                    }
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    playerStill = 0;
                    playerY = playerY + playerYSpeed;
                    if (playerYSpeed < 0.05)
                    {
                        playerYSpeed = playerYSpeed + playerSpeedIncr;
                    }

                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    playerStill = 0;
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
                        playerStill++;
                        playerY = playerY + playerYSpeed;
                        playerYSpeed = playerYSpeed - playerSpeedDecr;
                        if (playerStill > 1000)
                        {
                            playerYSpeed = 0;
                        }

                    }
                    if (playerYSpeed < 0)
                    {
                        playerStill++;
                        playerY = playerY + playerYSpeed;
                        playerYSpeed = playerYSpeed + playerSpeedDecr;
                        if (playerStill > 1000)
                        {
                            playerYSpeed = 0;
                        }
                    }
                }
                //Sjukta
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    shoot(0, -2, playerX + 3, playerY + 3, "up");
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    shoot(0, 2, playerX + 3, playerY + 3, "down");
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    shoot(2, 0, playerX + 3, playerY + 3, "right");
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    shoot(-2, 0, playerX + 3, playerY + 3, "left");
                }

                //Reload
                if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
                {
                    mapTarget = 0;
                    playerLock = false;
                    playerXSpeed = 0;
                    playerYSpeed = 0;
                    playerX = 0;
                    playerY = 0;
                }


                Raylib.EndDrawing();
            }
        }
        static void shoot(float Speedx, float Speedy, float Xknow, float Yknow, string direction)
        {
            if (direction == "up")
            {
                Xknow = Xknow + Speedx;
                Yknow = Yknow - 6 + Speedy;
            }
            else if (direction == "down")
            {
                Xknow = Xknow + Speedx;
                Yknow = Yknow + 6 + Speedy;
            }
            else if (direction == "right")
            {
                Xknow = Xknow + 6 + Speedx;
                Yknow = Yknow + Speedy;
            }
            else if (direction == "left")
            {
                Xknow = Xknow - 6 + Speedx;
                Yknow = Yknow + Speedy;
            }
            Raylib.DrawCircle((int)Xknow, (int)Yknow, 1, Color.ORANGE);
            Xknow = Xknow + Speedx;
            Yknow = Yknow + Speedy;

        }
    }
}