using System.Collections.Generic;
using System.Linq;
using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Snake : IGameObject
    {
        private List<Cell> body = new List<Cell>(3);
        private int xStart;                                     //available top left coords
        private int yStart;
        private int xEnd;                                       //available bottom right coords
        private int yEnd;
        private Direction direction = Direction.Up;
        private Direction prohibitedDirection = Direction.Down; //snake can't move back
        private Color color = Color.Black;
        private bool canMove = false;
        public int FoodEated = 0;

        public Snake(int xStart, int yStart, int xEnd, int yEnd)
        {
            this.xStart = xStart;
            this.yStart = yStart;
            this.xEnd = xEnd + xStart;
            this.yEnd = yEnd + yStart;
            
            body.Add(new Cell(xEnd / 2 + xStart, yEnd / 2 + yStart, color));                    //snake start position, from the center
            body.Add(new Cell(xEnd / 2 + xStart, yEnd / 2 + Cell.Size + yStart, color));
            body.Add(new Cell(xEnd / 2 + xStart, yEnd / 2 + Cell.Size * 2 + yStart, color));
        }

        public void Move()
        {
            switch (direction)
            {
                case Direction.Up:
                {
                    if (body.First().Y != yStart)
                    {
                        body.Insert(0, new Cell(body.First().X, body.First().Y - Cell.Size, color));
                    }
                    else
                    {
                        body.Insert(0, new Cell(body.First().X, yEnd - Cell.Size, color));
                    }
                    break;
                }
                case Direction.Right:
                {
                    if (body.First().X != xEnd - Cell.Size)
                    {
                        body.Insert(0, new Cell(body.First().X + Cell.Size, body.First().Y, color));
                    }
                    else
                    {
                        body.Insert(0, new Cell(xStart, body.First().Y, color));
                    }
                    break;
                }
                case Direction.Down:
                {
                    if (body.First().Y != yEnd - Cell.Size)
                    {
                        body.Insert(0, new Cell(body.First().X, body.First().Y + Cell.Size, color));
                    }
                    else
                    {
                        body.Insert(0, new Cell(body.First().X, yStart, color));
                    }
                    break;
                }
                case Direction.Left:
                {
                    if (body.First().X != xStart)
                    {
                        body.Insert(0, new Cell(body.First().X - Cell.Size, body.First().Y, color));
                    }
                    else
                    {
                        body.Insert(0, new Cell(xEnd - Cell.Size, body.First().Y, color));
                    }                    
                    break;
                }
            }
            body.Remove(body.Last());
        }

        public void Eat(Food food)
        {
            if ((body.First().X == food.X) && (body.First().Y == food.Y))
            {
                body.Insert(0, new Cell(food.X, food.Y, color));
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
                FoodEated++;
            }
        }

        public bool HitItself()
        {
            var head = body[0];
            bool isHit = false;
            for (int i = 3; i < body.Count(); i++)
            {
                if (head.X == body[i].X && head.Y == body[i].Y)
                {
                    isHit = true;
                    canMove = false;
                    break;
                }
            }
            return isHit;
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (Cell c in body)
            {
                c.Render(graphics);
            }
        }

        public void Update(GameEngine engine)
        {
            if (canMove)
            {
                Move();
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
                canMove = true;
            }
            if (Input.IsKeyDown(Keys.ESCAPE))
            {
                canMove = false;
            }
        }
    }
}
