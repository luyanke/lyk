using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{

    //private int hitCount;
    // Start is called before the first frame update
    void Start()
    {
        //hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    public void MoveControl()
    {
        if (ClickObject() == null)
        {
            return;
        }
        GameObject clickObj = ClickObject();
        if (clickObj.tag == "grid")
        {
            clickObj.GetComponent<RawImage>().texture = Resource.instance.gridChangeColor.texture;
        }

    }

    public void ModeChoose(GameObject obj)
    {

    }

    public GameObject ClickObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2
            (
#if UNITY_EDITOR
            Input.mousePosition.x, Input.mousePosition.y
#elif UNITY_ANDROID || UNITY_IOS
           Input.touchCount > 0 ? Input.GetTouch(0).position.x : 0, Input.touchCount > 0 ? Input.GetTouch(0).position.y : 0
#endif
            );
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Count > 0)
        {
            return results[0].gameObject;
        }
        else
        {
            return null;
        }
    }

}
