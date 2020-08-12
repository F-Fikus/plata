using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Sphere;
    public int S;

    public void OnButtonDown()
    {
        S = Random.Range(1, 2);
        Sphere.transform.Translate(S, 0, 0);

    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
