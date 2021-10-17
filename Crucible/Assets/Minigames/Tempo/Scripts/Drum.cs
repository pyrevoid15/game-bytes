using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour
{
    public float excellentWindow;
    public float goodWindow;
    public float badWindow;
    private SongManager songManager;
    private FeedbackRenderer feedbackRenderer;

    public Queue<DrumNote> drumNotes = new Queue<DrumNote>();

    public void initialize(float excellentWindow, float goodWindow, float badWindow, SongManager songManager, FeedbackRenderer feedbackRenderer)
    {
        this.excellentWindow = excellentWindow;
        this.goodWindow = goodWindow;
        this.badWindow = badWindow;
        this.songManager = songManager;
        this.feedbackRenderer = feedbackRenderer;
    }

    private void checkForDespawnTiming()
    {
        if (drumNotes.Count == 0)
            return;

        DrumNote note = drumNotes.Peek();
        if (songManager.getCurrentSongTime() - note.hitTime > badWindow)
        {
            drumNotes.Dequeue();
            Destroy(note.gameObject);
            feedbackRenderer.renderMiss();
        }
    }

    // If drum note is present in queue, removes the drum and returns the score for the note
    public int hitDrum()
    {
        if (drumNotes.Count == 0) return -1;

        int score = 0;
        DrumNote note = drumNotes.Dequeue();
        if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < excellentWindow) score = 3;
        else if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < goodWindow) score = 2;
        else if (Mathf.Abs(songManager.getCurrentSongTime() - note.hitTime) < badWindow) score = 1;
        Destroy(note.gameObject);
        return score;
    }

    public void selectDrum()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(50, 50, 200, 255);
    }

    public void deselectDrum()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(181, 201, 219, 255);
    }

    // Update is called once per frame
    void Update()
    {
        checkForDespawnTiming();
    }
}
