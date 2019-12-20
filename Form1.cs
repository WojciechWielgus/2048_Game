using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        static int NUMBER_OF_START_NUMBERS = 7;
        const int sizeBoard = 4;
        List<Cell> cells = new List<Cell>();
        enum Direction { Left, Up, Right, Down };

        public Form1()
        {
            InitializeComponent();
            Start();
            UpdateBoard();
            
        }

        void Start()
        {
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    string labelName = "field" + i + j;
                    Label label = Controls.Find(labelName, true).FirstOrDefault() as Label;
                    cells.Add(new Cell(i, j, 0, label));
                }
            }
            StartRandomValues();
        }

        void Movement(Direction direction)
        {
            List<int> tempList = new List<int>();
            for (int i = 0; i < sizeBoard; i++)
            {
                switch (direction)
                {
                    case Direction.Left:
                        tempList.Clear();
                        for (int j = 0; j < sizeBoard - 1; j++)
                        {
                            if (j < 1  && cells[(i * sizeBoard) + j + 1].value == 0 && cells[(i * sizeBoard) + j + 2].value == 0 && cells[(i * sizeBoard) + j].value == cells[(i * sizeBoard) + j + 3].value)
                            {
                                cells[(i * sizeBoard) + j].value *= 2;
                                cells[(i * sizeBoard) + j + 3].value = 0;
                            }
                            else if (j < 2 && cells[(i * sizeBoard) + j + 1].value == 0  && cells[(i * sizeBoard) + j].value == cells[(i * sizeBoard) + j + 2].value)
                            {
                                cells[(i * sizeBoard) + j].value *= 2;
                                cells[(i * sizeBoard) + j + 2].value = 0;
                            }
                            else if (cells[(i * sizeBoard) + j].value == cells[(i * sizeBoard) + j + 1].value)
                            {
                                cells[(i * sizeBoard) + j].value *= 2;
                                cells[(i * sizeBoard) + j + 1].value = 0;
                            }
                        }
                        for (int j = 0; j < sizeBoard; j++)
                        {
                            if (cells[(i * sizeBoard) + j].value > 0)
                            {
                                tempList.Add(cells[(i * sizeBoard) + j].value);
                                cells[(i * sizeBoard) + j].value = 0;
                            }                            
                        }
                        for (int j = 0; j < tempList.Count; j++)
                        {
                            cells[(i * sizeBoard) + j].value = tempList[j];
                        }


                        
                        break;
                    case Direction.Up:
                        tempList.Clear();
                        for (int j = 0; j < sizeBoard - 1; j++)
                        {
                            if(j < 1 && cells[i + (j * sizeBoard)].value == cells[i + (j * sizeBoard) + (3 * sizeBoard)].value)
                            {
                                cells[i + (j * sizeBoard)].value *= 2;
                                cells[i + (j * sizeBoard) + (3 * sizeBoard)].value = 0;
                            }
                            else if (j < 2 && cells[i + (j * sizeBoard)].value == cells[i + (j * sizeBoard) + (2 * sizeBoard)].value)
                            {
                                cells[i + (j * sizeBoard)].value *= 2;
                                cells[i + (j * sizeBoard) + (2 * sizeBoard)].value = 0;
                            }
                            else if (cells[i + (j * sizeBoard)].value == cells[i + (j * sizeBoard) + sizeBoard].value)
                            {
                                cells[i + (j * sizeBoard)].value *= 2;
                                cells[i + (j * sizeBoard) + sizeBoard].value = 0;
                            }

                        }
                        for (int j = 0; j < sizeBoard; j++)
                        {
                            if (cells[i + (j * sizeBoard)].value > 0)
                            {
                                tempList.Add(cells[i + (j * sizeBoard)].value);
                                cells[i + (j * sizeBoard)].value = 0;
                            }
                        }
                        for (int j = 0; j < tempList.Count; j++)
                        {
                            cells[i + (j * sizeBoard)].value = tempList[j];
                        }

                        break;
                    case Direction.Right:
                        tempList.Clear();
                        for (int j = 0; j < sizeBoard - 1; j++)
                        {
                            if(j < 1 && cells[(i * sizeBoard) + sizeBoard - 2 - j].value == 0 && cells[(i * sizeBoard) + sizeBoard - 3 - j].value == 0 && cells[(i * sizeBoard) + sizeBoard - 1 - j].value == cells[(i * sizeBoard) + sizeBoard - 4 - j].value)
                            {
                                cells[(i * sizeBoard) + sizeBoard - 1 - j].value *= 2;
                                cells[(i * sizeBoard) + sizeBoard - 4 - j].value = 0;
                            }
                            else if (j < 2 && cells[(i * sizeBoard) + sizeBoard - 2 - j].value ==0 && cells[(i * sizeBoard) + sizeBoard - 1 - j].value == cells[(i * sizeBoard) + sizeBoard - 3 - j].value)
                            {
                                cells[(i * sizeBoard) + sizeBoard - 1 - j].value *= 2;
                                cells[(i * sizeBoard) + sizeBoard - 3 - j].value = 0;
                            }
                            else if (cells[(i * sizeBoard) + sizeBoard - 1 - j].value == cells[(i * sizeBoard) + sizeBoard - 2 - j].value)
                            {
                                cells[(i * sizeBoard) + sizeBoard - 1 - j].value *= 2;
                                cells[(i * sizeBoard) + sizeBoard - 2 - j].value = 0;
                            }
                        }
                        for (int j = 0; j < sizeBoard - 1; j++)
                        {
                            if (cells[(i * sizeBoard) + sizeBoard - 1 - j].value == cells[(i * sizeBoard) + sizeBoard - 2 - j].value)
                            {
                                cells[(i * sizeBoard) + sizeBoard - 1 - j].value *= 2;
                                cells[(i * sizeBoard) + sizeBoard - 2 - j].value = 0;
                            }
                        }
                        for (int j = 0; j < sizeBoard; j++)
                        {
                            if (cells[(i * sizeBoard) + j].value > 0)
                            {
                                tempList.Add(cells[(i * sizeBoard) + j].value);
                                cells[(i * sizeBoard) + j].value = 0;
                            }
                        }
                        for (int j = 0; j < tempList.Count; j++)
                        {
                            cells[(i * sizeBoard) + (sizeBoard - 1 - j)].value = tempList[tempList.Count - 1 - j];
                        }
                        break;
                    case Direction.Down:
                        tempList.Clear();
                        for (int j = 0; j < sizeBoard; j++)
                        {
                            if (cells[i + (j * sizeBoard)].value > 0)
                            {
                                tempList.Add(cells[i + (j * sizeBoard)].value);
                                cells[i + (j * sizeBoard)].value = 0;
                            }
                        }
                        for (int j = 0; j < tempList.Count; j++)
                        {
                            cells[((sizeBoard * sizeBoard) - sizeBoard + i) - 4*j].value = tempList[tempList.Count - 1 - j];
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }

        void StartRandomValues()
        {
            Random random = new Random();
            Random random2 = new Random();
            for (int i = 0; i < NUMBER_OF_START_NUMBERS; i++)
            {
                int position = random.Next(0, cells.Count);
                if (cells[position].value <= 0) cells[position].value = 2;
                else i--;
            }
        }

        void UpdateBoard()
        {
            foreach (var cell in cells)
            {
                Label label = cell.label;
                if(cell.value <= 0) label.Text = "";
                else label.Text = cell.value.ToString();
                //Console.WriteLine("X:{0} || Y:{1} || Label:{2}", cell.x, cell.y, cell.label.Name);
            }
        }
           
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) Movement(Direction.Left);
            if (e.KeyCode == Keys.Up) Movement(Direction.Up);
            if (e.KeyCode == Keys.Right) Movement(Direction.Right);
            if (e.KeyCode == Keys.Down) Movement(Direction.Down);
            //RandomInsert();
            UpdateBoard();
        }
    }



    class Cell
    {
        //uint id;
        public int x { get; set; }
        public int y { get; set; }
        public int value { get; set; }
        public Label label { get; set; }

        public Cell(int x, int y, int value, Label label)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.label = label;
        }

        public void Swap(Cell cell)
        {
            Cell tempCell = this;

            //this.x = cell.x;
            //this.y = cell.y;
            this.value = cell.value;
            //this.label = cell.label;

            //cell.x = tempCell.x;
            //cell.y = tempCell.y;
            cell.value = tempCell.value;
            //cell.label = tempCell.label;
        }

    }
}
