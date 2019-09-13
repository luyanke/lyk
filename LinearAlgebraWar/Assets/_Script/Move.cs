using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum StepChose
{
    None,//未选中
    Row,//选中行
    Col //选中列
}

public class Move : MonoBehaviour
{
    public static Move instance;

    public List<int> chosen;
    //用于判断行列
    private int[,] template = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
    private StepChose stepChose = StepChose.None;//传递行或者列变换信息
    private int stepChoseParam;//信息所携带的行/列号
    private Step step = Step.none;//传递要进行的操作
    private int stepParam;
    bool isInteractive = true; //当前是否可点击

    //private int hitCount;
    // Start is called before the first frame update
    void Start()
    {
        //hitCount = 0;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    public void MoveControl()
    {
        if (isInteractive)
        {
            if (ClickObject() == null)
            {
                return;
            }
            GameObject clickObj = ClickObject();
            if (clickObj.tag == "grid")
            {
                for (int i = 0; i < Matrix.instance.gridObj.Length; i++)
                {
                    if (clickObj == Matrix.instance.gridObj[i])
                    {
                        if (chosen.Count <= 3)
                        {
                            //判断当前点击是否已被选中
                            if (!chosen.Contains(i))
                            {
                                chosen.Add(i);
                            }
                        }
                        else
                        {
                            RefreshChose();
                        }
                    }
                }
                //每次点击都更换颜色
                clickObj.GetComponent<RawImage>().texture = Resource.instance.gridChangeColor.texture;

                //判断是否选中行或者列
                if (chosen.Count == 3)
                {
                    SwitchRowOrCol();
                }
            }
        }
    }

    public void SwitchRowOrCol()
    {
        switch (step)
        {
            case Step.multipRow:
                break;
            case Step.multipCol:
                break;
            case Step.divideRow:
                break;
            case Step.divideCol:
                break;
        }
        for (int i = 0; i < template.GetLength(0); i++)
        {
            //选中行
            if (chosen.Contains(template[i, 0]) && chosen.Contains(template[i, 1]) && chosen.Contains(template[i, 2]))
            {
                stepChose = Message(step, StepChose.Row, i);
                break;
            }
            //选中列
            else if (chosen.Contains(template[0, i]) && chosen.Contains(template[1, i]) && chosen.Contains(template[2, i]))
            {
                stepChose = Message(step,StepChose.Col, i);
                break;
            }
            //选中的不是行或者列
            if (i == 2)
            {
                isInteractive = false;
                StartCoroutine(ShowHint());
            }
        }
    }

    public IEnumerator ShowHint()
    {
        Debug.Log("请选中行或者列");
        yield return new WaitForSeconds(.2f);
        RefreshChose();
        isInteractive = true;
    }

    public void RefreshChose()
    {
        chosen.Clear();
        stepChose = StepChose.None;
        step = Step.none;
        foreach (GameObject flashChose in Matrix.instance.gridObj)
        {
            flashChose.GetComponent<RawImage>().texture = Resource.instance.gridOriginColor.texture;
        }
    }

    public StepChose Message(Step stepMessage,StepChose choseMessage,int i)
    {
        stepChoseParam = i;
        switch (stepMessage)
        {
            case Step.none:
                return choseMessage;

            case Step.swapRow:
                break;

            case Step.swapCol:
                break;

            case Step.addRow:
                Matrix.instance.AddRow(stepParam, stepChoseParam);
                break;

            case Step.addCol:
                break;

            case Step.minusRow:
                break;

            case Step.minusCol:
                break;
        }
        return choseMessage;
    }

    public Step Message(Step stepMessage,int i)
    {
        stepParam = i;
        return stepMessage;
    }

    public GameObject ClickObject()
    {
        if (Input.GetMouseButton(0))
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
        else
        {
            return null;
        }
        
    }

    public void AddBtn()
    {
        switch (stepChose)
        {
            case StepChose.None:
                Debug.Log("请先选中行或者列AddBtn");
                break;

            case StepChose.Row:
                Debug.Log("行相加");
                step = Message(Step.addRow, stepChoseParam);
                break;

            case StepChose.Col:
                step = Message(Step.addCol, stepChoseParam);
                break;
        }
    }

}
