# Dual of legends

## Dual of legends est un jeux de combat tour par tour en 2D opposant un joueur et l'ordinateur.

Équipe :
- Nathan Cueni Dolis
- Hugo Impérat
- Samuel Bugeas

Outils utilisés :
C#
Visual Studio 2022 (Application Windows Form)

### Contexte :
Dual of legends est un jeu 2D de combat en tour par tour, opposant un joueur à un ordinateur.
Chaque tour, le joueur devra choisir une action parmi l'Attaque, la Défense ou une compétence, qui dépend de la classe choisie. 
L'ordinateur, lui, choisit aléatoirement.
Lorsque la vie d'un des joueurs(ou les deux) atteint 0, la partie est perdue. 
A chaque tour, les actions sont jouées simultanément, il peut donc y avoir une égalité.


### Interactions avec le programme :

L'implementation visuelle du jeu s'est faite sur Windows Form. L'application possède donc des boutons pour récupérer les choix du joueur.


Les quatres classes jouables sont les suivantes :
- Tank
- Damager
- Healer
- Rogue

La classe 'Rogue'
Statistiques : 2 cœurs / 1 dégât
Compétence : Le rogue applique du poison sur ses dagues et entreprend une attaque infligeant 1 dégât, si la cible ne se défend pas et l'empoisonne, même si celle-ci s'est défendu. La cible est alors dans l'état empoisonnée jusqu'au tour suivant, ce qui lui infligera 1 dégât supplémentaire. Le cible sortira ensuite de l'état d'empoisonnement.


###Instructions pour installer et lancer le programme :

Résolution recommandé : 1920 x 1080 ou 1920x1200

Lancer le fichier comportant l'extention ".sln" et lancer l'execution du programme.

Interactions avec le programme :

* Cliquez sur le bouton 'Start'. 
* Choisissez votre classe parmi les quatres proposées en cliquant sur la carte associée. 
* Le combat commence, cliquer alors sur l'action que vous souhaitez réaliser pour le tour, parmi les 3 suivantes :
	- Attaque (Icone épée)
	- Défense (Icone bouclier)
	- Compétence (Icone étoile)
* A la fin du combat, vous pouvez retourner au menu en cliquant sur le bouton 'Restart'

-----------------------------------

Améliorations apportées :
1 - Nouvelle classe de personnage ('Rogue')
2 - Mode de simulation -> fonction "GameSimulation()" permettant de confronter automatiquement deux personnages, pour un nombre de combat donné, ce qui permet de tester l'équilibrage entre les différentes classes.
3 - Interface graphique (Windows Form)
