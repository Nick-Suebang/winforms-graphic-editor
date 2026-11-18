# Éditeur Graphique Windows Forms

Un éditeur graphique simple permettant de dessiner des formes géométriques basiques, développé avec Windows Forms en C#.

## Fonctionnalités

- Dessin de formes géométriques :
  - Lignes
  - Rectangles
  - Ellipses
- Personnalisation :
  - Choix de la couleur
  - Modification de l'épaisseur du trait
- Gestion de fichiers :
  - Sauvegarde des dessins
  - Chargement des dessins existants

## Interface utilisateur

### Menu principal
- **Fichier** :
  - Ouvrir : Charger un dessin existant
  - Enregistrer : Sauvegarder le dessin actuel
- **Outils** :
  - Ligne : Outil de dessin de lignes
  - Rectangle : Outil de dessin de rectangles
  - Ellipse : Outil de dessin d'ellipses
  - Épaisseur du trait : Modifier l'épaisseur du trait

### Menu contextuel (clic droit)
- Couleur : Changer la couleur du trait
- Augmenter trait : Augmenter l'épaisseur du trait
- Diminuer trait : Diminuer l'épaisseur du trait

### Barre d'état
Affiche l'outil actuel, la couleur sélectionnée et l'épaisseur du trait

## Compilation et lancement

Prérequis : Windows avec le [SDK .NET](https://dotnet.microsoft.com/download) (version 6 ou plus récente) ou Visual Studio 2022. L'application cible le .NET Framework 4.7.2, déjà présent sur Windows 10 et 11.

```bash
dotnet build
dotnet run --project editeur-graphique-winforms.csproj
```

Avec Visual Studio, il suffit d'ouvrir `editeur-graphique-winforms.sln` et d'appuyer sur F5.

## Structure du projet

```
Formes/        Modèle des formes géométriques
Modele/        Le dessin (liste ordonnée des formes)
Persistance/   Lecture et écriture des fichiers de dessin
Vues/          Fenêtre principale et boîte de dialogue d'épaisseur
Program.cs     Point d'entrée
```

### Formes
- **Forme** (classe abstraite) : points de début et de fin, couleur, épaisseur (validée entre 1 et 100 px). La méthode `Dessiner` prépare le crayon puis délègue le tracé à `Tracer`, que chaque sous-classe implémente (patron *Méthode template*).
- **Ligne**, **Rectangle**, **Ellipse** : implémentations concrètes.
- **TypeForme** : énumération des types de formes disponibles.
- **FabriqueFormes** : seul endroit où les formes sont créées (patron *Fabrique*).

### Modèle et persistance
- **Dessin** : contient les formes et sait les dessiner, indépendamment de l'interface.
- **SerialiseurDessin** : enregistre et charge un dessin. Le fichier est validé en entier avant d'être accepté : une ligne invalide est signalée avec son numéro et le dessin en cours n'est pas perdu.

### Vues
- **FenetrePrincipale** : relaie les actions de l'utilisateur (souris, menus) vers le modèle.
- **EpaisseurDialog** : saisie bornée de l'épaisseur du trait.

### Ajouter une nouvelle forme
1. Créer une classe qui hérite de `Forme` et implémente `Type` et `Tracer`.
2. Ajouter la valeur correspondante dans `TypeForme` et le cas dans `FabriqueFormes`.
3. Ajouter l'élément de menu dans la fenêtre principale.

## Utilisation

1. Sélectionnez un outil de dessin dans le menu "Outils"
2. Personnalisez la couleur et l'épaisseur du trait si désiré
3. Cliquez et maintenez le bouton gauche de la souris pour commencer le dessin
4. Déplacez la souris pour ajuster la forme
5. Relâchez le bouton pour finaliser le dessin

## Format de sauvegarde

Les dessins sont sauvegardés au format texte avec une ligne par forme :
```
TypeForme;X1;Y1;X2;Y2;R;G;B;Epaisseur
```
- TypeForme : Ligne, Rectangle ou Ellipse
- X1,Y1 : Coordonnées du point de début
- X2,Y2 : Coordonnées du point de fin
- R,G,B : Composantes de couleur RGB
- Epaisseur : Épaisseur du trait en pixels

## Auteur et contact

**Nick Suebang** (Nick Hariel Teponno Suebang), technicien en informatique et développeur web et mobile à Rimouski (QC).

- Portfolio : [nicksuebang.com](https://nicksuebang.com)
- Courriel : [contact@nicksuebang.com](mailto:contact@nicksuebang.com)
- GitHub : [@Nick-Suebang](https://github.com/Nick-Suebang)
- LinkedIn : [Nick Hariel Teponno Suebang](https://www.linkedin.com/in/nick-hariel-teponno-suebang-6a8875292/)
