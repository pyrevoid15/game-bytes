using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fret : MonoBehaviour
{
    public float excellentWindow;
    public float goodWindow;
    public float badWindow;
    private SongManager songManager;

    public Queue<GuitarNote> guitarNotes = new Queue<GuitarNote>();

    public void initialize(float excellentWindow, float goodWindow, float badWindow, SongManager songManager)
    {
        this.excellentWindow = excellentWindow;
        this.goodWindow = goodWindow;
        this.badWindow = badWindow;
        this.songManager = songManager;
    }

    private void checkForDespawnTiming()
    {
        if (guitarNotes.Count == 0)
            return;

        GuitarNote note = guitarNotes.Peek();
        if (songManager.getCurrentSongTime() - note.hitTime > badWindow)
        {
            guitarNotes.Dequeue();
            Destroy(note.gameObject);
        }
    }

    public float strumFret()
    {/* TODO:
        if (guitarNotes.Count == 0) return 0f;

        float score = 0f;
        GuitarNote note = guitarNotes.Dequeue();
        if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < excellentWindow) score = 3f;
        else if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < goodWindow) score = 2f;
        else if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < badWindow) score = 1f;
        Destroy(note.gameObject);
        return score;*/
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkForDespawnTiming();
    }
}
