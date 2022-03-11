/** Global informations
 * Authors : Marwan K. & Charles A. - Lebrun
 * Github project repository : https://github.com/marwank270/projet_csharp_s2/
 * Author's github : https://github.com/marwank270 & https://github.com/novaxsavestheyear
 **/

using System;
using System.Threading;

namespace Projet_CSharp_S2
{

    static class cc // Classe console color faite maison (inutile aux exercices c'est juste pour le fun et faire plus beau) (Marwan)#{
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

    public static class Stock   // Classe de stockage de constante
    {
        public static char[] fourmis = { '▲', '►', '▼', '◄' };                      // Toutes les formes possible de la fourmi 
        // [deprecated] //public static string[] directions = { "Nord", "Est", "Sud", "Ouest" };      // Toutes les directions possibles de la fourmi
        public static int direction;                                                // Variable régulièrement mise à jour contenant la direction de la fourmi
        public static string[,] matrice_principale;                                 // Variable régulièrement mise à jour contenant la matrice générale de l'algorithme
        public static int[,] matrice_fantome;                                    // Variable régulièrement mise à jour contenant la matrice de couleurs
        public static int[] coordonnees;                                            // Variable régulièrement mise à jour contenant les coordonnées x,y et direction de la fourmi
    }

    /*public struct saved
    {
        public int direction;                                                // Variable régulièrement mise à jour contenant la direction de la fourmi
        public string[,] matrice_principale;                                 // Variable régulièrement mise à jour contenant la matrice générale de l'algorithme
        public int[] coordonnees;                                            // Variable régulièrement mise à jour contenant les coordonnées x,y et direction de la fourmi
    }*/

    class Program
    {
        #region Méthode Outils

        static int SaisieNombre()
        {
            short? input;   // On ne dépassera jamais 32767 comme valeur donc inutile de prendre un int (et prendre un short permet d'optimiser le code)
            bool succes;
            do
            {
                try
                {
                    input = Convert.ToInt16(Console.ReadLine());    // Le code essaye de convertir la saisie et si il réussi il passe la valeur de succes à true
                    succes = true;
                }
                catch                                               // En cas d'echec, on affiche un message d'erreur et on recommence
                {
                    Console.WriteLine($"{cc.badVal} : Vous devez saisir {cc.red}uniquement des nombres{cc.end} ici. Veuillez réessayer avec des nombres.");
                    input = null;                                   // input ne peut pas rester sans valeur, en cas d'erreur comme il n'a toujours pas de valeur on le fait valoir null
                    succes = false;
                }
            } while (input == null && succes == false);

            return (int)input;  // On reconverti input en int pour simplifier le reste du code
        }
        public static string[,] SaisieMatrice()   // Saisie des coordonnées des matrices
        {
            int x, y;
            do
            {
                Console.Write("Saisir la hauteur de la matrice : ");
                x = SaisieNombre();                                     // Saisie des valeurs par l'utilisateur
                Console.Write("\nSaisir la largeur de la matrice : ");
                y = SaisieNombre();

                if (x % 2 == 0 && y % 2 == 0)                           // Vérification de la parité des valeurs
                    Console.WriteLine($"{cc.badVal} : Vous ne pouvez pas saisir {cc.yellow}deux nombres pairs{cc.end} sinon la matrice n'as pas de centre.");
            } while  (x % 2 == 0 && y % 2 == 0);


            string[,] matrice = new string[x, y];                       // Déclaration et initialisation de la matrice
            return matrice;
        }
        static void AffichageMatrice(string[,] matrice)
        {
            //Console.Write(cc.bgWhite + cc.black);     // Passage en blanc de la console pour laisser que la matrice soit de la bonne couleur au départ
            // La classe cc est inutilisable du fait que je n'ai pas prévu de propriété pour détecter la couleur actuelle nous allons donc continuer comme cela :
            // Surtout qu'après reflexion la couleur doit être mise au moment de l'initialisation mdrr

            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                Console.WriteLine();                    // Retours à la ligne lorsque le bord de la matrice est atteint
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    if (Stock.matrice_fantome[i, j] == 0)                       // Si la case est actuellement blanche
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write(matrice[i, j]);                       // Case vide de couleur noire sur blanche

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (Stock.matrice_fantome[i,j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(matrice[i, j]);                       // Case vide de couleur blanche sur noir

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    //Console.Write(matrice[i, j]);       // Dans cette ligne on écrit la case actuelle de notre matrice dans la console
                    
                }
            }

            //Console.Write(cc.end);                    // Ici nous remettons la police et couleurs originelles de la console
        }

