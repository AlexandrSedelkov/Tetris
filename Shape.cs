using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Shape
    {
        public int x;
        public int y;
        public int[,] matrix;
        public int[,] nextMatrix;
        public int sizeMatrix;
        public int sizeNextMatrix;

        readonly int[,] line = new int[4, 4]
            {
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0 ,1, 0}
            };
        readonly int[,] triangle = new int[3, 3]
            {
                {0, 0, 0},
                {0, 2, 0},
                {2 ,2, 2}
            };
        readonly int[,] square = new int[2, 2]
            {
                {3, 3},
                {3 ,3}
            };
        readonly int[,] zigzag = new int[3, 3]
            {
                {0, 0, 0},
                {0, 4, 4},
                {4, 4, 0}
            };
        readonly int[,] curveLine = new int[3, 3]
            {
                {0, 0, 5},
                {0, 0, 5},
                {0 ,5, 5}
            };
        readonly int[,] obrcurveLine = new int[3, 3]
            {
                {6, 0, 0},
                {6, 0, 0},
                {6 ,6, 0}
            };
        readonly int[,] obrzigzag = new int[3, 3]
            {
                {0, 0, 0},
                {7, 7, 0},
                {0 ,7, 7}
            };

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
            matrix = GenerateMatrix();
            sizeMatrix = (int)Math.Sqrt(matrix.Length);
            nextMatrix = GenerateMatrix();
            sizeNextMatrix = (int)Math.Sqrt(nextMatrix.Length);
        }

        public void ResetShape(int x, int y)
        {
            this.x = x;
            this.y = y;
            matrix = nextMatrix;
            sizeMatrix = (int)Math.Sqrt(matrix.Length);
            nextMatrix = GenerateMatrix();
            sizeNextMatrix = (int)Math.Sqrt(nextMatrix.Length);
        }

        public int[,] GenerateMatrix()
        {
            int[,] _matrix = line;
            Random r = new Random();
            switch (r.Next(1, 8))
            {
                case 1:
                    _matrix = line;
                    break;
                case 2:
                    _matrix = triangle;
                    break;
                case 3:
                    _matrix = square;
                    break;
                case 4:
                    _matrix = zigzag;
                    break;
                case 5:
                    _matrix = curveLine;
                    break;
                case 6:
                    _matrix = obrcurveLine;
                    break;
                case 7:
                    _matrix = obrzigzag;
                    break;

                default: break;
            }
            return _matrix;
        }

        public void RotateShape()
        {
            int[,] tempMatrix = new int[sizeMatrix, sizeMatrix];
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    tempMatrix[i, j] = matrix[j, (sizeMatrix - 1) - i];
                }
            }
            matrix = tempMatrix;
            int offset1 = (8 - (x + sizeMatrix));
            if (offset1 < 0)
            {
                for (int i = 0; i < Math.Abs(offset1); i++)
                    MoveLeft();
            }

            if (x < 0)
            {
                for (int i = 0; i < Math.Abs(x) + 1; i++)
                    MoveRight();
            }

        }

        public void MoveDown()
        {
            y++;
        }
        public void MoveRight()
        {
            x++;
        }
        public void MoveLeft()
        {
            x--;
        }
    }
}
