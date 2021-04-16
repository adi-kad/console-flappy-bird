﻿using System;
using System.Linq;
using System.Collections;
namespace FlappyBird
{
    class Board : Game
    {
        int height;
        private int width = Console.WindowWidth;
        public Board()
        {
            this.height = 25;
        }

        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Draw(Bird bird)
        {
            bird.DrawBird();
        }

        public void Draw(Obstacle[] obstacles)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                for (int j = 1; j <= height ; j++)
                {
                    if (obstacles[i].xpos == 5)
                    {
                        Random rnd = new Random();
                        obstacles[i].height = rnd.Next(0, 23);
                        obstacles[i].xpos = Console.WindowWidth - 4;
                        obstacles[i].obsFloor = obstacles[i].height + obstacles[i].gate;
                    }
                    
                    else
                    {
                        if (j < obstacles[i].height | j >= obstacles[i].obsFloor)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(obstacles[i].xpos, j);
                            Console.Write(String.Concat(Enumerable.Repeat(" ", 4 /*obstacles[i].width*/ /*width*/)));
                            
                        }
                    }

                }
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void DrawBoard(int score)
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("_");
            }

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, height);
                Console.Write("_");
            }
            Console.SetCursorPosition(width/2 - 10 , height + 2);
            Console.WriteLine($"Score: {score}");
        }

    }
}
