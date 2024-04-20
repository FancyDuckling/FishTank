using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopWater : MonoBehaviour
{
    public Material material;
    public Color[] colors;
    public float time; //time between changing colors
    public bool tankIsClean = false;
    public bool fishIsFull = false;
    public GameObject poop;
    
    private int curentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    
   void Start()
    {
        targetColorIndex = 0;
    }
    

    void Update()
    {
        TransitionToClean();


        if (fishIsFull)
            TransitionToDirty();
        else
            targetColorIndex = 0;




    }

    void TransitionToDirty()
    {
        targetPoint += Time.deltaTime/time;
        material.color = Color.Lerp(colors[curentColorIndex], colors[targetColorIndex],targetPoint); 

        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            curentColorIndex = targetColorIndex;
            targetColorIndex++;
            if (targetColorIndex == colors.Length)
            {
                targetColorIndex = 3;
                tankIsClean = false;
                fishIsFull = false;
            }
            
           
                
        }
    }

    void TransitionToClean()
    {
       if (Input.GetKey(KeyCode.E))
       {
            
            tankIsClean = true;
            

            targetColorIndex = 0;
       }
       

    }
}
