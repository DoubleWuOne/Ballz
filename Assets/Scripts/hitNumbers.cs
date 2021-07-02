using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public  class hitNumbers : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI bloc;
    public int counter;
    public int bloki;
    public void Start()
    {
        staticCounter.m_hitNumbers = this;
    }
    public void counterNum()
    {
        counter++;
    }
    public void bloks()
    {
        bloki++;
    }
    private void Update()
    {
        text.text = "Uderzone bloki: "+ counter.ToString();
        bloc.text = bloki.ToString();
    }
}
