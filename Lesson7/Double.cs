using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    public partial class Double : Form
    {
        private DialogResult internalDialogResult = DialogResult.None;

        public DialogResult InternalDialogResult
        {
            get { return internalDialogResult; }
        }

        int currentNumber = 0;
        int numberOfMoves = 0;
        int numberToGet = 9999;
        int minMoves = 9999;
        public Double()
        {
            InitializeComponent();

            label1.Text = currentNumber.ToString();
            label2.Text = "Количество ходов:";
            label3.Text = numberOfMoves.ToString();
            this.Text = "Удвоитель";

            Random rand = new Random();
            numberToGet = rand.Next(1,20);

            minMoves = MinMoves(numberToGet);

            label4.Text = numberToGet.ToString();
            MessageBox.Show(this, $"Постарайтесь набрать {numberToGet} за минимальное количество ходов!", "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (internalDialogResult != DialogResult.Abort)
            {
                if (MessageBox.Show(this, "Вы действительно желаете завершить работу приложения?",
                "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    internalDialogResult = DialogResult.Cancel;
                }
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Вы действительно желаете выйти в меню?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                internalDialogResult = DialogResult.Abort;
                Close();
            }
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            currentNumber++;
            numberOfMoves++;
            label1.Text = currentNumber.ToString(); 
            label3.Text = numberOfMoves.ToString();
            CheckWin();
        }

        private void buttonTimes2_Click(object sender, EventArgs e)
        {
            currentNumber *= 2;
            numberOfMoves++;
            label1.Text = currentNumber.ToString();
            label3.Text = numberOfMoves.ToString();
            CheckWin();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            currentNumber = 0;
            numberOfMoves++;
            label1.Text = currentNumber.ToString();
            label3.Text = numberOfMoves.ToString();
        }

        private int MinMoves(int number)
        {
            int minMoves = 0;
            while(number > 0)
            {
                if (number % 2 == 0)
                {
                    number /= 2;
                }
                else
                {
                    number--;
                }
                minMoves++;
            }
            return minMoves;
        }

        private void CheckWin()
        {
            if(currentNumber == numberToGet)
            {
                string winText = $"Победа! Вы получили верное число за {numberOfMoves} ходов! ";
                if(numberOfMoves <= minMoves)
                {
                    winText += "Отличный результат!";
                }
                else
                {
                    winText += "Можно было и по-быстрее...";
                }
                if (MessageBox.Show(this, winText, "Победа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    internalDialogResult = DialogResult.Abort;
                    Close();
                }
                else
                {
                    internalDialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }
    }
}
