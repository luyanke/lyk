using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base
{
    // This class is just for organzing code construction.

    public void ReWindStep()
    {
        // for rewind step function
    }

    public  void ModeChoose()
    {
        // choose ShiftRow mode or ShiftCol mode
    }

    public void ShiftRow()
    {
        // for --- alter
    }

    public void ShiftCol()
    {
        // for
        //     |
        //     |
        //     |
        //        alter
    }
    
    public void Add()
    {
        // for two rows or cols add
    }

    public void Multip()
    {
        // for one row or col multiply a not zero number
    }

    public void Swap()
    {
        //exchange two rows or cols
    }

    public void ShowHint()
    {
        // for advise
    }

    public void AddStep()
    {

    }
}
