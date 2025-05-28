using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticles : MonoBehaviour
{
    GameObject player;
    ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(player)
        {
            StartCoroutine(destroyParticles());
        }
    }

    IEnumerator destroyParticles()
    {
        _particleSystem.GetComponent<Collider>().enabled = false;
        _particleSystem.Stop();
        yield return new WaitForSeconds(1);
        GameObject.Destroy(this.gameObject);
    }
}
