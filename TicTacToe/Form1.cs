using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
                     //переменные для хранения результатов игры
        int Player_1 = 0; 
        int Player_2 = 0;
        int Draw = 0;
                  
        int[,] Game_map = new int[3, 3]; // игровое поле, 0- пустое поле, 1 - крестик, 2 - нолик
        int Gamer; // 1 - крестик, 2 - нолик
        bool Play; // true - игра продолжается, false - конец игры
        int Step; // количество сделанных ходов, если  == 9 ничья
        public Form1()
        {
            InitializeComponent();
            newGameOnePlayerToolStripMenuItem.Enabled = false; // метод игры с компьютером  
            this.Text = "Tic tac toe";
            this.BackgroundImage = Image.FromFile("1.jpg");
            tableLayoutPanel1.BackColor = Color.Transparent;

            GameInit(); 
            Start_Game();

        }
        public void GameInit() // инициализация игрового поля
        {
            Gamer = 1;
            Play = true;
            Step = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Game_map[i, j] = 0;
                }
            }
        }
        public bool Moves_to_play(int i, int j) // проверка возможности хода
        {
            if (!Play)
            {
                return false;
            }
            if (i < 0 || i > 2 || j < 0 || j > 2) //проверка координат игрового поля
            {
                return false;
            }
            if (Game_map[i, j] > 0)
            {
                return false; //если поле зянято 
            }
            Game_map[i, j] = Gamer; //устанавливаем значение: 1 - крестик, 2 - нолик
            Step++;
            if(!Finish(i, j))
            {
                Gamer = (Gamer == 1) ? 2 : 1; // меняем игрока               
            }
            return true;

        }

        public bool Finish(int i, int j)
        {
            Bitmap bmp = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Brushes.Yellow, 15);

            bool win = false;
            if (Game_map[i, 0] == Gamer && Game_map[i, 1] == Gamer && Game_map[i, 2] == Gamer) //проверка горизонтали 
            {
                win = true;
                if (Game_map[0, 0] == 1 && Game_map[0, 1] == 1 && Game_map[0, 2] == 1 || Game_map[0, 0] == 2 && Game_map[0, 1] == 2 && Game_map[0, 2] == 2)
                {
                    graph.DrawLine(pen, new Point(10, pictureBox1.Height / 2), new Point(tableLayoutPanel1.Width - 15, pictureBox1.Height / 2 ));
                }
                if (Game_map[1, 0] == 1 && Game_map[1, 1] == 1 && Game_map[1, 2] == 1 || Game_map[1, 0] == 2 && Game_map[1, 1] == 2 && Game_map[1, 2] == 2)
                {
                    graph.DrawLine(pen, new Point(10, tableLayoutPanel1.Height / 2), new Point(tableLayoutPanel1.Width - 15, tableLayoutPanel1.Height / 2));
                }
                if (Game_map[2, 0] == 1 && Game_map[2, 1] == 1 && Game_map[2, 2] == 1 || Game_map[2, 0] == 2 && Game_map[2, 1] == 2 && Game_map[2, 2] == 2)
                {
                    graph.DrawLine(pen, new Point(10, ((pictureBox1.Height / 2) * 5)), new Point(tableLayoutPanel1.Width - 15, ((pictureBox1.Height / 2) * 5)));
                }

            }
            if (Game_map[0, j] == Gamer && Game_map[1, j] == Gamer && Game_map[2, j] == Gamer) //проверка вертикали 
            {
                win = true;
                if (Game_map[0, 0] == 1 && Game_map[1, 0] == 1 && Game_map[2, 0] == 1 || Game_map[0, 0] == 2 && Game_map[1, 0] == 2 && Game_map[2, 0] == 2)
                {
                    graph.DrawLine(pen, new Point(pictureBox1.Width / 2, 10), new Point(pictureBox1.Width / 2, tableLayoutPanel1.Height - 15 ));
                }
                if (Game_map[0, 1] == 1 && Game_map[1, 1] == 1 && Game_map[2, 1] == 1 || Game_map[0, 1] == 2 && Game_map[1, 1] == 2 && Game_map[2, 1] == 2)
                {
                    graph.DrawLine(pen, new Point(tableLayoutPanel1.Width / 2, 10), new Point(tableLayoutPanel1.Width / 2, tableLayoutPanel1.Height - 15));
                }
                if (Game_map[0, 2] == 1 && Game_map[1, 2] == 1 && Game_map[2, 2] == 1 || Game_map[0, 2] == 2 && Game_map[1, 1] == 2 && Game_map[2, 2] == 2)
                {
                    graph.DrawLine(pen, new Point((pictureBox1.Width / 2) * 5, 10), new Point((pictureBox1.Width / 2) * 5, tableLayoutPanel1.Height - 15));
                }
            }
            if (Game_map[0, 0] == Gamer && Game_map[1, 1] == Gamer && Game_map[2, 2] == Gamer) //проверка диагонали 1
            {
                win = true;
                graph.DrawLine(pen, new Point(10, 10), new Point( tableLayoutPanel1.Width - 15, tableLayoutPanel1.Height - 15));
            }
            if (Game_map[2, 0] == Gamer && Game_map[1, 1] == Gamer && Game_map[0, 2] == Gamer) //проверка диагонали 2
            {
                win = true;
                graph.DrawLine(pen, new Point(10, tableLayoutPanel1.Height - 15), new Point(tableLayoutPanel1.Width - 15, 10 ));
            }
            tableLayoutPanel1.BackgroundImage = bmp;
            graph.Dispose();
            pen.Dispose();
            if (win)
            {
                if (win)
                {
                    if (Gamer == 1)
                    {
                        Player_1++;
                        Play = false;
                        MessageBox.Show("Player number 1 won", "End of the game");                       
                    }
                    else
                    {
                        Player_2++;
                        Play = false;
                        MessageBox.Show("Player number 2 won", "End of the game");                       
                    }

                }
            }
            else
            {
                if (Step == 9)
                {
                    Play = false;
                    MessageBox.Show("Draw", "End of the game");
                    Draw++;
                    return win;
                }
                //else
                //{
                //     //продолжение игры
                //}
            }
            return win;
        }

        private void pictureBox1_Click(object sender, EventArgs e) // обработчик для всех pictureBox
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = null;
            int i;
            int j;
            string tag = ((PictureBox)sender).Tag.ToString(); // из Tag pictureBox берем координаты ячейки игрового поля
            i = int.Parse(tag.Substring(0, 1));
            j = int.Parse(tag.Substring(1, 1));
            int gamer = Gamer; // берем значение текущего игрока до изменения в Moves_to_play

            if (Moves_to_play(i, j))
            {
                if (gamer == 1) // 1 - крестик
                {
                    pen = new Pen(Brushes.Red, 15);
                    graph.DrawLine(pen, new Point(30, 30), new Point(pictureBox1.Width - 35, pictureBox1.Height - 35));
                    graph.DrawLine(pen, new Point(pictureBox1.Width - 35, 30), new Point(30, pictureBox1.Height - 35));
                    ((PictureBox)sender).Image = bmp;
                    graph.Dispose();
                    pen.Dispose();
                   
                }
                else
                {
                    pen = new Pen(Brushes.Blue, 15);
                    graph.DrawEllipse(pen, 20, 15, pictureBox1.Width - 40, pictureBox1.Height - 30);
                    ((PictureBox)sender).Image = bmp;
                    graph.Dispose();
                    pen.Dispose();
                }
            }
            if (Play == false)
            {
                return;
            }
        }

        private void newGameTwoPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start_Game();
        }
        private void Start_Game()
        {
            GameInit();
            label4.Text = Player_1.ToString();
            label5.Text = Player_2.ToString();
            label6.Text = Draw.ToString();
            tableLayoutPanel1.BackgroundImage = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rulesOfTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игроки по очереди ставят на свободные клетки поля 3х3 знаки (один всегда крестики, другой всегда нолики). Первый, выстроивший в ряд 3 своих фигуры по вертикали, горизонтали или диагонали, выигрывает. Первый ход делает игрок, ставящий крестики.", "Rulebook");

        }

        private void aboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Экзаменационный проект игры Крестики-Нолики", "About the program");

        }

       
    }
}
