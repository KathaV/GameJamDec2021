using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    private float AvgSecondsDelay = 3;

    private float LookDelay = 5;
    private float TurnDelay = 3;
    private bool isLooking = false;
    private bool isTurning = false;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(turnIntermittently());
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator turnIntermittently()
    {

        Debug.Log("Starting at" + Time.realtimeSinceStartup);
        float offset = AvgSecondsDelay / 3;

        Debug.Log(offset);
        float timeDelay = AvgSecondsDelay + Random.Range(-offset, offset);
        yield return new WaitForSeconds(timeDelay);
        StartCoroutine(Turn(false));
    }

    IEnumerator Turn(bool lookingAway)
    {
        sprite.color = new Color(1, 0, 0, 1);
        float offset = TurnDelay / 3;
        Debug.Log(offset);

        float randomOff = Random.Range(-offset, offset);
        Debug.Log("random offset " + randomOff);
        float timeDelay = TurnDelay + randomOff;
        Debug.Log("Turning at " + Time.realtimeSinceStartup + " for " + timeDelay);
        isTurning = true;
        yield return new WaitForSeconds(timeDelay);
        if (!lookingAway) {

            StartCoroutine(Look());
        }
        else
        {
            StartCoroutine(turnIntermittently());
        }

    }

    IEnumerator Look()
    {
        // TODO: look code
        isLooking = true;
        isTurning = false;

        float offset = LookDelay / 3;
        float randomOff = Random.Range(-offset, offset);
        Debug.Log("random offset " + randomOff);
        float timeDelay = LookDelay + randomOff;

        Debug.Log("Looking at " + Time.realtimeSinceStartup + " for " + timeDelay);
        // Change color (temporary visual cue) and wait
        sprite.color = new Color(1, 1, 0, 1);
        yield return new WaitForSeconds(timeDelay);

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
