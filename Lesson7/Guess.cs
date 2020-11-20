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
    public partial class Guess : Form
    {
        private DialogResult internalDialogResult = DialogResult.None;

        public DialogResult InternalDialogResult
        {
            get { return internalDialogResult; }
        }

        int numberToGet = 9999;
        int numberOfMoves = 0;
        public Guess()
        {
            InitializeComponent();

            label1.Text = "Отгадай число от 1 до 100!";
            label2.Text = "Количество ходов:";
            label3.Text = numberOfMoves.ToString();
            this.Text = "Отгадай число от 1 до 100";

            Random rand = new Random();
            numberToGet = rand.Next(1, 100);
        }


        private void CheckWin()
        {

            if (Int32.TryParse(textBox1.Text, out int guess))
            {
                if (guess == numberToGet)
                {
                    if (MessageBox.Show(this, $"Победа! Вы отгадали число за {numberOfMoves} ходов!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
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
                else if (guess > numberToGet)
                {
                    label1.Text = "Введённое число больше загаданного!";
                }
                else
                {
                    label1.Text = "Введённое число меньше загаданного!";
                }
            }
            else
            {
                label1.Text = "Вы ввели что-то непонятное!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberOfMoves++;
            label3.Text = numberOfMoves.ToString();
            
            CheckWin();
            textBox1.Text = "";
        }

        private void buttonQuit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Вы действительно желаете выйти в меню?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                internalDialogResult = DialogResult.Abort;
                Close();
            }
        }

        private void Guess_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
