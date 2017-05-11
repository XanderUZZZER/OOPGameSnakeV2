using System;
using System.Collections.Generic;
using System.Linq;
using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Snake : IGameObject
    {
        public List<Cell> body = new List<Cell>();            //default snake body consists of 3 cells   
        private int xStart;                                     //available top left coords
        private int yStart;
        private int xEnd;                                       //available bottom right coords
        private int yEnd;
        private Direction direction = Direction.Up;
        private Direction prohibitedDirection = Direction.Down; //snake can't move back
        private Color color = Color.Black;
        public int FoodEated { get; private set; }
        public bool CanMove { get; private set; } = false;
        public bool IsHit { get; private set; }                 //flag indicates, that snake hits itself

        public Snake(int xStart, int yStart, int xEnd, int yEnd)
        {
            this.xStart = xStart;
            this.yStart = yStart;
            this.xEnd = xEnd + xStart;
            this.yEnd = yEnd + yStart;

            CreateNewSnake();
        }

        public void CreateNewSnake()
        {           
            body.Add(new Cell((xEnd - xStart) / 2 + xStart, (yEnd - yStart) / 2 + yStart, color));                    //snake start position, from the center
            body.Add(new Cell((xEnd - xStart) / 2 + xStart, (yEnd - yStart) / 2 + Cell.Size + yStart, color));
            body.Add(new Cell((xEnd - xStart) / 2 + xStart, (yEnd - yStart) / 2 + Cell.Size * 2 + yStart, color));
            FoodEated = 0;
            IsHit = false;            
        }

        public void Initialize(GameEngine engine)
        {
            foreach (Cell c in body)
            {
                engine.AddObject(c);
            }
        }

        public void Move()
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                //body.Last().Color = Color.ForegroundColor;
                //body[i] = body[i - 1];
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            switch (direction)
            {
                
                case Direction.Up:
                    {
                        if (body.First().Y != yStart)
                        {                            
                            body.First().X = body.First().X;
                            body.First().Y = body.First().Y - Cell.Size;
                            //body.First().X = body.First().X;
                            //body.First().Y = body.First().Y - Cell.Size;
                            //body.Insert(0, new Cell(body.First().X, body.First().Y - Cell.Size, color));
                        }
                        else
                        {
                            body.First().X = body.First().X;
                            body.First().Y = yEnd - Cell.Size;
                            //body.Last().X = body.First().X;
                            //body.Last().Y = yEnd - Cell.Size;
                            //body.Insert(0, new Cell(body.First().X, yEnd - Cell.Size, color));
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (body.First().X != xEnd - Cell.Size)
                        {
                            body.First().X = body.First().X + Cell.Size;
                            body.First().Y = body.First().Y;
                            //body.Last().X = body.First().X + Cell.Size;
                            //body.Last().Y = body.First().Y;
                            //body.Insert(0, new Cell(body.First().X + Cell.Size, body.First().Y, color));
                        }
                        else
                        {
                            body.First().X = xStart;
                            body.First().Y = body.First().Y;
                            //body.Last().X = xStart;
                            //body.Last().Y = body.First().Y;
                            //body.Insert(0, new Cell(xStart, body.First().Y, color));
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (body.First().Y != yEnd - Cell.Size)
                        {
                            body.First().X = body.First().X;
                            body.First().Y = body.First().Y + Cell.Size;
                            //body.Last().X = body.First().X;
                            //body.Last().Y = body.First().Y + Cell.Size;
                            //body.Insert(0, new Cell(body.First().X, body.First().Y + Cell.Size, color));
                        }
                        else
                        {
                            body.First().X = body.First().X;
                            body.First().Y = yStart;
                            //body.Last().X = body.First().X;
                            //body.Last().Y = yStart;
                            //body.Insert(0, new Cell(body.First().X, yStart, color));
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        if (body.First().X != xStart)
                        {
                            body.First().X = body.First().X - Cell.Size;
                            body.First().Y = body.First().Y;
                            //body.Last().X = body.First().X - Cell.Size;
                            //body.Last().Y = body.First().Y;
                            //body.Insert(0, new Cell(body.First().X - Cell.Size, body.First().Y, color));
                        }
                        else
                        {
                            body.First().X = xEnd - Cell.Size;
                            body.First().Y = body.First().Y;
                            //body.Last().X = xEnd - Cell.Size;
                            //body.Last().Y = body.First().Y;
                            //body.Insert(0, new Cell(xEnd - Cell.Size, body.First().Y, color));
                        }
                        break;
                    }
            }
        }

        public void Eat(Food food)
        {
            if ((body.First().X == food.X) && (body.First().Y == food.Y))
            {
                body.Insert(0, new Cell(food.X, food.Y, color));
                FoodEated++;
                food.CanCreateNext = true;
                do
                {
                    food.CreateNext();
                    foreach (var c in body)
                    {
                        if (food.X == c.X && food.Y == c.Y)
                        {
                            food.CanCreateNext = true;          // food can't appear on the snake body
                            break;
                        }
                    }
                } while (food.CanCreateNext);
            }
        }

        public void HitItself()
        {
            var head = body[0];
            for (int i = 3; i < body.Count(); i++)
            {
                if (head.X == body[i].X && head.Y == body[i].Y)
                {
                    IsHit = true;
                    CanMove = false;
                    break;
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {            
        }

        public void Update(GameEngine engine)
        {
            
            if (CanMove)
            {
                Move();
                //HitItself();
            }
            if (Input.IsKeyDown(Keys.UP) && (prohibitedDirection != Direction.Up))
            {
                direction = Direction.Up;
                prohibitedDirection = Direction.Down;
            }
            if (Input.IsKeyDown(Keys.RIGHT) && (prohibitedDirection != Direction.Right))
            {
                direction = Direction.Right;
                prohibitedDirection = Direction.Left;
            }
            if (Input.IsKeyDown(Keys.DOWN) && (prohibitedDirection != Direction.Down))
            {
                direction = Direction.Down;
                prohibitedDirection = Direction.Up;
            }
            if (Input.IsKeyDown(Keys.LEFT) && (prohibitedDirection != Direction.Left))
            {
                direction = Direction.Left;
                prohibitedDirection = Direction.Right;
            }
            if (Input.IsKeyDown(Keys.SPACE))
            {
                CanMove = true;
            }
            if (Input.IsKeyDown(Keys.ESCAPE))
            {
                CanMove = false;
            }
        }
    }
}
