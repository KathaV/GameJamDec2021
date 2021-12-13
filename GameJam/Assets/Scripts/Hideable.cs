using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    private bool hiddenStatus = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setHidden(bool status)
    {
        hiddenStatus = status;
    }

    public bool getHidden()
    {
        return hiddenStatus;
    }
}
