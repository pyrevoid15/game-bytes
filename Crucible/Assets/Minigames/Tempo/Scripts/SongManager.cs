using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public BeatMap beatMap;
    public Text guitarScore;
    public Text drumScore;
    private float startTime;
    private float endTime;
    private AudioSource song;

    public float getCurrentSongTime()
    {
        return (float)AudioSettings.dspTime - startTime - 3;
    }

    private void endScene()
    {
        SceneManager.LoadScene("Results_Scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = (float)AudioSettings.dspTime;
        endTime = beatMap.songTime;
        float calibration = -0.5f; // higher value means later song play back (i.e. notes appear "earlier")
        song = gameObject.GetComponent<AudioSource>();
        song.clip = Resources.Load<AudioClip>(LevelState.songFilename);
        song.PlayScheduled(AudioSettings.dspTime + calibration + 3);

        Score.player1MaxScore = beatMap.numNotesGuitar * 3;
        Score.player2MaxScore = beatMap.numNotesDrum * 3;
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
