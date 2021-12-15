using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    // count of Key Fragments
    private int fragCount = 0;
    private int fragTotal = 0;
    private GameObject[] fragList;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        fragList = GameObject.FindGameObjectsWithTag("Fragment");
        fragTotal = fragList.Length;
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fragment" && !other.gameObject.GetComponent<Collectible>().isCollected())
        {
            fragCount++;
            Debug.Log("Fragment found! Frag#" + fragCount+"\n"+(fragTotal-fragCount)+" more to go!");

            other.gameObject.GetComponent<Collectible>().collect();
            if (fragCount==fragTotal)
            {

                finished = true;
            }
        }

    }

    void isFinished()
    {
        return finished;
    }

}
