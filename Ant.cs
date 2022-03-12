namespace Projet_CSharp_S2
{
    class Ant
    {
        public static char[] fourmis = { '▲', '►', '▼', '◄' };                      // Toutes les formes possible de la fourmi 
        // [deprecated] //public static string[] directions = { "Nord", "Est", "Sud", "Ouest" };      // Toutes les directions possibles de la fourmi
        public static int direction;                                                // Variable régulièrement mise à jour contenant la direction de la fourmi
        public static string[,] matrice_principale;                                 // Variable régulièrement mise à jour contenant la matrice générale de l'algorithme
        public static int[,] matrice_fantome;                                       // Variable régulièrement mise à jour contenant la matrice de couleurs
        public static int[] coordonnees;                                            // Variable régulièrement mise à jour contenant les coordonnées x,y et direction de la fourmi
        public static int step;
    }
}
