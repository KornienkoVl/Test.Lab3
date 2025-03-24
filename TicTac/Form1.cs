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

            map[cellX, cellY] = 1;
            return true;
        }

        public void ChangePlayer()
        {
            player = 0 - player;
        }

    };
}
