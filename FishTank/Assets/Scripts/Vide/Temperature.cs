using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Temperature : MonoBehaviour
{
    public Image tempMeter;
    public Slider tempMeterSlider;
    public TextMeshProUGUI text;
    private float lastMeasuredTemp;
    void Start()
    {
        tempMeterSlider.value = Random.Range(0, 51);
        text.text = tempMeterSlider.value.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeTemperature(+1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeTemperature(-1);
        }
    }
    public void ChangeTemperature(float value) 
    {
        tempMeterSlider.value += value;
        tempMeter.fillAmount = tempMeterSlider.value / tempMeterSlider.maxValue;
        text.text = tempMeterSlider.value.ToString();
        Debug.Log("Fill Image");
        ;
    }
}
