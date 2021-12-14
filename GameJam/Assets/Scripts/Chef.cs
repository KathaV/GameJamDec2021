using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    private float idleDelay = 3;

    private float LookDelay = 5;
    private float TurnDelay = 3;
    private bool isLooking = false;
    private bool isTurning = false;
    private SpriteRenderer sprite;
    private GameObject player;
    private Hideable playerHideScript;
    public GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(LookAway());
        player = GameObject.FindWithTag("Player");
        playerHideScript = player.GetComponent<Hideable>();
        gameOverText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LookAway()
    {
        isTurning = false;
        isLooking = false;
        // set green colour (temporary visual cue for chef state change)
        sprite.color = new Color(0, 1, 0, 1);
        Debug.Log("Starting at" + Time.realtimeSinceStartup);


        // random offset to change duration slightly
        float offset = idleDelay / 3;
        Debug.Log(offset);

        // Calculate delay to include offset, then wait
        float timeDelay = idleDelay + Random.Range(-offset, offset);
        yield return new WaitForSeconds(timeDelay);

        //Begin to turn towards player
        StartCoroutine(Turn(false));
    }

    IEnumerator Turn(bool lookingAway)
    {
        isTurning = true;
        isLooking = false;
        // set yellow colour (temporary visual cue for chef state change)
        sprite.color = new Color(1, 1, 0, 1);

        // random offset to change duration slightly
        float offset = TurnDelay / 3;
        Debug.Log(offset);
        float randomOff = Random.Range(-offset, offset);
        Debug.Log("random offset " + randomOff);

        // Calculate delay to include offset, then wait
        float timeDelay = TurnDelay + randomOff;
        Debug.Log("Turning at " + Time.realtimeSinceStartup + " for " + timeDelay);
        yield return new WaitForSeconds(timeDelay);

        // Depending on if turning towards or away from player, do appropriate action
        if (!lookingAway) {

            StartCoroutine(Look());
        }
        else
        {
            StartCoroutine(LookAway());
        }

    }

    IEnumerator Look()
    {
        // Set appropriate variables
        isLooking = true;
        isTurning = false;

        // set red colour (temporary visual cue for chef state change)
        sprite.color = new Color(1, 0, 0, 1);

        // random offset to change duration slightly
        float offset = LookDelay / 3;
        float randomOff = Random.Range(-offset, offset);
        Debug.Log("random offset " + randomOff);

        float Timer = LookDelay + randomOff;
        Debug.Log("Looking at " + Time.realtimeSinceStartup + " for " + Timer);

        // Look for player if visible.

        while (Timer > 0)
        {
            if (!playerHideScript.getHidden())
            {
                Debug.Log("Chef has seen player!");
                //TODO: Add gameover and other actions upon detection
                
                gameOverText.gameObject.SetActive(true);
                yield break;
            }
            else
            {
                //Debug.Log("Chef can't see player!");
                yield return null;
            }
            Timer -= Time.deltaTime;
        }

        //Look away
        StartCoroutine(Turn(true));
    }


    bool getIsTurning()
    {
        return isTurning;
    }

    bool getIsLooking()
    {
        return isLooking;
    }

}
