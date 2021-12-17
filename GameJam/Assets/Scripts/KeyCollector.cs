using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    // count of Key Fragments
    private int fragCount = 0;
    private int fragTotal = 0;
    private GameObject[] fragList;
    private bool finished = false;
    public GameObject keyTxt;
    private GameObject msgController;

    // Start is called before the first frame update
    void Start()
    {
        fragList = GameObject.FindGameObjectsWithTag("Fragment");
        fragTotal = fragList.Length;
        msgController = GameObject.FindGameObjectWithTag("MessageController");
        msgController.GetComponent<MessageController>().broadcast("Collect " + fragTotal + " keys to escape!");
        keyTxt.GetComponent<TextMeshProUGUI>().text = "" + fragCount + "/" + fragTotal;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fragment" && !other.gameObject.GetComponent<Collectible>().isCollected())
        {
            fragCount++;
            Debug.Log("Fragment found! Frag#" + fragCount+"\n"+(fragTotal-fragCount)+" more to go!");
            keyTxt.GetComponent<TextMeshProUGUI>().text = "" + fragCount + "/" + fragTotal;
            other.gameObject.GetComponent<Collectible>().collect();
            if (fragCount==fragTotal)
            {
                finished = true;
                msgController.GetComponent<MessageController>().broadcast("You've collected all the keys! Find and open the door to escape...");
            }
        }

    }

    public bool isFinished()
    {
        return finished;
    }

    public int getRemaining()
    {
        return fragTotal - fragCount;
    }

    public int getCount()
    {
        return fragCount;
    }
    public int getTotal()
    {
        return fragTotal;
    }

}
