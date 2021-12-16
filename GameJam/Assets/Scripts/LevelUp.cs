using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    private GameObject msgController;
    private MessageController msgScript;
    void Start()
    {

        msgController = GameObject.FindGameObjectWithTag("MessageController");
        msgScript = msgController.GetComponent<MessageController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            KeyCollector collectorScript = other.gameObject.GetComponent<KeyCollector>();
            // check if player has collected all keys
            if (collectorScript.isFinished())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            // else prompt player to collect all
            else
            {
                msgScript.broadcast("You haven't collected all the keys! You need " + collectorScript.getRemaining() + " more to escape...");
            }
        }
    }
}
