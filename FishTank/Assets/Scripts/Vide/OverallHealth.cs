using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverallHealth : MonoBehaviour
{
    public Slider hungerBar;
    public Slider tempBar;
    public Material material;
    public Color[] colors;
    private int idealTemp;
    int initialValue;
    int lastIndex;
    bool firstTime = true;
    FeedTheFish hungerControl;
    public PoopWater water;
    public LifeSystem lifeSystem;
    public ScriptedFishMovement fish;
    void Start()
    {
        idealTemp = (int)Random.Range(10, tempBar.maxValue);
        Debug.Log(idealTemp);
        StartCoroutine(Timer());
        hungerControl = GetComponent<FeedTheFish>();
        PoopWater water = GetComponent<PoopWater>();
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        UpdateOverallHealth();
        StartCoroutine(Timer());
        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
       if (hungerBar.value == 0)
        {
            lifeSystem.TakeDamage();
            NewFish(false);
        }
       
    }

    // Update is called once per frame
    public void UpdateOverallHealth()
    {
        var diff = idealTemp - tempBar.value;
        //Debug.Log("Diff Value : "+ diff);
        if( diff == 0 )
        {
            TransitionColor(10, 3);   
        }
        else if ( Mathf.Abs(diff) < 5)
        {
            TransitionColor(5, 3);
        }
        else if (Mathf.Abs(diff) < 10)
        {
            TransitionColor(1,2);
        }
        else if (Mathf.Abs(diff) < 15)
        {
            TransitionColor(-5, 1);
        }
        else
        {
            TransitionColor(-10, 1);
        }

    }
    void TransitionColor(int addedValue, int index)
    {
        var newValue = initialValue + addedValue;
        
        
        //if (newValue > 75)
        //{
        //    index = 4;
        //}
        //else if (newValue > 50)
        //{
        //    index = 3;
        //}
        //else if (newValue > 25)
        //{
        //    index = 2;
        //}
        //else
        //{
        //    index = 1;
        //}
        if (firstTime == false)
        {
            material.color = Color.Lerp(colors[lastIndex], colors[index], initialValue/(index * 25));
            lastIndex = index;

        }
        else
        {
            material.color = Color.Lerp(colors[0], colors[index], 1);
            firstTime = false;
            lastIndex = index;
        }

       
        initialValue = newValue;
        initialValue = Mathf.Clamp(initialValue, 0, 100);
        if (initialValue == 100) 
        {
            material.color = colors[4];
            if (water.tankIsClean == true)
                NewFish(true);

        }
       // Debug.Log("CurrentColor " + initialValue);
       // Debug.Log("NewValue " + newValue);

        hungerControl.speed = (4 - index)* (4 - index);
        fish.speed = 1 / hungerControl.speed;


    }
    void NewFish(bool Success)
    {
        hungerControl.FeedFish();
        water.tankIsClean = false;
        idealTemp = (int)Random.Range(10, tempBar.maxValue);
        if(Success ==true)
        {
            lifeSystem.successfulFish++;
        }
    }
}
