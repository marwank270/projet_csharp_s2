/** Global informations
 * Authors : Marwan K. & Charles A. - Lebrun
 * Github project repository : https://github.com/marwank270/projet_csharp_s2/
 * Author's github : https://github.com/marwank270 & https://github.com/novaxsavestheyear
 **/


// test
using System;
using System.Linq;                          // Nécessaire pour les Enummerable
using System.Threading;                     // Nécessaire pour les Thread.Sleep(t);
using System.Runtime.InteropServices;       // Nécessaire pour lire les dll et les process (utile au fullscreen)

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

    /*public struct saved
    {
        public int direction;                                                // Variable régulièrement mise à jour contenant la direction de la fourmi
        public string[,] matrice_principale;                                 // Variable régulièrement mise à jour contenant la matrice générale de l'algorithme
        public int[] coordonnees;                                            // Variable régulièrement mise à jour contenant les coordonnées x,y et direction de la fourmi
    }*/

    class Program
    {
        #region Méthode Menu

        public static void EcrireCentre(string texte)       // Soimple méthode qui centre le texte a l'aide de String.Format et le code escape \u0001[1000D
        {
            Console.Write(String.Format("[1000D\n{0," + ((Console.WindowWidth / 2 + 5/* +5 pour aérer le texte */) + (texte.Length / 2)) + "}", texte));
        }

        #endregion Méthode Menu

        #region Méthode Outils

        static int SaisieNombre()
        {
            short? input;   // On ne dépassera jamais 32767 comme valeur donc inutile de prendre un int (et prendre un short permet d'optimiser le code)
            bool succes;
            do
            {
                try
                {
                    Console.CursorVisible = true;
                    input = Convert.ToInt16(Console.ReadLine());    // Le code essaye de convertir la saisie et si il réussi il passe la valeur de succes à true
                    succes = true;
                    Console.CursorVisible = false;
                }
                catch                                               // En cas d'echec, on affiche un message d'erreur et on recommence
                {
                    EcrireCentre($"{cc.badVal} : Vous devez saisir {cc.red}uniquement des nombres{cc.end} ici. Veuillez réessayer avec des nombres entiers : ");
                    input = null;                                   // input ne peut pas rester sans valeur, en cas d'erreur comme il n'a toujours pas de valeur on le fait valoir null
                    succes = false;
                }
            } while (input == null && succes == false);

            return (int)input;  // On reconverti input en int pour simplifier le reste du code
        }
        public static string[,] SaisieMatrice()   // Saisie des coordonnées des matrices
        {
            Console.CursorVisible = true;

            int x, y;
            do
            {
                EcrireCentre("Saisir la hauteur de la matrice : ");
                x = SaisieNombre();                                     // Saisie des valeurs par l'utilisateur
                EcrireCentre("Saisir la largeur de la matrice : ");
                y = SaisieNombre();

                if (x % 2 == 0 && y % 2 == 0)                           // Vérification de la parité des valeurs
                {
                    Console.Clear();
                    EcrireCentre($"{cc.wrongFlag} : Vous ne pouvez pas saisir {cc.yellow}deux nombres pairs{cc.end} sinon la matrice n'as pas de centre.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (x <= 3 || y <= 3)                                   // Vérification de la qualité des valeurs
                {
                    Console.Clear();
                    EcrireCentre($"{cc.wrongFlag} : Vous ne pouvez pas saisir {cc.yellow}de matrice inférieure à [3,3]{cc.end} sinon la simulation ne se {cc.red}produit que sur 1 tour{cc.end}");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (y >= 55)                                            // Vérification de la qualité des valeurs
                {
                    Console.Clear();
                    EcrireCentre($"{cc.infoFlag} : La Largeur de la matrice ne doit pas dépasser les 55 de largeur ou elle débordera sur les informations");
                    Console.WriteLine();
                    Console.WriteLine();
                }

            } while (x % 2 == 0 && y % 2 == 0 && x <= 3 || y == 3 && y > 55); // y > 55 déborde sur le menu du coté

            
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
                Console.SetCursorPosition(Console.WindowWidth / 2 - matrice.GetLength(1) * 3/*nombre de caractère par cases*/ / 2, 10 /*marge de base en partant du haut*/ + i);
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    if (Ant.matrice_fantome[i, j] == 0)                       // Si la case est actuellement blanche
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write(matrice[i, j]);                       // Case vide de couleur noire sur blanche

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (Ant.matrice_fantome[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(matrice[i, j]);                       // Case vide de couleur blanche sur noir

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
            }
        }
        public static int[] PosFourmi(string[,] tab)            // Définition de la matrice comme étant publique afin de la rendre accessible dans toutes les méthodes (donc d'avoir en permanance la position de la fourmi)
        {
            int[] pos = new int[3];                             // Tableau initialisé pour contenir les coordonnées x, y de la fourmi et sa direction 

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == $" {Ant.fourmis[0]} ")  // Si le contenu au coordonnées vaut ce que l'on cherche (Ant.fourmis contient les différentes formes de la fourmi) on lance l'enregistrement des variables
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 1; Ant.direction = 1;    // 1 désigne direction nord (sous la forme de x = 1, y = j, direction = 1)
                    }
                    else if (tab[i, j] == $" {Ant.fourmis[1]} ")
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 2; Ant.direction = 2;    // 2 désigne direction est
                    }
                    else if (tab[i, j] == $" {Ant.fourmis[2]} ")
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 3; Ant.direction = 3;    // 3 désigne direction sud
                    }
                    else if (tab[i, j] == $" {Ant.fourmis[3]} ")
                    {
                        pos[0] = i; pos[1] = j; pos[2] = 4; Ant.direction = 4;    // 4 désigne direction ouest
                    }
                }
            }

            Ant.coordonnees = pos;    // Cette ligne est très importante, elle nous permet d'envoyer les coordonnées et la direction de la fourmi dans une classe Ant qui contient les variables globales du programme
            return pos;
        }
        public static void DeplacementFourmi()
        {
            /*int[] position_fourmi = Ant.coordonnees;                                                      // Coordonnées de la fourmi récupérée à partir de la variable globale Ant.coordonnees
            int x = PosFourmi(Ant.matrice_principale)[0];                                                 //
            int y = PosFourmi(Ant.matrice_principale)[1];*/                                                 //
            int x = Ant.coordonnees[0];
            int y = Ant.coordonnees[1];
            int direc = Ant.coordonnees[2];

            if (Ant.matrice_fantome[x, y] == 0)
            {
                if (direc == 1)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // Réécriture du contenu de la case pour le passage en noir   // Problème avec la classe cc

                    SwitchColor(Ant.matrice_principale, x, y);
                    direc = 4;      // Tourne de Nord à Ouest
                    x -= 1;         // Avance vers l'Ouest donc de -1 sur l'axe x
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[3]} ";                                  // Réécriture de la fourmi à sa nouvelle position
                }
                else if (direc == 2)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // ---
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc = 1;      // Tourne d'Est à Nord
                    y += 1;// x- v+ // Monte vers le Nord donc de 1 sur l'axe y
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[0]} ";                                  // --
                }
                else if (direc == 3)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // ---
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc = 2;      // Tourne de Sud à Est
                    x += 1;         // Avance vers l'Est donc de 1 sur l'axe x
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[1]} ";                                  // --
                }
                else if (direc == 4)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";     // ---
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc = 3;      // Tourne d'Ouest à Sud
                    y -= 1;// x+ v- // Descend vers le Sud donc de -1 sur l'axe y
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[2]} ";                                  // --
                }
                Ant.coordonnees[0] = x;               // Mise à jour des variables globales en adéquation avec les changements des lignes d'au dessus
                Ant.coordonnees[1] = y;               //
                Ant.coordonnees[2] = direc;           //
            }
            else if (Ant.matrice_fantome[x, y] == 1)       // Si la case est blanche
            {
                if (direc == 1)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc += 1;     // Tourne de Nord à Est
                    x += 1;         // Avance vers l'Est donc de 1 sur l'axe x
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[1]} ";
                }
                else if (direc == 2)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc += 1;     // Tourne de Est à Sud
                    y -= 1;         // Descend vers le Sud donc de -1 sur l'axe y
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[2]} ";
                }
                else if (direc == 3)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc += 1;     // Tourne de Sud à Ouest
                    x -= 1;         // Avance vers l'Ouest donc de -1 sur l'axe x
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[3]} ";
                }
                else if (direc == 4)
                {
                    //Ant.matrice_principale[x, y] = $"{cc.bgBlack}   {cc.end}{cc.bgWhite}{cc.black}|";
                    SwitchColor(Ant.matrice_principale, x, y);
                    direc = 1;      // Tourne de Ouest à Nord
                    y += 1;         // Monte vers le Nord donc de 1 sur l'axe x
                    Ant.matrice_principale[x, y] = $" {Ant.fourmis[0]} ";
                }

                Ant.coordonnees[0] = x;               // Mise à jour des variables globales en adéquation avec les changements des lignes d'au dessus
                Ant.coordonnees[1] = y;               //
                Ant.coordonnees[2] = direc;           //
            }
            AffichageMatrice(Ant.matrice_principale);
        }

        static void SwitchColor(string[,] matrice, int x, int y)
        {
            if (Ant.matrice_fantome[x, y] == 0)
            {
                matrice[x, y] = "   ";
                Ant.matrice_fantome[x, y] = 1;
            }
            else if (Ant.matrice_fantome[x, y] == 1)
            {
                matrice[x, y] = "   ";
                Ant.matrice_fantome[x, y] = 0;
            }

        }
        /*static int[,] GenerateFourmi(int nbfourmi)
        {
            int[,] mat = SaisieMatrice();
            for (int i = 0; i <= nbfourmi; i++)
            {
                Random a = new Random();
                int x = x.Next(0, mat.GetLength(0)-1);
                int y = y.Next(0, mat.GetLength(1)-1);

                // Ant.matrice_principale[i, j] = "   |"; // case de la matrice vide
                // Ant.matrice_principale[i, j] = $" {Ant.fourmis[Ant.coordonnees[2]] |"; // case de la matrice avec la foumi dans la bonne direction
            }
        }*/


        #endregion Méthode Outils

        #region Fullscreen Stuff
        [DllImport("kernel32.dll", ExactSpelling = true)]                           // Ce code n'est pas le notre mais nous savons comment il fonctionne et le comprenons
        private static extern IntPtr GetConsoleWindow();                            // Il provient de cette source : https://www.codegrepper.com/code-examples/csharp/maximize+window+c%23
        private static IntPtr ThisConsole = GetConsoleWindow();                     // Ainsi que les deux première lignes du main
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        #endregion Fullscreen Stuff

        static void Main()
        {
            #region Préparation

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);     // Agrandi d'abord la fenêtre au maximum
            ShowWindow(ThisConsole, MAXIMIZE);                                                  // Puis la met en plein écran
            Console.Title = "La fourmi de Langton. Par Marwan Kaouachi & Charles Albert-Lebrun";// Titre de la fenêtre
            Console.OutputEncoding = System.Text.Encoding.UTF8;                                 // Prévention des problèmes de compatibilités
            Console.CursorVisible = false;

            Thread ThreadPrincipal = new Thread(FourmiLangton)                                  // Création d'un objet Thread
            {
                Priority = ThreadPriority.AboveNormal                                           // Surclassement de la priorité du processus le plus lourd 
            };                                 

            #endregion Préparation

            string ASCII = @"           
                                                ╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
                                                ║                                                                                                                                                   ║
                                                ║        ,d8888b                                          d8,          d8b             d8b                                                          ║
                                                ║       88P'                                            `8P           88P             88P                                  d8P                      ║
                                                ║    d888888P                                                        d88             d88                                d888888P                    ║
                                                ║     ?88'     d8888b ?88   d8P  88bd88b  88bd8b,d88b   88b     d888888   d8888b    888   d888b8b    88bd88b  d888b8b    ?88'   d8888b   88bd88b    ║
                                                ║     88P     d8P' ?88d88   88   88P'  `  88P'`?8P'?8b  88P    d8P' ?88  d8b_,dP    ?88  d8P' ?88    88P' ?8bd8P' ?88    88P   d8P' ?88  88P' ?8b   ║
                                                ║    d88      88b  d88?8(  d88  d88      d88  d88  88P d88     88b  ,88b 88b         88b 88b  ,88b  d88   88P88b  ,88b   88b   88b  d88 d88   88P   ║
                                                ║   d88'      `?8888P'`?88P'?8bd88'     d88' d88'  88bd88'     `?88P'`88b`?888P'      88b`?88P'`88bd88'   88b`?88P'`88b  `?8b  `?8888P'd88'   88b   ║
                                                ║                                                                                                             )88                                   ║
                                                ║                                                                                                            ,88P                                   ║
                                                ║                                                                                                        `?8888P                                    ║
                                                ║                                                                                                                                                   ║
                                                ╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝   ";

            Console.WriteLine(String.Format($"\n{cc.yellow} \t {ASCII} {cc.end}"));             // Écris en jaune

            Console.SetCursorPosition(Console.WindowWidth / 2, 60);                             // Place le curseur en bas de l'écran pour la barre de chargement
            for (var i = 0; i < 100; i++)                                                       // Barre de chargement inspirée par cette source : https://www.lihaoyi.com/post/BuildyourownCommandLinewithANSIescapecodes.html
            {                                                                                   // Traduite en cs par nos soins
                Thread.Sleep(1);                                                                // 1ms d'attente pour que la transition soit visible à l'oeil nu
                var largeur = (i + 1) / 4;
                var rempplissage = new string('█', largeur);                                    // La string rempplissage se met à jour a chaque tour de la boucle en ajoutant "largeur" x "█"
                var espaces = new string(' ', 25 - largeur);                                    // Idem avec ' ' et "25 - largeur"
                var barre = $"\t\t│{rempplissage}{espaces}│{cc.bgYellow}{cc.black}  {i + 1}  %{cc.end} ";// Mise à jour a chaques tour de la barre avec le remplissage + les espaces les couleurs et le %
                Console.Write(String.Format("[1000D{0," + ((Console.WindowWidth / 2) + (barre.Length / 2)) + "}", barre));
            }

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 10);  // Position du curseur au centre (mais plus haut (-10) pour préparer l'écriture du menu

            string titre = "Choisissez une option avec les fleches directionnelles :\n\n\n";
            string[] options = { "--------  Fourmi de Langton  ---------\n", "-------- Fourmi de Langton V2 --------\n\n", "QUITTER " };

            Menu menu = new Menu(titre, options);       // Création/Écriture du menu
            int choix_menu = menu.Deplacement();        // Traitement des touches

            switch (choix_menu)
            {

                case 0:
                    Console.Clear();
                    FourmiLangton();                    // Redirection vers la méthode de suite du programme
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("Under construction");
                    break;

                case 2:                                 // Cas 2 : Quitter
                    Console.Clear();
                    Console.WriteLine($"Merci d'avoir utilisé notre programme ! À bientôt ! {cc.red}<3{cc.end}");
                    Thread.Sleep(3000);                 // Temps d'attente de 3s avant de quitter pour que ce ne soit pas sec pour l'utilisateur
                    Environment.Exit(0);                // Permet de quitter le programme "proprement" avec le code 0 qui indique que le programme s'est terminé sans erreur
                    break;

                default:                                // Ne devrais jamais s'afficher avec le menu flêché mais soyons prudent et evitons les crash potentiels
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
            Ant.matrice_principale = mat;                   // Copie de l'état actuel de la matrice dans la classe Ant pour la rendre accessible
            Ant.matrice_fantome = ghost_mat;

            Console.BackgroundColor = ConsoleColor.White;   // Passage de la couleur du fond au blanc 
            Console.ForegroundColor = ConsoleColor.Black;   // Passage de la couleur des caractères en noirs (faut bien que ce soit lisible)

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = "   ";             // Remplissage de la matrice avec de quoi faire des cotés
                }
            }

            Console.ResetColor();   // Simple inversion de ce qui a été fait plus haut

            AffichageMatrice(mat);                  // Test d'affichage de la matrice

            Console.WriteLine("\n");
            EcrireCentre("\x1b[32mMatrice initialisée\x1b[0m. Appuyez sur une touche continuez ...");
            Console.ReadKey();
            Console.Clear();

            #endregion Initialisation de la Matrice

            Ant.Spawn(mat, mat.GetLength(0) / 2, mat.GetLength(1) / 2);        // Initialisation de la matrice principale

            int direc = PosFourmi(mat)[2];  // Recherche de la position de la fourmi à travers la matrice pour déterminer sa position

            if (direc == null)              // Gestion d'une erreur d'array vide à l'initialisation
                direc = Ant.direction;

            //ConsoleKeyInfo info_touche = Console.ReadKey(true);             // Lecture de la frappe utilisateur
            //ConsoleKey touche = info_touche.Key;                            // Détection de la touche lors de la frappe

            int tours = 1;
            bool run = true;
            Ant.running = run;

            while (Ant.coordonnees[0] != mat.GetLength(0) || Ant.coordonnees[1] != mat.GetLength(1))
            {
                //Console.Clear(); // Mieux sans (vu que nous avons géré la matrice pour qu'elle garde les même positions
                Menu.SideInfo();
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Ant.running = false;
                        Console.SetCursorPosition(0, 10);
                        Console.Write($"{cc.bgRed}[    ÉTAT   ] : En pause...{cc.end}");
                        while (Console.ReadKey().Key != ConsoleKey.Spacebar)
                        {
                            run = false;

                            if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                Main();
                                break;
                            }
                        }
                    }
                    /*else if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        string MainMenu = $"{cc.bgRed}{cc.white}Voulez vous retourner au menu principal ?";
                        string confirmation = $"ECHAP : Non / ENTRÉE : Oui{cc.end}";
                        Console.SetCursorPosition(Console.WindowWidth / 2 - MainMenu.Length / 2, Console.WindowHeight / 2);
                        Console.Write(MainMenu);
                        Console.SetCursorPosition(Console.WindowWidth / 2 - confirmation.Length / 2, Console.WindowHeight / 2 + 1);
                        Console.Write(confirmation);

                        while (Console.ReadKey().Key != ConsoleKey.Escape)
                        {
                            run = false;

                            if (Console.ReadKey().Key != ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Main();
                                break;
                            }
                        }
                    }*/
                }
                Ant.running = run;
                DeplacementFourmi();
                tours++;
                Ant.step = tours;
                if (Menu.count_spinner >= 3)
                    Menu.count_spinner = -1;
                Menu.count_spinner += 1;
                Thread.Sleep(10);
            }
        }
    }
}
