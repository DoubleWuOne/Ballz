using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallColors : MonoBehaviour
{

    [SerializeField] Button red_b;
    [SerializeField] Button green_b;
    [SerializeField] Button blue_b;
   
    public Color color;

    private void Awake()
    {
        color = Color.white;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        red_b.onClick.AddListener(redColor);
        green_b.onClick.AddListener(greenColor);
        blue_b.onClick.AddListener(blueColor);
    }
    private void redColor()
    {
        color = Color.red;
    }
    private void greenColor()
    {
        color = Color.green;
    }
    private void blueColor()
    {
        color = Color.blue;
    }
}
