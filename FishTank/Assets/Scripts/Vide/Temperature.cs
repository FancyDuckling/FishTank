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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeTemperature(+1);
            // Play sound effect for temperature increase
            SoundManager.Instance.PlaySoundEffect(2); // Adjust the index based on your sound effects array
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeTemperature(-1);
            // Play sound effect for temperature decrease
            SoundManager.Instance.PlaySoundEffect(1); // Adjust the index based on your sound effects array
        }
    }

    public void ChangeTemperature(float value)
    {
        tempMeterSlider.value += value;
        tempMeter.fillAmount = tempMeterSlider.value / tempMeterSlider.maxValue;
        text.text = tempMeterSlider.value.ToString();
        Debug.Log("Fill Image");
    }
}