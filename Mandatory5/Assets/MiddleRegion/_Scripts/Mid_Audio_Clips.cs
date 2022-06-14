using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Audio_Clips : MonoBehaviour
{
    public AudioClip[] sounds = new AudioClip[2];                       //Creates a public array of 2 Audio Clips.

    public void PlayAudioOne()
    {
        GetComponent<AudioSource>().clip = sounds[0];                   //Gets sound 1, and plays it.
        GetComponent<AudioSource>().Play();
    }

    public void PlayAudioTwo()
    {
        GetComponent<AudioSource>().clip = sounds[1];                   //Gets sound 2, and plays it.
        GetComponent<AudioSource>().Play();
    }


}
