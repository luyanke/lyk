using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Resource : MonoBehaviour
{
    public static Resource instance;
    public Sprite gridChangeColor;
    public Sprite gridOriginColor;

    public Sprite[] numSpriteArray;

    private void Start()
    {
        instance = this;
        gridChangeColor = Resources.Load<Sprite>("background/cyan60");
        gridOriginColor = Resources.Load<Sprite>("background/gray30");
    }
}
