using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckDetection : MonoBehaviour
{
    private GameObject player;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Entered!");
        if (other.tag=="Player")
        {
            Debug.Log("Player hidden");
            other.gameObject.GetComponent<Hideable>().setHidden(true);
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Staying!");
        if (other.tag == "Player")
        {
            //Debug.Log("Player hidden");
            other.gameObject.GetComponent<Hideable>().setHidden(true); 
            

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player no longer hidden");
            other.gameObject.GetComponent<Hideable>().setHidden(false);
            

        }
    }
}
