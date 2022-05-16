using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_CSharp_S2
{
    /*public struct Fourmis
    {
        public int[] coordonnees;               // X, Y et direction 
        public int age;
        //public string[,] matrice_principale;    // Matrice circulaire
        //public bool[,] matrice_fantome;
        public int etape;
        public bool running;
        //public int[][] fourmis;

        /*public Fourmis SaveMat(string[,] mat, bool[,] ghost_mat, Fourmis G)
        {
            matrice_principale = mat;
            matrice_fantome = ghost_mat;

            return G;
        }

        public Fourmis VerifMatriceCirculaire()
        {
            Fourmis G = new Fourmis();

            if (G.coordonnees[0] > Ant.matrice_principale.GetLength(0) && G.coordonnees[2] == 3)
                G.coordonnees[0] = 0;
            if (G.coordonnees[0] < 0 && G.coordonnees[2] == 1)
                G.coordonnees[0] = Ant.matrice_principale.GetLength(0);

            if (G.coordonnees[1] > Ant.matrice_principale.GetLength(1) && G.coordonnees[2] == 1)
                G.coordonnees[1] = 0;
            if (G.coordonnees[1] < 0 && G.coordonnees[2] == 3)
                G.coordonnees[1] = Ant.matrice_principale.GetLength(1);

            return G;
        }

        public Fourmis MultiSpawn(string[,] matrice, int id)
        {
            Fourmis Ant = new Fourmis();

            Random direction = new Random();
            int dir = direction.Next(1, 4);                                                             // Choix aléatoire de la direction de la foumi (1, 4) pour Nord Est Sud Ouest

            return Ant;
        }
    }*/

    public class Antv2
    {
        public static int[][] fourmis;    // tableau de tableau de toutes les infos de la fourmi (x, y, direction, age)
        public static int index_fourmi_track;
        public static bool moved;
    }
    // int maxage = 0; 
    //*for (int i = 0; i < mat.GetLength(0); i++){
    //for (int j = 0; j < mat.GetLength(1); j++){
    // if (maxage < age fourmi case)
        //maxage = age fourmi case)
        //sauvegarder les coordonées, puis activer un booléen une fois qu'elle à bougé, pour ne pas la faire bouger une seconde fois,
        //sans oublier de faire age+1. 
        //une fois que tt les fourmi ont bougés, respawn d'une, puis rebelote avec les booléen qui indique que la fourmi à été incrémenté remis à 0  
    //  }
    //}

}