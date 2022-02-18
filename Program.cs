/** Global informations
 * Authors : Marwan K. & Charles A. - Lebrun
 * Github project repository : https://github.com/marwank270/projet_csharp_s2/
 * Authors githubs : https://github.com/marwank270 & https://github.com/novaxsavestheyear
 **/

using System;
using System.Threading;

namespace Projet_CSharp_S2
{

    static class cc // Classe console color faite maison (inutile aux exercices c'est juste pour le fun et faire plus beau)
    {
        #region ConsoleColor
        /*
         * J'assigne de façon manuelle les constante des couleurs a des codes de formatage pour la console
         * En espérant que ca ne gène pas, c'est un petit plus et perso je trouve ça plus esthétique
         */

        public const string end = "\x1b[0m"; // Balise fermante de la modification de police et de couleur

        public const string bold = "\x1b[1m"; // Balise gras
        public const string rod = "\x1b[2m"; // Balise "désactivé" 
        public const string ita = "\x1b[3m"; // Balise italique
        public const string under = "\x1b[4m"; // Balise souligner
        public const string inver = "\x1b[7m"; // Balise "upside down"
        public const string disab = "\x1b[9m"; // Balise rayé

        public const string black = "\x1b[30m"; // Balise police noir
        public const string bgBlack = "\x1b[40m"; // Balise fond noir
        public const string red = "\x1b[31m"; // Balise police rouge
        public const string bgRed = "\x1b[41m"; // Balise fond rouge
        public const string green = "\x1b[32m"; // Balise police vert
        public const string bgGreen = "\x1b[42m"; // Balise fond vert
        public const string yellow = "\x1b[33m"; // Balise police jaune
        public const string bgYellow = "\x1b[43m"; // Balise fond jaune
        public const string blue = "\x1b[34m"; // Balise police bleu
        public const string bgBlue = "\x1b[44m"; // Balise fond bleu
        public const string purple = "\x1b[35m"; // Balise police violet
        public const string bgPurple = "\x1b[45m"; // Balise fond violet
        public const string cyan = "\x1b[36m"; // Balise police cyan
        public const string bgCyan = "\x1b[46m"; // Balise fond cyan
        public const string white = "\x1b[37m"; // Balise police blanche
        public const string bgWhite = "\x1b[47m"; // Balise fond blanche

        public const string lightPurple = "\x1b[38;2;129;10;209m";
        public const string bgLightPurple = "\x1b[48;2;129;10;209m";

        public const string warnFlag = bgRed + "[ ! ]" + end;
        public const string wrongFlag = bgYellow + "[ ? ]" + end;
        public const string infoFlag = bgBlue + "[ i ]" + end;

        public const string closeConsole = infoFlag + " Au revoir et à bientôt !";
        public const string badVal = wrongFlag + " Il semble que vous n'avez pas saisis une valeur conforme.";

        /*
         Traduit depuis un fichier .js que j'ai fais pour un projet personnel (https://pastebin.com/nLVM6aR6) 
         Je sais que C# embarque la fonction ConsoleColor mais elle fonctionne différement selon les version alors je préfère utiliser Les codes d'escape ANSI, de plus ca me fait un peu d'entraineent
         */
        #endregion ConsoleColor
    }
    class Program
    {
        #region Méthode Outils

