using System;

namespace Projet_CSharp_S2
{
    class Menu
    {
        private string Question;        // String qui va contenir la question à poser dans le menu (en private pour être accessible partout dans la classe Menu seulement
        private string[] Options;       // Tableau destiné à contenir les options possible
        private int Selection;          // Int qui contiendra la sélection actuelle
        public static int count_spinner;

        public Menu(string question, string[] options_menu)     // Struc Menu pour les variables du menu
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
                        selecteur = $"\t  {cc.bgRed}{cc.white}►  ";      // Affichage spécial fond rouge écrit en blanc pour l'option 2, l'option quitter 
                    else
                        selecteur = $"\t  {cc.bgWhite}{cc.black}►  ";      // Sinon le selecteur est noir sur blanc
                }
                else
                {
                    selecteur = "";                                 // Si le selecteur est sur une option les autres sont en blanc sur noir en normal quoi
                }
                Program.EcrireCentre($"{selecteur}{SelectionActuelle}{cc.end}"); // Écriture (au centre) de notre selecteur et de l'option actuelle suivi d'une balise de reset format (même fonction que Console.ResetColors();
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

        public static void SideInfo()
        {
            int x = Ant.coordonnees[0], y = Ant.coordonnees[1], direc = Ant.coordonnees[2];

            string dirFourmi = "";

            switch (direc)
            {
                case 1:
                    dirFourmi = "Nord ";
                    break;
                case 2:
                    dirFourmi = "Est  ";
                    break;
                case 3:
                    dirFourmi = "Sud  ";
                    break;
                case 4:
                    dirFourmi = "Ouest";
                    break;
            }

            string X = x < 10 ? $"0{x}" : x.ToString();                // x < 10 on ajoute le 0 sinon on le touche pas (pour eviter que les coordonnées se décallent en permanance)
            string Y = y < 10 ? $"0{y}" : y.ToString();                // Idem avec y
            string[] spinner = { "/", "-", "\\", "|" };

            Console.SetCursorPosition(0, 10);
            Console.Write($"{cc.bgGreen}[    ÉTAT   ] : En cours {spinner[count_spinner]} {cc.end}");
            Console.SetCursorPosition(0, 11);
            Console.Write($"{cc.bgYellow}{cc.black}[  POSITION ] : X : {X} | Y : {Y} {cc.end}");
            Console.SetCursorPosition(0, 12);
            Console.Write($"[ DIRECTION ] : {Ant.fourmis[direc - 1]} : {dirFourmi} ");
            Console.SetCursorPosition(0, 13);
            Console.Write($"[   ÉTAPE   ] : {cc.rod}{Ant.step}{cc.end}");
            Console.SetCursorPosition(0, 17);
            Console.Write($"{cc.yellow}[   PAUSE  ] : {cc.end}ESPACE");
            Console.SetCursorPosition(0, 18);
            Console.Write($"{cc.red}[  QUITTER ] : {cc.end}ECHAP (x2 en pause)");


        }

        public static void SideInfov2()
        {
            int i = Antv2.index_fourmi_track, x = Antv2.fourmis[i][0], y = Antv2.fourmis[i][1], direc = Antv2.fourmis[i][2], age = Antv2.fourmis[i][3];

            string dirFourmi = "";

            switch (direc)
            {
                case 1:
                    dirFourmi = "Nord ";
                    break;
                case 2:
                    dirFourmi = "Est  ";
                    break;
                case 3:
                    dirFourmi = "Sud  ";
                    break;
                case 4:
                    dirFourmi = "Ouest";
                    break;
            }

            string X = x < 10 ? $"0{x}" : x.ToString();                // x < 10 on ajoute le 0 sinon on le touche pas (pour eviter que les coordonnées se décallent en permanance)
            string Y = y < 10 ? $"0{y}" : y.ToString();                // Idem avec y
            string[] spinner = { "/", "-", "\\", "|" };

            Console.SetCursorPosition(0, 10);
            Console.Write($"{cc.bgGreen}[    ÉTAT   ] : En cours {spinner[count_spinner]} {cc.end}");
            Console.SetCursorPosition(0, 11);
            Console.Write($"{cc.bgYellow}{cc.black}[  POSITION ] : X : {X} | Y : {Y} {cc.end}");
            Console.SetCursorPosition(0, 12);
            Console.Write($"[ DIRECTION ] : {Antv2.fourmis[i][direc - 1]} : {dirFourmi} ");
            Console.SetCursorPosition(0, 13);
            Console.Write($"[   ÉTAPE   ] : {cc.rod}{Ant.step}{cc.end}");
            Console.SetCursorPosition(0, 14);
            Console.Write($"[    AGE    ] : Fourmi n°{cc.green}{i}{cc.end} : {age}");
            Console.SetCursorPosition(0, 17);
            Console.Write($"{cc.yellow}[   PAUSE  ] : {cc.end}ESPACE");
            Console.SetCursorPosition(0, 18);
            Console.Write($"{cc.red}[  QUITTER ] : {cc.end}ECHAP (x2 en pause)");


        }
    }
}