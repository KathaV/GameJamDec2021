using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("a"))
        {
            player.transform.localPosition += new Vector3(-playerSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey("d"))
        {   
            player.transform.localPosition += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        } 

        if (Input.GetKey("w"))
        {   
            player.transform.localPosition += new Vector3(0f, playerSpeed * Time.deltaTime, 0f);
        }
    }
}
