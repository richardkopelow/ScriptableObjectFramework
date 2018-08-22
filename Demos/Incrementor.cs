using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incrementor : MonoBehaviour {

    public IntValue Integer;

    public void Increment()
    {
        Integer.Value++;
    }
}
