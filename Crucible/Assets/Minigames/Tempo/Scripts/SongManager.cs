using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    private float startTime;

    public float getCurrentSongTime()
    {
        return (float)AudioSettings.dspTime - startTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = (float)AudioSettings.dspTime;
        float calibration = 0.75f; // higher value means later song play back (i.e. notes appear "earlier")
        gameObject.GetComponent<AudioSource>().PlayScheduled(AudioSettings.dspTime + calibration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
