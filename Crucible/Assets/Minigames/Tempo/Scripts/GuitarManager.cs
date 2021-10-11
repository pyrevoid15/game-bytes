using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarManager : MonoBehaviour
{
    public BeatMap beatMap;
    public GuitarNote guitarNotePrefab;
    public Fret[] frets;
    public SongManager songManager;
    public float score;

    private int noteNum;

    private void checkForNoteSpawn()
    {
        if (noteNum == beatMap.numNotesGuitar) return;

        if (beatMap.noteTimesGuitar[noteNum] - songManager.getCurrentSongTime() <= beatMap.approachTimeGuitar)
        {
            int location = beatMap.noteLocationsGuitar[noteNum];

            // spawn a note
            GuitarNote guitarNote = Instantiate(guitarNotePrefab, frets[location].transform.position - new Vector3(0, 8.5f, 0), Quaternion.identity);

            // initialize note hit time and velocity
            guitarNote.initialize(beatMap.noteTimesGuitar[noteNum], beatMap.noteTypesGuitar[noteNum], beatMap.approachTimeGuitar);

            // send note to the corresponding fret
            frets[location].guitarNotes.Enqueue(guitarNote);

            // move onto the next note
            noteNum++;
        }
    }

    private void checkForInput()
    {
        //TODO
    }

    // Start is called before the first frame update
    void Start()
    {
        noteNum = 0;
        for (int i = 0; i < frets.Length; i++)
        {
            frets[i].initialize(beatMap.excellentWindow, beatMap.goodWindow, beatMap.badWindow, songManager);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForNoteSpawn();
        checkForInput();
    }
}