        static int SaisieNombre()
        {
            short? input;   // On ne dépassera jamais 32767 comme valeur donc inutile de prendre un int
            bool succes;
            do
            {
                try
                {
                    input = Convert.ToInt16(Console.ReadLine());    // Le code essaye de convertir la saisie et si il réussi il passe la valeur de succes à true
                    succes = true;
                }
                catch
                {
                    Console.WriteLine($"{cc.badVal} : Vous devez saisir {cc.red}uniquement des nombres{cc.end} ici. Veuillez réessayer avec des nombres.");
                    input = null;
                    succes = false;
                }
            } while (input == null && succes == false);

            return (int)input;  // On reconverti input en int pour simplifier le reste du code
        }
        static int[,] SaisieMatrice()   // Saisie des coordonnées des matrices
        {
            int x, y;
            do
            {
                x = SaisieNombre();     // Saisie des valeurs
                y = SaisieNombre();

                if (x % 2 == 0 && y % 2 == 0)   // Vérification de la parité des valeurs
                    Console.WriteLine($"{cc.badVal} : Vous ne pouvez pas saisir {cc.yellow}plusieurs nombres pairs{cc.end} à cause du centre.");
            } while  (x % 2 == 0 && y % 2 == 0);
            

            int[,] matrice = new int[x, y];// Déclaration et initialisation de la matrice
            return matrice;
        }
        static void AffichageMatrice(string[,] matrice)
        {
            /*int x = matrice.GetLength(0);
            int y = matrice.GetLength(1);*/

            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(matrice[i, j]);
                    
                }
            }
        }

        #endregion Méthode Outils

        static void Main()
        {
            
            Console.WriteLine(@"  _____                          _       _        _                      _              
 |  ___|__  _   _ _ __ _ __ ___ (_)   __| | ___  | |    __ _ _ __   __ _| |_ ___  _ __  
 | |_ / _ \| | | | '__| '_ ` _ \| |  / _` |/ _ \ | |   / _` | '_ \ / _` | __/ _ \| '_ \ 
 |  _| (_) | |_| | |  | | | | | | | | (_| |  __/ | |__| (_| | | | | (_| | || (_) | | | |
 |_|  \___/ \__,_|_|  |_| |_| |_|_|  \__,_|\___| |_____\__,_|_| |_|\__, |\__\___/|_| |_|
                                                                   |___/                ");

            int choix_menu;

            Console.WriteLine("\n0: Quitter le programme\n\n1: La fourmi de Langton - 1ère Partie.\n2: La fourmi de Langton V2 - 2ème Partie\n");
            Console.WriteLine("Que voulez vous faire ?");

            /*do
            {
                choix_menu = SaisieNombre();
                //if (choix_menu < 0 || choix_menu > 2)
                      //Console.WriteLine($"{cc.badVal} : Le nombre saisi n'est pas dans les bornes {cc.red}[0 ; 2]{cc.end}.");   // Gestion de l'erreur dans le default du switch
            } while (choix_menu < 0 || choix_menu > 2);*/

            choix_menu = SaisieNombre();

            switch (choix_menu) {

                case 0:                     // Cas 0 : Quitter
                    Console.Clear();
                    Console.WriteLine("Merci d'avoir utilisé notre programme ! À bientôt !");
                    Thread.Sleep(3000);     // Temps d'attente de 3s avant de quitter pour que ce ne soit pas sec pour l'utilisateur
                    Environment.Exit(0);    // Permet de quitter le programme "proprement" avec le code 0 qui indique que le programme s'est terminé sans erreur
                    break;

                case 1:
                    Console.Clear();
                    FourmiLangton();        // Redirection vers la méthode de suite du programme
                    break;

                /*case 2:
                    Console.Clear();
                    
                    break;*/

                default:
                    Console.Clear();
                    Console.WriteLine($"{cc.badVal} : Le nombre saisi n'est pas dans les bornes {cc.red}[0 ; 2]{cc.end}.");
                    Main();
                    break;
            }
        }

        static void FourmiLangton()
        {
            string[,] mat = new string[19, 20];     // Déclaration et intialisation de la matrice qui sera utilisée.

            for (int i = 0; i < mat.GetLength(0); i++)  
                for (int j = 0; j < mat.GetLength(1); j++)
            {
                {
                    mat[i, j] = "  |";              // Remplissage de la mattrice avec de quoi faire des cotés.
                    }
            }

            Console.Write(cc.bgWhite + cc.black);
            AffichageMatrice(mat);                  // Test d'affichage de la matrice
            Console.Write(cc.end);

            mat[19 / 2, 20 / 2] = "X";              // Tentative de cibler le millieu de la matrice

            Console.ReadKey();
        }

       
    }
}
