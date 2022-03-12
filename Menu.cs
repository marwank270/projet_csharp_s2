using System;

namespace Projet_CSharp_S2
{
    class Menu
    {
        private string Question;        // String qui va contenir la question à poser dans le menu (en private pour être accessible partout dans la classe Menu seulement
        private string[] Options;       // Tableau destiné à contenir les options possible
        private int Selection;          // Int qui contiendra la sélection actuelle

        public Menu(string question, string[] options_menu) 
        {
            Question = question;        // Assignation dans les variables globales
            Options = options_menu;     //
            Selection = 0;              //
        }

        public void AffichageOptions()  // Méthode permettant d'écrire les options ainsi que la selection (et au centre en plus)
        {
            Program.EcrireCentre(Question);

            for (int i = 0; i < Options.Length; i++)
            {
                string SelectionActuelle = Options[i];      // Selection actuelle définie quelle option est actuellement sélectionnée (et donc surlignée)
                string selecteur;                           // Nous ajoutons un indicateur afin d'aussi de pointer l'option sélectionné

                if (i == Selection)
                {
                    if (i == 2)
                        selecteur = "\t  \x1b[41m\x1b[37m►  ";      // Affichage spécial fond rouge écrit en blanc pour l'option 2, l'option quitter 
                    else
                        selecteur = "\t  \x1b[47m\x1b[30m►  ";      // Sinon le selecteur est noir sur blanc
                }
                else
                {
                    selecteur = "";                                 // Si le selecteur est sur une option les autres sont en blanc sur noir en normal quoi
                }
                Program.EcrireCentre($"{selecteur}{SelectionActuelle}\x1b[0m"); // Écriture (au centre) de notre selecteur et de l'option actuelle suivi d'une balise de reset format (même fonction que Console.ResetColors();
            }
        }

        public int Deplacement()        // Méthode de déplacement du curseur
        {
            ConsoleKey touche;          // Appel de enum ConsoleKey pour différencier les frappes
            do
            {

                Console.SetCursorPosition(96, 29); // Curseur replacé en position du début de la ligne 2
                AffichageOptions();

                ConsoleKeyInfo info_touche = Console.ReadKey(true);     // Lecture de la frappe utilisateur
                touche = info_touche.Key;                               // Détection de la touche lors de la frappe

                if (touche == ConsoleKey.UpArrow)                       
                {
                    Selection--;                                        // Décrémentation de la valeur de la selection
                    if (Selection == -1)
                        Selection = Options.Length - 1;                 // Si < 0 on passe au dernier membre du tableau
                }
                else if (touche == ConsoleKey.DownArrow)
                {
                    Selection++;                                        // Idem à contrario
                    if (Selection == Options.Length)
                        Selection = 0;                                  // Idem à contrario
                }

            } while (touche != ConsoleKey.Enter);                       // La méthode continue tant que l'utiisateur n'appuie pas sur entrée 
            return Selection;                                           // Et renvoie la selection actuelle
        }
    }
}