        public static int[] PosFourmi(string[,] tab)            // Définition de la matrice comme étant publique afin de la rendre accessible dans toutes les méthodes (donc d'avoir en permanance la position de la fourmi)
        {
            int[] pos = new int[3];                             // Tableau initialisé pour contenir les coordonnées x, y de la fourmi et sa direction 

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == $" {Stock.fourmis[0]} |")  // Si le contenu au coordonnées vaut ce que l'on cherche (Stock.fourmis contient les différentes formes de la fourmi) on lance l'enregistrement des variables
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 1; Stock.direction = 1;    // 1 désigne direction nord (sous la forme de x = 1, y = j, direction = 1)
                    }
                    else if (tab[i, j] == $" {Stock.fourmis[1]} |")
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 2; Stock.direction = 2;    // 2 désigne direction est
                    }
                    else if (tab[i, j] == $" {Stock.fourmis[2]} |")
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 3; Stock.direction = 3;    // 3 désigne direction sud
                    }
                    else if (tab[i, j] == $" {Stock.fourmis[3]} |")
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 4; Stock.direction = 4;    // 4 désigne direction ouest
                    }
                }
            }

            Stock.coordonnees = pos;    // Cette ligne est très importante, elle nous permet d'envoyer les coordonnées et la direction de la fourmi dans une classe Stock qui contient les variables globales du programme
            return pos;
        }
        static void DeplacementFourmi()
        {
            /*int[] position_fourmi = Stock.coordonnees;                                                      // Coordonnées de la fourmi récupérée à partir de la variable globale Stock.coordonnees
            int x = PosFourmi(Stock.matrice_principale)[0];                                                 //
            int y = PosFourmi(Stock.matrice_principale)[1];*/                                                 //
            int x = Stock.coordonnees[0];
            int y = Stock.coordonnees[1];
            int direc = Stock.coordonnees[2];                                                                 

            if (Stock.matrice_fantome[x, y] == 0)  
            {
                if (direc == 1)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // Réécriture du contenu de la case pour le passage en noir   // Problème avec la classe cc

                    SwitchColor(Stock.matrice_principale, x, y);
                    direc = 4;      // Tourne de Nord à Ouest
                    x -= 1;         // Avance vers l'Ouest donc de -1 sur l'axe x
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[3]} |";                                  // Réécriture de la fourmi à sa nouvelle position
                }
                else if (direc == 2)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // ---
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc = 1;      // Tourne d'Est à Nord
                    y += 1;// x- v+ // Monte vers le Nord donc de 1 sur l'axe y
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[0]} |";                                  // --
                }
                else if (direc == 3)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // ---
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc = 2;      // Tourne de Sud à Est
                    x += 1;         // Avance vers l'Est donc de 1 sur l'axe x
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[1]} |";                                  // --
                }
                else if (direc == 4)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // ---
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc = 3;      // Tourne d'Ouest à Sud
                    y -= 1;// x+ v- // Descend vers le Sud donc de -1 sur l'axe y
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[2]} |";                                  // --
                }
            }
            else if (Stock.matrice_fantome[x, y] == 1)       // Si la case est blanche
            {
                if (direc == 1)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc += 1;     // Tourne de Nord à Est
                    x += 1;         // Avance vers l'Est donc de 1 sur l'axe x
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[1]} |";
                }
                else if (direc == 2)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc += 1;     // Tourne de Est à Sud
                    y -= 1;         // Descend vers le Sud donc de -1 sur l'axe y
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[2]} |";
                }
                else if (direc == 3)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc += 1;     // Tourne de Sud à Ouest
                    x -= 1;         // Avance vers l'Ouest donc de -1 sur l'axe x
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[3]} |";
                }
                else if (direc == 4)
                {
                    //Stock.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Stock.matrice_principale, x, y);
                    direc = 1;      // Tourne de Ouest à Nord
                    y += 1;         // Monte vers le Nord donc de 1 sur l'axe x
                    Stock.matrice_principale[x, y] = $" {Stock.fourmis[0]} |";
                }

                Stock.coordonnees[0] = x;               // Mise à jour des variables globales en adéquation avec les changements des lignes d'au dessus
                Stock.coordonnees[1] = y;               //
                Stock.coordonnees[2] = direc;           //
            }

            AffichageMatrice(Stock.matrice_principale);

            string dirFourmi = "";
            switch (direc)
            {
                case 1:
                    dirFourmi = "Nord";
                    break;
                case 2:
                    dirFourmi = "Est";
                    break;
                case 3:
                    dirFourmi = "Sud";
                    break;
                case 4:
                    dirFourmi = "Ouest";
                    break;
            }
            Console.WriteLine($"\n\nLa fourmi est actuellement aux coordonnées : {x}, {y} et dans la direction {dirFourmi}");
            //VerificationFond();
            Console.WriteLine(Console.ForegroundColor + "\n" + Console.BackgroundColor);
        }

        static void SwitchColor(string[,] matrice, int x, int y)
        {
            if (Stock.matrice_fantome[x, y] == 0)
            {
                matrice[x, y] = "   |";
                Stock.matrice_fantome[x, y] = 1;
            }
            else if (Stock.matrice_fantome[x, y] == 1)
            {
                matrice[x, y] = "   |";
                Stock.matrice_fantome[x, y] = 0;
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
            Console.Write("Que voulez vous faire ? ");
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

                case 2:
                    Console.Clear();
                    Console.WriteLine("Under construction");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine($"{cc.badVal} : Le nombre saisi n'est pas dans les bornes {cc.red}[0 ; 2]{cc.end}. Veuillez réessayer.");
                    Main();
                    break;
            }
        }

        static void FourmiLangton()
        {
            #region Initialisation de la Matrice

            string[,] mat = SaisieMatrice();                // Déclaration et intialisation de la matrice principale
            int[,] ghost_mat = new int[mat.GetLength(0), mat.GetLength(1)]; // Déclaration et initialisation de la matrice de couleurs
            Stock.matrice_principale = mat;                 // Copie de l'état actuel de la matrice dans la classe Stock pour la rendre accessible
            Stock.matrice_fantome = ghost_mat;

            Console.BackgroundColor = ConsoleColor.White;   // Passage de la couleur du fond au blanc 
            Console.ForegroundColor = ConsoleColor.Black;   // Passage de la couleur des caractères en noirs (faut bien que ce soit lisible)

            for (int i = 0; i < mat.GetLength(0); i++)  
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = "   |";             // Remplissage de la matrice avec de quoi faire des cotés
                }
            }

            Console.ResetColor();   // Simple inversion de ce qui a été fait plus haut

            AffichageMatrice(mat);                  // Test d'affichage de la matrice

            Console.WriteLine("\n\n\x1b[32mMatrice initialisée\x1b[0m. Appuyez sur une touche continuez ...");

            #endregion Initialisation de la Matrice

            Console.ReadKey();
            Console.Clear();

            #region Initialisation de la fourmi

            Random direction = new Random();
            int dir = direction.Next(1, 4);         // Choix aléatoire de la direction de la foumi (1, 4) pour Nord Est Sud Ouest

            char fourmi = ' ';                      // Initialisation de la fourmi qui sera dans la matrice

            if (dir == 1)
                fourmi = Stock.fourmis[0];// Stock.coordonnees[2] = 0;      // Direction Nord (Stock.fourmis contient les différentes formes de la fourmi)
            if (dir == 2)
                fourmi = Stock.fourmis[1];// Stock.coordonnees[2] = 1;      // Direction Est
            if (dir == 3)
                fourmi = Stock.fourmis[2];// Stock.coordonnees[2] = 2;      // Direction Sud
            if (dir == 4)
                fourmi = Stock.fourmis[3];// Stock.coordonnees[2] = 3;      // Direction Ouest

            mat[mat.GetLength(0) / 2, mat.GetLength(1) / 2] = $" {fourmi} |";   // Insertion de la fourmi au centre de la matrice avec une direction aléatoire

            #endregion Initialisation de la fourmi

            AffichageMatrice(mat);

            int direc = PosFourmi(mat)[2];
            string dirFourmi = "";
            switch(direc)
            {
                case 1:
                    dirFourmi = "Nord";
                    break;
                case 2:
                    dirFourmi = "Est";
                    break;
                case 3:
                    dirFourmi = "Sud";
                    break;
                case 4:
                    dirFourmi = "Ouest";
                    break;
            }

            Console.WriteLine($"\n\nLa fourmi est actuellement aux coordonnées : {PosFourmi(mat)[0]}, {PosFourmi(mat)[1]} et dans la direction {dirFourmi}");

            while (Stock.coordonnees[0] < mat.GetLength(0) && Stock.coordonnees[1] < mat.GetLength(1) )
            {
                Console.Clear();
                DeplacementFourmi();

                if (Stock.coordonnees[0] != PosFourmi(mat)[0] || Stock.coordonnees[1] != PosFourmi(mat)[1] || Stock.coordonnees[2] != PosFourmi(mat)[2])    // Ne devrait jamais s'executer normalement
                    Console.WriteLine($"{cc.wrongFlag} Attention les coordonnées son faussées, échec de la simulation.\nSelon la méthode {cc.red}PosFourmi(string[,] matrice){cc.end} : {cc.cyan}x = {PosFourmi(mat)[0]}; y = {PosFourmi(mat)[1]},{cc.end} de direction {cc.cyan}{PosFourmi(mat)[2]}\nSelon la variable globale {cc.red}Stock.coordonnees[n]{cc.end} : {cc.cyan}x = {Stock.coordonnees[0]}; y = {Stock.coordonnees[1]},{cc.end} de direction {cc.cyan}{Stock.coordonnees[2]}"); 

                //Thread.Sleep(1);      // Pause de l'execution du programme d'une durée de 500 ms soit d'une demi seconde
            }
        }       
    }
}
