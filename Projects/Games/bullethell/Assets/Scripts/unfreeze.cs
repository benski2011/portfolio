using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Class is used to freeze/unfreeze the game
/// </summary>
public class unfreeze : MonoBehaviour
{
    VideoPlayer video;
    ulong frames = 0;
        // Start is called before the first frame update
    void Start()
    {
        video = this.GetComponent<VideoPlayer>();
        frames = video.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("frame"+video.frame);
        if ((ulong)video.frame == frames-3)
        {
            Time.timeScale = 1;
            //Debug.Log("vid done");
        }
    }
}
