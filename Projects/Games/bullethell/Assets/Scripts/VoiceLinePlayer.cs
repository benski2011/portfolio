using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLinePlayer : MonoBehaviour
{

    [SerializeField]
    public List<AudioClip> audioClips;
    int currentAudioTrack = 0;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
         audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            increaseAudioTrack();
        }
    }

    public void increaseAudioTrack()
    {
        audio.Stop();
        
        if (currentAudioTrack < audioClips.Count-1)
        {
            Debug.Log(currentAudioTrack);
            audio.clip = audioClips[currentAudioTrack];
            audio.Play();
            currentAudioTrack++;
        }
       
    }
}
