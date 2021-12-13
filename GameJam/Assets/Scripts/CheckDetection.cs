using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDetection : MonoBehaviour
{
    private GameObject player;
    private Hideable hideable;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // based/sourced from: https://answers.unity.com/questions/942561/percentage-of-collider-within-a-trigger-area-c.html
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered!");
        if (other.tag=="Player")
        {
            Debug.Log("Player hidden");
            hideable = other.gameObject.GetComponent<Hideable>();
            hideable.setHidden(true);        
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Staying!");
        if (other.tag == "Player")
        {
            Debug.Log("Player hidden");
            hideable = other.gameObject.GetComponent<Hideable>();
            hideable.setHidden(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player no longer hidden");
            hideable = other.gameObject.GetComponent<Hideable>();
            hideable.setHidden(false);

        }
    }
}
