using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;




public class BallGenerator : MonoBehaviour
{
    // Ex1
    private Color[] validColor = new Color[] { Color.blue, Color.red, Color.green };
    private List<GameObject> SphereList = new List<GameObject>();
    Dictionary<GameObject, int> _DicInDex = new Dictionary<GameObject, int>();
    Dictionary<GameObject, float> _DicIntensity = new Dictionary<GameObject, float>();


    //Ex 2
    private List<GameObject> redBalls= new List<GameObject>();
    private List<GameObject> greenBalls = new List<GameObject>();
    private List<GameObject> blueBalls = new List<GameObject>();

    //Ex3
    private List<GameObject> _OrderedredBalls = new List<GameObject>();
    private List<GameObject> _OrderedgreenBalls = new List<GameObject>();
    private List<GameObject> _OrderedblueBalls = new List<GameObject>();

    // Ex4 
    private List<GameObject> _First100Balls = new List<GameObject>();
    Dictionary<GameObject, int> _DicIn100Score = new Dictionary<GameObject, int>();


    private int compteur = 0;
    private int maxBallCreated = 3000;



    bool ok = true;
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i=0;i<300;i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.AddComponent<Rigidbody>();
            Renderer rend = sphere.GetComponent<Renderer>();
            sphere.transform.position = new Vector3(0, 1.5f, 0);
            int rand = UnityEngine.Random.Range(0, validColor.Length);
            float intensity = (validColor[rand].r + validColor[rand].g + validColor[rand].b) / 3f;
            rend.material.SetColor("_Color", validColor[rand]*intensity);
            _DicInDex.Add(sphere, i);
            
            SphereList.Add(sphere);
        }*/
       
    }

    // Update is called once per frame
    void Update()
    {
        if(compteur<maxBallCreated)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.AddComponent<Rigidbody>();
            Renderer rend = sphere.GetComponent<Renderer>();
            sphere.transform.position = new Vector3(0, 1.5f, 0);


            int rand = UnityEngine.Random.Range(0, validColor.Length);
            float intensity = (float)(validColor[rand].r + validColor[rand].g + validColor[rand].b) / 3f;

            rend.material.SetColor("_Color", validColor[rand] * intensity);

            _DicIntensity.Add(sphere, intensity);
            _DicInDex.Add(sphere, compteur);
            SphereList.Add(sphere);

            compteur++;
        }
        else if(ok)
        {
            RegroupBallByColors();
            SortAllThreeBalls();
           //  Debug.Log("nb = " + _OrderedblueBalls.Count);
           MergeFirst100Balls();
            ok = false;
        }
     
    }
    //Ex 2

    private void RegroupBallByColors()
    {
       // Debug.Log("SHERE LIST = " + SphereList.Count);
        foreach (GameObject b in SphereList)
        {
           // Debug.Log((b.GetComponent<Renderer>().material.color == validColor[0] * _DicIntensity[b]));
            if (b.GetComponent<Renderer>().material.color == validColor[0]*_DicIntensity[b]) //blue
            {
                blueBalls.Add(b);

            }
            else if(b.GetComponent<Renderer>().material.color == validColor[1] * _DicIntensity[b]) // red
            {
                redBalls.Add(b);
            }
            else if (b.GetComponent<Renderer>().material.color == validColor[2] * _DicIntensity[b]) // green
            {
               greenBalls.Add(b);
            }

        }
       
    }
    // Ex3 sort
    private void SortAllThreeBalls()
    { 
        // Renverser les index c'est renverser la liste puis la lire dans l'ordre
        blueBalls.Reverse();
        foreach (GameObject sphere in blueBalls)
        {
            _OrderedblueBalls.Add(sphere); //DESC
        }

        redBalls.Reverse();

        foreach (GameObject sphere in redBalls)
        {
            _OrderedredBalls.Add(sphere); //DESC
        }
        greenBalls.Reverse();
        foreach (GameObject sphere in greenBalls)
        {
            _OrderedgreenBalls.Add(sphere); //DESC
        }
       // printData(_OrderedblueBalls);

    }

    private void MergeFirst100Balls()
    {
        for (int i = 0; i<99;i++)
        {
            GameObject MergedSphere = _OrderedblueBalls[i];
            MergedSphere.transform.position = new Vector3(0, 1.5f, 0);
            Color B = _OrderedblueBalls[i].GetComponent<Renderer>().material.color;
            Color G = _OrderedgreenBalls[i].GetComponent<Renderer>().material.color;
            Color R = _OrderedredBalls[i].GetComponent<Renderer>().material.color;

            

            MergedSphere.GetComponent<Renderer>().material.SetColor("_Color", new Color(R.r, G.g, B.b));
            // largement simplifiee car les boules n'ont qu'une seule composante, dans le cas contraire il aurait fallu faire une multiplication de chacun des canaux
            _First100Balls.Add(MergedSphere);
            int score = _DicInDex[_OrderedblueBalls[i]] + _DicInDex[_OrderedgreenBalls[i]] + _DicInDex[ _OrderedredBalls[i]];
            _DicIn100Score.Add(MergedSphere, score);
        }
    }


    void printData(List<GameObject> b)
    {
        
        foreach (GameObject s in b)
        { 
            Debug.Log(_DicInDex[s]);
        }
    }


}
