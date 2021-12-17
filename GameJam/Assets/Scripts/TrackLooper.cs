using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLooper : MonoBehaviour
{
    public AudioSource loopPart;
    public AudioClip introPart;
    public string trackName;
    private float startVolume;

    // Start is called before the first frame update
    public void Play()
    {
        loopPart.PlayOneShot(introPart);
        loopPart.PlayScheduled(AudioSettings.dspTime + introPart.length);

        startVolume = loopPart.volume;
        Debug.Log(startVolume);
    }

    // Update is called once per frame
    public void Stop()
    {
        loopPart.Stop();
    }

    public void Mute()
    {
        loopPart.volume = 0 ;
    }

    public void Unmute()
    {
        loopPart.mute = false;
    }

    public void FadeMute(float fadeTime)
    {
        StartCoroutine(FadeOut(fadeTime));
    }
    public void FadeUnmute(float fadeTime)
    {
        StartCoroutine(FadeIn(fadeTime));
    }

    private IEnumerator FadeOut( float FadeTime)
    {
        //Debug.Log("start volume: " + startVolume);
        while (loopPart.volume > 0)
        {

            //Debug.Log("Decrease by " + (startVolume * Time.deltaTime / FadeTime));
            loopPart.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        Debug.Log("Done fading out, and faded out is playing? " + loopPart.isPlaying);
        //audioSource.volume = startVolume;
    }

    private IEnumerator FadeIn(float FadeTime)
    {
        //Debug.Log("start volume: " + startVolume);
        while (loopPart.volume < startVolume)
        {
            //Debug.Log("Increase by "+ (startVolume * Time.deltaTime / FadeTime));
            loopPart.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        Debug.Log("Done fading in, and faded in is playing ? " + loopPart.isPlaying);
       
        //audioSource.Stop();
        //audioSource.volume = startVolume;
    }

    public string getName()
    {
        return name;
    }

}
