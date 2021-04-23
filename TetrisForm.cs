using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        static Shape currentShape;

        readonly static int[,] map = new int[20, 10];
        readonly static int rectangleSize = 25;
        readonly int indent = 50;
        readonly static int nextIndent1 = 350;
        readonly static int nextIndent2 = 290;
        private int linesRemoved = 0;
        private static int score = 0;
        private int interval = 300;

        public TetrisForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            currentShape = new Shape(3,0);

            this.KeyDown += new KeyEventHandler(KeysFunctions);

            scoreLabel.Text = "Score: " + score;
            linesLabel.Text = "Lines: " + linesRemoved;

            timer.Interval = interval;
            timer.Tick += new EventHandler(Update);

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
                    if (j >= 0 && j <= map.GetLength(1)-1)
                    {
                        if (map[i, j] != 0 && currentShape.matrix[i - currentShape.y, j - currentShape.x] == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void KeysFunctions(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Up:
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
                case Keys.Space:
                    {
                        if (timer.Enabled)
                        {
                            pauseButton.Text = "Play";
                            timer.Stop();
                        }
                        else
                        {
                            pauseButton.Text = "Pause";
                            timer.Start();
                        }
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
            ShowNextShape(e.Graphics);
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
                currentShape.ResetShape(3, 0);
                if (VerticalCollision())
                {
                    ClearMap();
                    timer.Tick -= new EventHandler(Update);
                    timer.Stop();
                    MessageBox.Show("Ваш результат: " + score, "Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Init();
                }
            }
            GetArea();
            Invalidate();
        }
        public void ClearMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 0;
                }
            }
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
                        {
                            return true;
                        }

                        if (map[i, j + 1 * direction] != 0)
                        {
                            if (j - currentShape.x + 1 * direction >= currentShape.sizeMatrix || j - currentShape.x + 1 * direction < 0)
                            {
                                return true;
                            }
                            if (currentShape.matrix[i - currentShape.y, j - currentShape.x + 1 * direction] == 0)
                            {
                                return true;
                            }
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
        public static void ShowNextShape(Graphics e)
        {
            for (int i = 0; i < currentShape.sizeNextMatrix; i++)
            {
                for (int j = 0; j < currentShape.sizeNextMatrix; j++)
                {
                    if (currentShape.nextMatrix[i, j] == 1)
                    {
                        e.FillRectangle(Brushes.DeepPink, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 2)
                    {
                        e.FillRectangle(Brushes.DarkGreen, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 3)
                    {
                        e.FillRectangle(Brushes.DodgerBlue, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 4)
                    {
                        e.FillRectangle(Brushes.Crimson, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 5)
                    {
                        e.FillRectangle(Brushes.DarkViolet, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 6)
                    {
                        e.FillRectangle(Brushes.Gold, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 7)
                    {
                        e.FillRectangle(Brushes.Cyan, new Rectangle(nextIndent1 + j * rectangleSize + 1, nextIndent1 + i * rectangleSize + 1 - nextIndent2, rectangleSize - 1, rectangleSize - 1));
                    }
                }
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                pauseButton.Text = "Play";
                timer.Stop();
            }
            else
            {
                pauseButton.Text = "Pause";
                timer.Start();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                pauseButton.Text = "Play";
                timer.Stop();
            }
            string infoString = "";
            infoString = "Для управление фигурами используйте стрелочку влево/вправо.\n";
            infoString += "Чтобы ускорить падение фигуры - нажмите стрелочку вниз.\n";
            infoString += "Для поворота фигуры используйте стрелочку вверх.\n";
            MessageBox.Show(infoString, "Справка");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            timer.Tick -= new EventHandler(Update);
            timer.Stop();
            ClearMap();
            Init();
        }
    }
}