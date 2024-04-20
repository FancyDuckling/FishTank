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
        if (Input.GetKey(KeyCode.E))
        {
            tankIsClean = true;

        }

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
       
        
            
        
        
        
        
        /*TransitionToClean();


        if (fishIsFull)
            TransitionToDirty();
        else
            targetColorIndex = 0;*/




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
            PlacePoop();
            if (targetColorIndex >= colors.Length)
            {
                targetColorIndex = 3;
            }
        }

        /*if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            curentColorIndex = targetColorIndex;
            targetColorIndex++;
            if (targetColorIndex == colors.Length)
            {
                targetColorIndex = 3;
                
                
            }
            
           
                
        }*/
    }

    void TransitionToClean()
    {
        //material.color = colors[0];

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
        // Instantiate two poop objects
        GameObject poop1 = Instantiate(poop, transform.position, Quaternion.identity);
        GameObject poop2 = Instantiate(poop, transform.position, Quaternion.identity);

       
        Vector3 offset1 = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        Vector3 offset2 = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        poop1.transform.position += offset1;
        poop2.transform.position += offset2;
    }

    void CleanPoop()
    {

    }
}
