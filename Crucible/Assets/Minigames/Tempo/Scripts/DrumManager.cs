using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumManager : MonoBehaviour
{
    public BeatMap beatMap;
    public DrumNote drumNotePrefab;
    public Drum[] drums;
    public SongManager songManager;

    private int noteNum;


    public void checkForNoteSpawn()
    {
        if (noteNum == beatMap.numNotesDrum) return;

        if (beatMap.noteTimesDrum[noteNum] - songManager.getCurrentSongTime() < beatMap.approachTimeDrum)
        {
            int location = beatMap.noteLocationsDrum[noteNum];
            
            // spawn a note
            DrumNote drumNote = Instantiate(drumNotePrefab, drums[location].transform.position, Quaternion.identity);

            // initialize note hit time and shrink rate
            drumNote.initialize(beatMap.noteTimesDrum[noteNum], beatMap.approachTimeDrum);

            // send note to the corresponding drum
            drums[location].drumNotes.Enqueue(drumNote);

            // move onto the next note
            noteNum++;
        }
    }


    void Start()
    {
        noteNum = 0;
        for (int i = 0; i < drums.Length; i++)
        {
            drums[i].initialize(beatMap.excellentWindow, beatMap.goodWindow, beatMap.badWindow, songManager);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        checkForNoteSpawn();
    }
}
