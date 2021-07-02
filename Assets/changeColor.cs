using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    BallColors col;
    void Start()
    {
        GetComponent<Renderer>().material.color = GameObject.Find("Script").GetComponent<BallColors>().color;
    }
}
