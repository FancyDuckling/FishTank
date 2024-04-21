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

    private int poopsDestroyed = 0;



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

            // Calculate the target color index dynamically based on the current index
            if (poopsDestroyed % 3 == 0 && poopsDestroyed != 0) // Every three destroyed poops
            {
                curentColorIndex--; // Decrease current index
                if (curentColorIndex < 0) // Clamp the index to 0
                {
                    curentColorIndex = 0;
                }
            }

            // If tank becomes clean while transitioning, stop at clean color
            if (tankIsClean)
            {
                curentColorIndex = 0;
            }
        }

        /* targetPoint += Time.deltaTime / time;
         material.color = Color.Lerp(colors[curentColorIndex], colors[0], targetPoint);

         if (targetPoint >= 1f)
         {
             targetPoint = 0f;
             curentColorIndex = 0;

             // Calculate the target color index dynamically based on the current index
             targetColorIndex = curentColorIndex + 1;
             if (targetColorIndex >= colors.Length)
             {
                 targetColorIndex = 1;
             }
         }*/



        /*targetPoint += Time.deltaTime / time;
        material.color = Color.Lerp(colors[curentColorIndex], colors[0], targetPoint);

        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            curentColorIndex = 0;
            targetColorIndex = 1;

            

        }*/



    }

    void PlacePoop()
    {
        // Stop placing poops if current color index is 3
        if (curentColorIndex >= 3)
            return;

        GameObject poops = Instantiate(poop, fish.transform.position, Quaternion.identity);
        poops.GetComponent<DestroyPoop>().poopWaterScript = this;

    }

    public void IncrementPoopsDestroyed()
    {
        poopsDestroyed++;
        if (poopsDestroyed >= 3) 
        {
            tankIsClean = true;
            poopsDestroyed = 0; // Reset the counter
        }
    }


    /*void DestroyAllPoop()
    {
        GameObject[] allPoops = GameObject.FindGameObjectsWithTag("Poop"); // Assuming the poop GameObjects have a "Poop" tag
        foreach (GameObject poopObj in allPoops)
        {
            Destroy(poopObj);
        }
    }*/
}
