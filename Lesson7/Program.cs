using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Menu());

            var authorizationState = GameState.NotStarted;

            do
            {
                switch (authorizationState)
                {
                    case GameState.NotStarted:
                        var menuForm = new Menu();
                        var result = menuForm.ShowDialog();
                        switch (result)
                        {
                            case DialogResult.Cancel:
                                authorizationState = GameState.ApplicationTerminate;
                                break;
                            case DialogResult.OK:
                                authorizationState = GameState.Double;
                                break;
                            case DialogResult.Yes:
                                authorizationState = GameState.Guess;
                                break;
                        }
                        break;
                    case GameState.Double:
                        var doubleForm = new Double();
                        Application.Run(doubleForm);
                        if (doubleForm.InternalDialogResult == DialogResult.Cancel)
                        {
                            authorizationState = GameState.ApplicationTerminate;
                        }
                        else
                        {
                            authorizationState = GameState.NotStarted;
                        }

                        break;
                    case GameState.Guess:
                        var guessForm = new Guess();
                        Application.Run(guessForm);
                        if (guessForm.InternalDialogResult == DialogResult.Cancel)
                        {
                            authorizationState = GameState.ApplicationTerminate;
                        }
                        else
                        {
                            authorizationState = GameState.NotStarted;
                        }

                        break;
                }

            } while (authorizationState != GameState.ApplicationTerminate);
        }
    }
}
