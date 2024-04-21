using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTheFish : MonoBehaviour
{
    public Slider hungerBar;
    public float hunger;
    public float speed = 1;
    public float maxHunger = 100f;
    public bool feedTheFish = false;
    

    public PoopWater poopWaterScript;


    void Start()
    {
        hunger = maxHunger;
        poopWaterScript = FindObjectOfType<PoopWater>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            feedTheFish = true;
            FeedFish();
        }
        else
        {
            HungerTimer();
            feedTheFish=false;
            poopWaterScript.fishIsFull = true;
        }


        /* if (feedTheFish)
        {
            FeedFish();
           
        }

        else
        {
            
            HungerTimer();

        }*/


    }

    void FeedFish()
    {
        hunger = maxHunger;
        feedTheFish = false;

        if (poopWaterScript != null)
        {
            poopWaterScript.fishIsFull = true;
            
        }
        

    }

    void HungerTimer()
    {
        
        hungerBar.value = hunger;
        hunger -= speed * Time.deltaTime;

        

    }

    
}
