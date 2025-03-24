using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TicTac
{
    public partial class Form1: Form
    {
        Game game = new Game();

        public Form1()
        {
            InitializeComponent();
            game.MakeMove(1,1);
            game.MakeMove(1, 2);
            game.MakeMove(2, 2);
            MessageBox.Show(game.map[1,1].ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void btn6_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {

        }

        private void btn8_Click(object sender, EventArgs e)
        {

        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }
    }

    public class Game
    {
        public int[,] map = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public int player = 1;

        public bool MakeMove(int cellX, int cellY)
        {
            if (cellX < 0 || cellX > 2 || cellY < 0 || cellY > 2)
                return false;

            if (map[cellX, cellY] != 0)
                return false;

            map[cellX, cellY] = player;

            ChangePlayer();

            return true;
        }

        public void ChangePlayer()
        {
            player = 0 - player;
        }

        // 1 - победа Х
        // 0 - нет победителя
        //-1 - победа О
        public int checkWin()
        {
            int checkSum = 0;

            //горизонталь
            for (int i = 0; i < 3; i++)
            {
                checkSum = map[i, 0] + map[i, 1] + map[i, 2];

                if (checkSum == 3) return 1;
                if (checkSum == -3) return -1;
            }
            //вертикаль
            for (int i = 0; i < 3; i++)
            {
                checkSum = map[0, i] + map[1, i] + map[2, i];

                if (checkSum == 3) return 1;
                if (checkSum == -3) return -1;
            }
            //диагонали
            checkSum = map[0, 0] + map[1, 1] + map[2, 2];
            if (checkSum == 3) return 1;
            if (checkSum == -3) return -1;

            checkSum = map[0, 2] + map[1, 1] + map[2, 0];
            if (checkSum == 3) return 1;
            if (checkSum == -3) return -1;

            return 0;
        }

        public bool checkDraw()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (map[i, j] == 0) return false;
            return true;
        }

        public void Clear()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    map[i, j] = 0;

            player = 1;
        }

        // 0 - игра продолжается
        // 1 - победил Х
        // 2 - ничья
        // 3 - победил O
        public int Play(int cellX, int cellY)
        {
            MakeMove(cellX, cellY);
            int win = checkWin();
            if (win == 1)
            {
                Clear();
                return 1;
            }

            if (win == -1)
            {
                Clear();
                return 3;
            }

            if (checkDraw()) 
            {
                Clear();
                return 2;
            }
            return 0;
        }
    };
}
