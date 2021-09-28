using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumNoteSpawner : MonoBehaviour
{
    public float startTime;
    public BeatMap beatMap;

    private int noteNum;
    // Start is called before the first frame update
    void Awake()
    {
        startTime = Time.time;
        noteNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (noteNum == beatMap.numNotesDrum) return;

        if (beatMap.noteTimesDrum[noteNum] - (Time.time - startTime) < beatMap.approachTimeDrum) {
            // spawn note
            Debug.Log("Spawned drum note number " + noteNum.ToString());
            noteNum++;
        }
    }
}
