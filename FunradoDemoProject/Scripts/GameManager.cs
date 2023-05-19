using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    private Collectable _collectable;
    void Awake()
    {
        _collectable = FindObjectOfType<Collectable>();
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
