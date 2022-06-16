# BallsExam

## Exercice 1

```

Créer un algorithme qui permet de générer 3000 billes.

Voici les propriétés de chaque bille :
- Un index qui correspond à l'ordre dans lequel elles ont été générées.
- Une couleur aléatoire qui est soit rouge, vert ou bleu.
- Une intensité de couleur aléatoire dans l'intervalle [0, 255]

```
Regardonc la méthode Update().
Les billes sont crées grâce à
```Cs
 GameObject.CreatePrimitive(PrimitiveType.Sphere);
```
 Les informations de chaque bille sont stockées dans des dictionnaires de <billes,int> ou <bille,float>, cf 
 
```Cs
 private List<GameObject> SphereList = new List<GameObject>();
    Dictionary<GameObject, int> _DicInDex = new Dictionary<GameObject, int>();
    Dictionary<GameObject, float> _DicIntensity = new Dictionary<GameObject, float>();
```

La couleur de chaque bille est stockée dans un tableau de float de 3 dimensions :
 ```Cs    
private Color[] validColor = new Color[] { Color.blue, Color.red, Color.green };
```
Puisque j'ai choisi de travailler avec des float, l'intensité est calculée comme suit :
```Cs
float intensity = validColor[Random.Range(0, validColor.Length)].r + validColor[Random.Range(0, validColor.Length)].g + validColor[Random.Range(0, validColor.Length)].b;
```

## Partie 2

```
# Objectif 2 - Regroupement

Créer un algorithme qui permet de regroupper les billes par couleur.

Le résultat sera :
- Un ensemble de billes rouges.
- Un ensemble de billes vertes.
- Un ensemble de billes bleues.
```
La methode RegroupBallByColors() est appelée dans la méthode Update(). Elle permet de regrouper les billes par couleur. Ces billes sont stockées dans des tableaux de GameObject.

```Cs
    //Ex 2
    private List<GameObject> redBalls= new List<GameObject>();
    private List<GameObject> greenBalls = new List<GameObject>();
    private List<GameObject> blueBalls = new List<GameObject>();
```
## Partie 3
```
Créer un algorithme qui permet de trier les 3 regroupements de billes en fonction de l'index de chaque bille, du plus grand au plus petit.

Le résultat sera :
- Un ensemble de billes rouges triées par index du plus grand au plus petit.
- Un ensemble de billes vertes triées par index du plus grand au plus petit.
- Un ensemble de billes bleues triées par index du plus grand au plus petit.
```
La methode SortBallByIndex() est appelée dans la méthode Update(). Elle permet de trier les billes par index Decroissant par l'utilisation de la méthode Reverse();.

Variables ou sont stocker les billes :
```Cs
    
    //Ex3
    private List<GameObject> _OrderedredBalls = new List<GameObject>();
    private List<GameObject> _OrderedgreenBalls = new List<GameObject>();
    private List<GameObject> _OrderedblueBalls = new List<GameObject>();
```

## Partie 4

```
Créer un algorithme qui fusionne ensemble les 100 premières billes de chacun des 3 regroupemements, selon leurs positions dans les regroupements triés de l'étape précédente.

Voici les transformations à faire lors de la fusion des billes :
- L'intensité de couleur qu'avait chaque bille avant d'être fusionnée deviendra la composante rouge, verte et bleue du format de couleur RGB de la bille fusionnée.
- Chaque bille fusionnée aura un score (valeur en nombre de points), calculé comme étant la somme de chaque index des 3 billes fusionnées ensemble.

```
La methode MergeFirst100Balls()() est appelée dans la méthode Update(). Elle permet de fusionner les couleurs billes.

On recupere les 100 premieres boules bleues et on les met dans un tableau de GameObject après avoir calculé leur score et leur intensité de couleur.

```Cs
    // Ex4 
    private List<GameObject> _First100Balls = new List<GameObject>();
    Dictionary<GameObject, int> _DicIn100Score = new Dictionary<GameObject, int>();

```
Les 100 premieres billes calculees sont stockées dans ce tableau de GameObject.
Leur scores dans ce dictionnaire.

# Partie 5

```
réer une scène où les 100 billes de l'étape précédentes sont affichées à l'écran.

Voici comment la scène est organisée :
- Les billes sont affichés une à la suite de l'autre en spirale, avec la première bille au centre de l'écran.
- Les billes sont triés par leur score, du plus petit au plus grand.
- Chaque bille est affichée avec la couleur calculée dans l'étape précédente.
- Une zone de texte affiche le score total, soit la somme du score de chaque bille.

```
La scene est utilisee est l'unique scene du projet, elle fait spawner les billes des couleurs rouge, vert et bleu puis recupere les 100 dernieres bleues et fait la fusion (elles deviennent grises). J'ai rajouté un rigibody pour les billes afin de les faire bouger.
