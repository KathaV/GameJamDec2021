using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    public GameObject msgBox;
    public GameObject mainMsg;
    public GameObject smallMsg;
    public float msgDuration = 5.5f;
    private bool isBroadcasting = false;
    private float timer = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        hideMsg();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBroadcasting)
        {
            if (Input.GetKey("e") || timer <= 0)
            {
                timer = 0;
                hideMsg();
            }
            else
            {
                timer -= Time.deltaTime;
            }
            

        }

    }

    void showMsg()
    {

        isBroadcasting = true;
        msgBox.SetActive(true);
        mainMsg.SetActive(true);
        smallMsg.SetActive(true);
    }

    void hideMsg()
    {
        isBroadcasting = false;
        msgBox.SetActive(false);
        mainMsg.SetActive(false);
        smallMsg.SetActive(false);
    }
    public void broadcast(string msg)
    {
        showMsg();
        mainMsg.GetComponent<TextMeshProUGUI>().text = msg;
        timer = msgDuration;
    }
}

