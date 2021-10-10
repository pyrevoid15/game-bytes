using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour
{
    public float excellentWindow;
    public float goodWindow;
    public float badWindow;
    private SongManager songManager;

    public Queue<DrumNote> drumNotes = new Queue<DrumNote>();

    public void initialize(float excellentWindow, float goodWindow, float badWindow, SongManager songManager)
    {
        this.excellentWindow = excellentWindow;
        this.goodWindow = goodWindow;
        this.badWindow = badWindow;
        this.songManager = songManager;
    }

    void Start()
    {
        
    }

    private void checkForDespawnTiming()
    {
        if (drumNotes.Count == 0)
            return;

        DrumNote note = drumNotes.Peek();
        if (songManager.getCurrentSongTime() - note.hitTime > badWindow)
        {
            drumNotes.Dequeue();
            // send note to scoring/some feedback
            Destroy(note.gameObject);
        }
    }

    // If drum note is present in queue, removes the drum and returns the score for the note
    public float hitDrum()
    {
        if (drumNotes.Count == 0) return 0f;

        float score = 0f;
        DrumNote note = drumNotes.Dequeue();
        if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < excellentWindow) score = 3f;
        else if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < goodWindow) score = 2f;
        else if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < badWindow) score = 1f;
        Destroy(note.gameObject);
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        checkForDespawnTiming();
    }
}
