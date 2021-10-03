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

    // Update is called once per frame
    void Update()
    {
        checkForDespawnTiming();
    }
}
