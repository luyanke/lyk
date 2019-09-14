using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using System;


public enum Step
{
    none,
    swapRow, //行交换
    swapCol, //列交换
    addRow, //行相加
    addCol, //列相加
    minusRow,//行相减
    minusCol,//列相减
    multipRow, //行倍乘
    multipCol, //列倍乘
    divideRow,//行倍除
    divideCol //列倍除
}

//history node
public class Node
{
    Step step;
    int param1;
    int param2;
    public Node(Step step, int param1, int param2)
    {
        this.step = step;
        this.param1 = param1;
        this.param2 = param2;
    }
}
public class Matrix : MonoBehaviour
{
    public static Matrix instance;

    private int[,] TestMatrix;

    public int[,] matrix;
    public GameObject[] gridObj;

    public GameObject[] numPrefab;

    private Node node;
    private List<Node> history;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        matrix = new int[3,3] { { 62, 20, 33 }, { 4, 56, 67 }, { 17, 8, 9 } };
    }
    void Start()
    {
        GenerateMatrix(matrix);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateMatrix(int[,] originMatrix)
    {
        int gridCount = 0;
        //生成3x3矩阵
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                foreach (Transform child in gridObj[gridCount].GetComponentInChildren<Transform>())
                {
                    if (child != null)
                    {
                        Destroy(child.gameObject);
                    }
                }
                foreach (char num in originMatrix[i, j].ToString())
                {
                    //根据矩阵实例化图片，并成为网格的子物体
                    if(num == '-')
                    {
                        //如果是负数
                        Instantiate(numPrefab[10], gridObj[gridCount].transform.position, Quaternion.identity).transform.parent = gridObj[gridCount].transform;
                    }
                    else
                    {
                        Instantiate(numPrefab[int.Parse(num.ToString())], gridObj[gridCount].transform.position, Quaternion.identity).transform.parent = gridObj[gridCount].transform;
                    }
                }
                gridCount++;
            }
        }

    }

    public void SwapRow(int row1, int row2)
    {
        // for --- alter
        int temp;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
        AddStep(new Node(Step.swapRow, row1, row2));
    }

    public void SwapCol(int col1, int col2)
    {
        int temp;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            temp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = temp;
        }
        AddStep(new Node(Step.swapCol, col1, col2));
    }

    public void AddRow(int row1,int row2)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[row1, i] += matrix[row2, i];
        }
        Debug.Log(matrix);
        GenerateMatrix(matrix);
    }

    public void AddCol(int col1,int col2)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i,col1] += matrix[i, col2];
        }
        Debug.Log(matrix);
        GenerateMatrix(matrix);
    }

    public void MinusRow(int row1, int row2)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[row1, i] -= matrix[row2, i];
        }
        Debug.Log(matrix);
        GenerateMatrix(matrix);
    }

    public void MinusCol(int col1, int col2)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i, col1] -= matrix[i, col2];
        }
        Debug.Log(matrix);
        GenerateMatrix(matrix);
    }

    public void MultipRow(int row1, int row2)
    {

    }

    public void AddStep(Node node)
    {
        history.Add(node);
    }
}
