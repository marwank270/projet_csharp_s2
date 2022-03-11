using System;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;

namespace Projet_CSharp_S2
{
    class Menu
    {
        private string Question;
        private string[] Options;
        private int Selection;

        public Menu(string question, string[] options_menu)
        {
            Question = question;
            Options = options_menu;
            Selection = 0;
        }

        public void AffichageOptions()
        {
            Program.EcrireCentre(Question);

            for (int i = 0; i < Options.Length; i++)
            {
                string SelectionActuelle = Options[i];
                string selecteur;

                if (i == Selection)
                {
                    if (i == 2)
                        selecteur = "\t  \x1b[41m\x1b[37m►  ";
                    else
                        selecteur = "\t  \x1b[47m\x1b[30m►  ";
                }
                else
                {
                    selecteur = "";
                }
                Program.EcrireCentre($"{selecteur}{SelectionActuelle}\x1b[0m");
            }
        }

        public int Deplacement()
        {
            ConsoleKey touche;
            do
            {
                Console.SetCursorPosition(96, 29); // ligne 2
                AffichageOptions();

                ConsoleKeyInfo info_touche = Console.ReadKey(true);
                touche = info_touche.Key;

                if (touche == ConsoleKey.UpArrow)
                {
                    Selection--;
                    if (Selection == -1)
                        Selection = Options.Length - 1;
                }
                else if (touche == ConsoleKey.DownArrow)
                {
                    Selection++;
                    if (Selection == Options.Length)
                        Selection = 0;
                }

            } while (touche != ConsoleKey.Enter);
            return Selection;
        }
    }
}