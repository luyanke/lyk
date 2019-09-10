using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Resource : MonoBehaviour
{
    public static Resource instance;
    public Sprite gridChangeColor;

    private void Start()
    {
        instance = this;
        gridChangeColor = Resources.Load<Sprite>("background/cyan60");
    }
}
