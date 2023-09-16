using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject enemyToActivate;
    public float activationProbability;

    public float GetActivationProbability()
    {
        return activationProbability;
    }

    public void AddActivationProbability(float activationProbability)
    {
        this.activationProbability = activationProbability >= 100 ? 100 : activationProbability <= 0 ? 0 : activationProbability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float randomValue = Random.Range(0, 101);

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
