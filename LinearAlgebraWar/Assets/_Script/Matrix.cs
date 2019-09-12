using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using System;


public enum Step
{
    swapRow, //行交换
    swapCol, //列交换
    addRow, //行相加
    addCol, //列相加
    multipRow, //行倍乘
    multipCol //列倍乘
}

//history node
public class Node
{
    Step step;
    int param1;
    int param2;
    public Node(Step step,int param1,int param2)
    {
        this.step = step;
        this.param1 = param1;
        this.param2 = param2;
    }
}

//矩阵的单个元素
public struct MatrixElement
{
    public int num { get; set; }
    //public Sprite numImg { get; set; }
    public RawImage Grid { get; set; }
}

public class Matrix : MonoBehaviour
{
    public static Matrix instance;

    public MatrixElement[,] matrix;
    private int[,] TestMatrix;

    //public int[,] matrix;
    //public Sprite[,] matrixGrid;

    //private Sprite[,] matrixImg;
    private Node node;
    private List<Node> history;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        matrix = new MatrixElement[3, 3];
        TestMatrix = new int[,]{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    }
    void Start()
    {
        GenerateMatrix(TestMatrix);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMatrix(int[,] originMatrix)
    {
        int gridCount = 0;
        //生成3x3矩阵
        for(int i = 0; i < 3;  i++)
        {
            for(int j = 0; j < 3; j++)
            {
                //...
                matrix[i, j].Grid = Resource.instance.grid[gridCount];
                gridCount++;
                foreach (char num in originMatrix[i, j].ToString())
                {
                    Image insObj = Instantiate(Resource.instance.nums[int.Parse(num.ToString())], matrix[i, j].Grid.transform.position, matrix[i, j].Grid.transform.rotation) as Image;
                    insObj.transform.parent = matrix[i, j].Grid.transform;
                }
            }
        }

    }

    public void SwapRow(int row1, int row2)
    {
        // for --- alter
        MatrixElement temp = new MatrixElement();
        for (int i = 0; i < 3; i++)
        {
            temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
        AddStep(new Node(Step.swapRow, row1, row2));
    }

    public void SwapCol(int col1,int col2)
    {
        MatrixElement temp = new MatrixElement();
        for (int i = 0; i < 3; i++)
        {
            temp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = temp;
        }
        AddStep(new Node(Step.swapCol,col1,col2));
    }

    public void AddStep(Node node)
    {
        history.Add(node);
    }
}
