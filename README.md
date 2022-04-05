# Projet C# S2 ► Le projet en binôme

# Partenaires : 
- [Marwan Kaouachi](https://github.com/marwank270/)
- [Charles A.-Lebrun](https://github.com/novaxsavestheyear)

# Historique d'avancement jounalier / Logs du projet :

## 18/02/22:
- Fichiers :
  - Création des fichiers du projet *(Marwan)*
  - Création de ce Github *(Marwan)*
- Codage :
  - Création du menu principal du programme *(Marwan)*
  - Création d'une méthode de Saisie de nombre *(Marwan)*
  - Creation d'une méthode de Saisie de matrice *(Charles)*
  - Tentative de localisation du millieu de la matrice [Échec à ce jour] *(Charles)*
  
## 20/02/22
- Codage :
  - Rectification de la localisation du milieu de la matrice *(Charles)*
  - Création et initialisation du spawn aléatoire de la fourmi au centre de la matrice blanche *(Marwan)*

## 21/02/22 :
- Codage :
  - Création d'une méthode de localisation des coordonnées et de la direction de la fourmi [Échec à ce jour] *(Marwan)*
  - Création d'une `class Stock` pour stocker les constantes dont nous aurons régulièrement besoin dans le code *(Marwan)*

## 27/02/22 
- Codage :
  - Création de la méthodes `PosFourmi()` *(Marwan)* 
  - > *(Résolution du bug précédent \[l.26] par Charles)*
  - Correction des bugs dans l'algo de recupération de la matrice *(Charles)*
  - Stockage de toutes les variables de positions de la fourmi et de la matrice dans `class Stock` *(Marwan)*
  - Création d'une méthode `MouvementFourmi()` qui change toutes les variables de la fourmi avec les bonne règles *(Marwan & Charles)*
- Optimisation :
  - Amélioration de partie de code lourdes *(Marwan & Charles)*

## 08/03/22 : 
- Codage :
  - Création de l'algo de Langton *(Marwan & Charles)*
  - Correction et amélioration de la méthode `PosFourmi()` *(Marwan & Charles)*
- Amélioration :
  - Ajout de commentaires explicatifs sur le code *(Marwan)*

## 11/03/22 :
- Fichiers :
  - Création de `Menu.cs` *(Marwan)*
- Codage : 
  - Création d'une nouvelle interface de menu contrôlable par les flèches directionnelles *(Marwan)*
  - Changement de l'ASCII art du menu (trop de rat nous on copié les idées de Marwan) *(Marwan)*
- Amélioration :
  - Ajout de commentaires explicatifs sur le code *(Marwan)*

## 12/03/22 :
- Fichiers :
  - Création de `Ant.cs`
- Codage : 
  - Foumi parfaitement fonctinonelle
- Amélioration :
  - Amélioration du menu
  - Amélioration des matrices
  - Amélioration de l'affichage
  - amélioration de l'agencement du code dans les fichiers

## 23/03/22 :
- Fichiers : 
  - Création de `FourmiTest.cs` dans le but de commencer les tests avec les structures *(Marwan)*
- Amélioration : 
  - Correction de bugs de saisies *(Charles)*
  - Amélioration des boucles *(Charles)*
  - Ajouts de commentaires dans les fichiers `Ant.cs` et `Menu.cs` *(Marwan)*

## 25/03/22 : 
- Fichiers : 
  - Mise à jour du fichier `.gitignore` pour nous permettre de reprendre le codage chacun de notre coté et pouvoir executer le projet (le problème était qu'en pushant tout le dossier les fichiers de génération de la build comprennais les chemins d'accès de l'un ou l'autre et donc ne pouvais pas s'executer sur un autre ordinateur le fait d'avoir configuré ce `.gitingnore` permet de récupérer et executer le projet en récupérant seulement les changements fait aux fichiers scripts) *(Marwan)*

## 27/03/22 :
- Codage :
  - Optimisation de la boucle principale : transformation des `if` `else if` a répétition en `switch` *(Marwan)*
  - Gestion de l'erreur du bord de matrice terminée mais à améliorer au niveau estétique *(Marwan)*

## 05/04/22 : 
- Amélioration :
  - Optimisation de la méthode `SwitchColor()` en changeant les `if` par l'opérateur d'inversion `!` *(Marwan)*
  - Optimisation de la méthode `Ant.Spawn()` en changeant les `if` par `Ant.fourmis[dir-1]` *(Marwan)*