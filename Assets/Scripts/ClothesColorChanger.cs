using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.black);
    }
    
}
