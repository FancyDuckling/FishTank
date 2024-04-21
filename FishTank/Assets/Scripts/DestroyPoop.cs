using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoop : MonoBehaviour
{

    public PoopWater poopWaterScript;


    void Start()
    {
        poopWaterScript = FindObjectOfType<PoopWater>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CleaningEquipment"))
        {
            poopWaterScript.IncrementPoopsDestroyed(); // Increment the counter in PoopWater script
            Destroy(gameObject);
        }
    }
}
