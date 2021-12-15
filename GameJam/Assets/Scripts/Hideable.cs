using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    private bool hiddenStatus = false;
   
    public void setHidden(bool status)
    {
        hiddenStatus = status;
    }

    public bool getHidden()
    {
        return hiddenStatus;
    }
}
