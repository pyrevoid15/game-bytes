using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public BeatMap beatMap;
    public Text guitarScore;
    public Text drumScore;
    private float startTime;
    private float endTime;

    public float getCurrentSongTime()
    {
        return (float)AudioSettings.dspTime - startTime;
    }

    private void endScene()
    {
        Score.player1Score = int.Parse(guitarScore.text);
        Score.player2Score = int.Parse(drumScore.text);
        Score.player1MaxScore = beatMap.numNotesGuitar * 3;
        Score.player2MaxScore = beatMap.numNotesDrum * 3;
        Debug.Log("SCENE ENDED");
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = (float)AudioSettings.dspTime;
        endTime = beatMap.songTime;
        float calibration = 0.75f; // higher value means later song play back (i.e. notes appear "earlier")
        gameObject.GetComponent<AudioSource>().PlayScheduled(AudioSettings.dspTime + calibration);
    }

    // Update is called once per frame
    void Update()
    {
        if (getCurrentSongTime() > endTime)
        {
            endScene();
        }
    }
}
