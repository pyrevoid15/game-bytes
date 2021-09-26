using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumNoteSpawner : MonoBehaviour
{
    public float startTime;
    // Start is called before the first frame update
    void Awake()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (BeatMap.drumNoteInfo[0].time - (Time.time - startTime) < BeatMap.approachTime) {
            // spawn note
            BeatMap.drumNoteInfo.RemoveAt(0);
        }
    }
}
