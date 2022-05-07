using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_CSharp_S2
{
    class AntV2
    {
        public struct Global
        {
            public int[] coordonnees;               // X, Y et direction 
            public string[,] matrice_principale;
            public bool[,] matrice_fantome;
            public int etape;
            public bool running;
        }

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
    }
}