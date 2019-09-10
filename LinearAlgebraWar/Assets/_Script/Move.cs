using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Move : MonoBehaviour
{

    private int hitCount;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    public void MoveControl()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //if (Input.touchCount > 0)
            {
                //if (Input.touches[0].phase == TouchPhase.Began)
                {
                    // 手指按下时，要触发的代码
                    Debug.Log("touch!");
                    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


                    //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    //hit用来存储碰撞物体的信息   
                    //RaycastHit hit;

                    if (hit.collider != null)
                    {
                        Debug.Log("hit");
                        GameObject gameObject = hit.collider.gameObject;

                        if (gameObject.tag == "grid")
                        {
                            hitCount++;
                            Debug.Log("hitGrid");
                            gameObject.GetComponent<SpriteRenderer>().sprite = Resource.instance.gridChangeColor;
                        }
                    }
                }
            }

        }


    }

    public void ModeChoose(GameObject obj)
    {

    }

}
