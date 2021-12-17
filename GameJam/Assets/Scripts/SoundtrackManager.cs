using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public TrackLooper awakeTrack;
    public TrackLooper switchTrack;
    private TrackLooper currentTrack;
    private TrackLooper tmp;
    public float fadeTime = 30f;
    // Start is called before the first frame update
    void Start()
    {
        awakeTrack.Play();
        currentTrack = awakeTrack;
        switchTrack.Play();
        switchTrack.Mute();
        //StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(32f);
        Debug.Log("Switching");
        SwitchTracks();
    }

    // Switch track with another STARTING where the other left off
    public void SwitchTracks()
    {
        Debug.Log("Switching");
        Debug.Log("switchin to " + switchTrack.getName());

        Debug.Log("fading " + currentTrack.getName());
        switchTrack.FadeUnmute(fadeTime);
        currentTrack.FadeMute(fadeTime);
        tmp = currentTrack;
        currentTrack = switchTrack;
        switchTrack = tmp;        
    }
}
