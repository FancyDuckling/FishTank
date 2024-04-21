using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoop : MonoBehaviour
{

    public PoopWater poopWaterScript;

    // Reference to the SoundManager
    private SoundManager soundManager;

    void Start()
    {
        poopWaterScript = FindObjectOfType<PoopWater>();
        // Get reference to the SoundManager instance
        soundManager = SoundManager.Instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CleaningEquipment"))
        {
            poopWaterScript.IncrementPoopsDestroyed(); // Increment the counter in PoopWater script
            Destroy(gameObject);
            // Play random sound between index 3-6
            if (soundManager != null)
            {
                int randomSoundIndex = Random.Range(7, 9);
                soundManager.PlaySoundEffect(randomSoundIndex);
            }
        }
    }
}
