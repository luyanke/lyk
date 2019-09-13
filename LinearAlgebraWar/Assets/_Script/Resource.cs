using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public static Resource instance;

    //选中的高光背景
    public Sprite gridChangeColor;
    public Sprite gridOriginColor;

    private void Start()
    {
        instance = this;
        gridChangeColor = Resources.Load<Sprite>("background/cyan60");
        gridOriginColor = Resources.Load<Sprite>("background/gray30");
    }
}
