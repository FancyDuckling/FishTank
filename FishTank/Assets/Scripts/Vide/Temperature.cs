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
    // Reference to the SoundManager
    private SoundManager soundManager;

    void Start()
    {
        tempMeterSlider.value = Random.Range(0, 51);
        text.text = tempMeterSlider.value.ToString();

        // Get reference to the SoundManager instance
        soundManager = SoundManager.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeTemperature(+1);

            //Play UI Temp UP
            // Play sound effect for temperature increase
            if (soundManager != null)
            {
                soundManager.PlaySoundEffect(2); // Adjust the index based on your sound effects array
            }


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeTemperature(-1);

            //Play UI Temp Down
            // Play sound effect for temperature decrease
            if (soundManager != null)
            {
                soundManager.PlaySoundEffect(1); // Adjust the index based on your sound effects array
            }

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
