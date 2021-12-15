using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private bool collected = false;
    private Renderer rend;
    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        sfx = GetComponent<AudioSource>();
    }

    public void collect()
    {
        if (!collected)
        {
            StartCoroutine(Collecting());
        }
        
    }

    public bool isCollected()
    {
        return collected;
    }

    IEnumerator Collecting()
    {
        collected = true;
        rend.enabled = false;
        sfx.Play();
        yield return new WaitForSeconds(sfx.clip.length);
        Destroy(gameObject);
    }

}