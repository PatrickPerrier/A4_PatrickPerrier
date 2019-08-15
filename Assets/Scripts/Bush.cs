using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pLeafs;

    [SerializeField]
    AudioClip death;

    private bool hasColided;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = death;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boomerang" && hasColided == false)
        {
            Instantiate(pLeafs, gameObject.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            transform.GetChild(0).gameObject.SetActive(false);
            hasColided = true;
        }
    }
}
