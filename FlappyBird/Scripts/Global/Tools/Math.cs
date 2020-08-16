using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MathTools
{
    
    public static int RandomNumberGenerator(int start, int end)
    {
        System.Random randgerator = new System.Random();
        return randgerator.Next(start, end);
    }
}
