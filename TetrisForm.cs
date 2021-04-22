using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        static Shape currentShape;

        readonly static int[,] map = new int[20, 10];
        readonly int rectangleSize = 25;
        readonly int indent = 50;
        private int linesRemoved = 0;
        private int score = 0;
        private int interval = 300;

        public TetrisForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            currentShape = new Shape(3, 0);

            this.KeyDown += new KeyEventHandler(KeysFunctions);

            scoreLabel.Text = "Score: " + score;
            linesLabel.Text = "Lines: " + linesRemoved;

            timer.Interval = interval;
            timer.Tick += new EventHandler(Update);
            timer.Start();

            Invalidate();
        }
        private void CutMap()
        {
            int counter;
            int curRemovedLines = 0;

            for (int i = 0; i < map.GetLength(0); i++) 
            {
                counter = 0;
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] != 0)
                    {
                        counter++;
                    }
                }
                if(counter == map.GetLength(1))
                {
                    curRemovedLines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int n = 0; n < 8; n++)
                        {
                            map[k, n] = map[k-1, n];
                        }
                    }
                }
            }
            for (int i = 0; i < curRemovedLines; i++)
            {
                score += 10 * curRemovedLines;
            }
            linesRemoved += curRemovedLines;

            if (linesRemoved % 5 == 0)
            {
                if (interval > 80)
                {
                    interval -= 10;
                }
            }

            scoreLabel.Text = "Score: " + score;
            linesLabel.Text = "Lines: " + linesRemoved;
        }

        public static bool AbilityToRotate()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (j >= 0 && j <= 7)
                    {
                        if (map[i, j] != 0 && currentShape.matrix[i - currentShape.y, j - currentShape.x] == 0)
                            return true;
                    }
                }
            }
            return false;
        }
        private void KeysFunctions(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.S:
                    {
                        if (!AbilityToRotate())
                        {
                            DeleteArea();
                            currentShape.RotateShape();
                            GetArea();
                            Invalidate();
                        }
                    }
                    break;
                case Keys.Down:
                    {
                        timer.Interval = 10;
                    }
                    break;
                case Keys.Right:
                    if (!HorizontalCollision(1))
                    {
                        DeleteArea();
                        currentShape.MoveRight();
                        GetArea();
                        Invalidate();
                    }
                    break;
                case Keys.Left:
                    if (!HorizontalCollision(-1))
                    {
                        DeleteArea();
                        currentShape.MoveLeft();
                        GetArea();
                        Invalidate();
                    }
                    break;
            }
        }
        private void DrawMap(Graphics g)
        {
            for (int i = 0; i <= map.GetLength(0); i++)
            {
                g.DrawLine(Pens.Black, new Point(indent, indent + i * rectangleSize), new Point(indent + map.GetLength(1) * rectangleSize, indent + i * rectangleSize));
            }
            for (int i = 0; i <= map.GetLength(1); i++)
            {
                g.DrawLine(Pens.Black, new Point(indent + i * rectangleSize, indent), new Point(indent + i * rectangleSize, indent + map.GetLength(0) * rectangleSize));
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            DrawShape(e.Graphics);
        }
        private void Update(object sender, EventArgs e)
        {
            DeleteArea();
            if (!VerticalCollision())
            {
                currentShape.MoveDown();
            }
            else
            {
                GetArea();
                CutMap();
                timer.Interval = interval;
                currentShape = new Shape(3, 0);
            }
            GetArea();
            Invalidate();
        }
        private bool VerticalCollision()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (i + 1 == map.GetLength(0)) 
                        {
                            return true;
                        }
                        if (map[i+1,j]!=0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool HorizontalCollision(int direction)
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (j + 1 * direction > map.GetLength(1) - 1 || j + 1 * direction < 0)
                            return true;

                        if (map[i, j + 1 * direction] != 0)
                        {
                            if (j - currentShape.x + 1 * direction >= currentShape.sizeMatrix || j - currentShape.x + 1 * direction < 0)
                            {
                                return true;
                            }
                            if (currentShape.matrix[i - currentShape.y, j - currentShape.x + 1 * direction] == 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        private void GetArea()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    { 
                        map[i, j] = currentShape.matrix[i - currentShape.y, j - currentShape.x];
                    }
                }
            }
        }
        private void DeleteArea()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                        if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                        {
                            map[i, j] = 0;
                        }
                }
            }
        }
        public void DrawShape(Graphics e)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        e.FillRectangle(Brushes.DeepPink, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (map[i, j] == 2)
                    {
                        e.FillRectangle(Brushes.DarkGreen, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (map[i, j] == 3)
                    {
                        e.FillRectangle(Brushes.DodgerBlue, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (map[i, j] == 4)
                    {
                        e.FillRectangle(Brushes.Crimson, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (map[i, j] == 5)
                    {
                        e.FillRectangle(Brushes.DarkViolet, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (map[i, j] == 6)
                    {
                        e.FillRectangle(Brushes.Gold, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (map[i, j] == 7)
                    {
                        e.FillRectangle(Brushes.Cyan, new Rectangle(indent + j * rectangleSize + 1, indent + i * rectangleSize + 1, rectangleSize - 1, rectangleSize - 1));
                    }
                }
            }
        }
    }
}