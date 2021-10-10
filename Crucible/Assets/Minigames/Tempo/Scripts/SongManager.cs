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
        gameObject.GetComponent<AudioSource>().PlayScheduled(AudioSettings.dspTime + 0.85);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
