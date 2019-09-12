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
    
    //num img
    public Sprite[] numSpriteArray;
    //grid
    //public SpriteRenderer[] grid;
    public RawImage[] grid;
    public Image[] nums;

    private void Start()
    {
        instance = this;
        gridChangeColor = Resources.Load<Sprite>("background/cyan60");
        gridOriginColor = Resources.Load<Sprite>("background/gray30");
    }
}
