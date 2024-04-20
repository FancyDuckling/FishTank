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
    public GameObject fish;

    
    private int curentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;

    

    void Start()
    {
        tankIsClean = true;
    }
    

    void Update()
    {
       /* if (Input.GetKey(KeyCode.E)) //Clean the aquarium
        {
            tankIsClean = true;
            

        }*/

        if (Input.GetKey(KeyCode.F)) //feed the fish
        {
            tankIsClean = false;
            
        }


        if (!tankIsClean)
        {
            TransitionToDirty();
        }

        if (tankIsClean)
        {
            TransitionToClean();
        }
       

    }

    void TransitionToDirty()
    {
        targetPoint += Time.deltaTime/time;
        material.color = Color.Lerp(colors[curentColorIndex], colors[targetColorIndex],targetPoint);
       // PlacePoop(); haha funny effect
        if (targetPoint >= 1f)
        {
            PlacePoop();
            targetPoint = 0f;
            curentColorIndex = targetColorIndex;
            targetColorIndex++;
            
            if (targetColorIndex >= colors.Length)
            {
                targetColorIndex = 3;
            }
        }

        
    }

    void TransitionToClean()
    {
        

        targetPoint += Time.deltaTime / time;
        material.color = Color.Lerp(colors[curentColorIndex], colors[0], targetPoint);

        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            curentColorIndex = 0;
            targetColorIndex = 1;

            

        }



    }

    void PlacePoop()
    {
        
     GameObject poops = Instantiate(poop, fish.transform.position, Quaternion.identity);


    }


   
}
