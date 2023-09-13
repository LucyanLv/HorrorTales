using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject enemyToActivate;
    public float activationProbability = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float randomValue = Random.value;

            if (randomValue <= activationProbability)
            {
                enemyToActivate.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyToActivate.SetActive(false);
        }
    }
}
