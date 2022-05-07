using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_CSharp_S2
{
    public struct Global
    {
        public int[] coordonnees;               // X, Y et direction 
        public string[,] matrice_principale;    // Matrice circulaire
        public bool[,] matrice_fantome;
        public int etape;
        public bool running;
        public int[][] fourmis;

        public Global VerifMatriceCirculaire()
        {
            Global G = new Global();

            if (G.coordonnees[0] > G.matrice_principale.GetLength(0) && G.coordonnees[2] == 3)
                G.coordonnees[0] = 0;
            if (G.coordonnees[0] < 0 && G.coordonnees[2] == 1)
                G.coordonnees[0] = G.matrice_principale.GetLength(0);

            if (G.coordonnees[1] > G.matrice_principale.GetLength(1) && G.coordonnees[2] == 1)
                G.coordonnees[1] = 0;
            if (G.coordonnees[1] < 0 && G.coordonnees[2] == 3)
                G.coordonnees[1] = G.matrice_principale.GetLength(1);

            return G;
        }

        public Global MultiSpawn(string[,] matrice, int id)
        {
            Global Ant = new Global();

            Random direction = new Random();
            int dir = direction.Next(1, 4);                                                             // Choix aléatoire de la direction de la foumi (1, 4) pour Nord Est Sud Ouest

            return Ant;
        }
    }
}