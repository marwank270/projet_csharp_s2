using System;

namespace Projet_CSharp_S2
{
    class Ant
    {
        #region Variables Globales
        public static char[] fourmis = { '▲', '►', '▼', '◄' };                      // Toutes les formes possible de la fourmi 
        // [deprecated] public static string[] directions = { "Nord", "Est", "Sud", "Ouest" };      // Toutes les directions possibles de la fourmi
        // [deprecated] public static int direction;                                                // Variable régulièrement mise à jour contenant la direction de la fourmi
        public static string[,] matrice_principale;                                 // Variable régulièrement mise à jour contenant la matrice générale de l'algorithme
        public static bool[,] matrice_fantome;                                       // Variable régulièrement mise à jour contenant la matrice de couleurs
        public static int[] coordonnees;                                            // Variable régulièrement mise à jour contenant les coordonnées x,y et direction de la fourmi
        public static int step;
        public static bool running;
        #endregion Variables Globales

        #region Initialisation de la fourmi
        public static void Spawn(string[,] matrice, int x, int y)
        {
            Random direction = new Random();
            int dir = direction.Next(1, 4);         // Choix aléatoire de la direction de la foumi (1, 4) pour Nord Est Sud Ouest

            char fourmi = ' ';                      // Initialisation de la fourmi qui sera dans la matrice

            if (dir == 1)
                fourmi = Ant.fourmis[0];// Ant.coordonnees[2] = 0;      // Direction Nord (Ant.fourmis contient les différentes formes de la fourmi)
            if (dir == 2)
                fourmi = Ant.fourmis[1];// Ant.coordonnees[2] = 1;      // Direction Est
            if (dir == 3)
                fourmi = Ant.fourmis[2];// Ant.coordonnees[2] = 2;      // Direction Sud
            if (dir == 4)
                fourmi = Ant.fourmis[3];// Ant.coordonnees[2] = 3;      // Direction Ouest

            matrice[x, y] = $" {fourmi} ";   // Insertion de la fourmi au centre de la matrice avec une direction aléatoire
        }
        #endregion Initialisation de la fourmi
    }
}
