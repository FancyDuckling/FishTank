using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoop : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CleaningEquipment"))
        {
            Destroy(gameObject);
        }
    }
}
