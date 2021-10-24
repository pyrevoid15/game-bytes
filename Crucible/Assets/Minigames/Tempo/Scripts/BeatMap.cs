using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMap : MonoBehaviour
{
    public TextAsset beatMapFile;
    private BeatMapBlueprint beatMapBlueprint;
    public float approachTimeDrum;
    public float approachTimeGuitar;
    public int numNotesDrum;
    public int numNotesGuitar;
    public float excellentWindow;
    public float goodWindow;
    public float badWindow;
    public float[] noteTimesDrum;
    public float[] noteTimesGuitar;
    public int[] noteLocationsDrum;
    public int[] noteLocationsGuitar;
    public int[] noteTypesGuitar;
    public float songTime;

    private class BeatMapBlueprint
    {
        public float approachTimeDrum;
        public float approachTimeGuitar;
        public int numNotesDrum;
        public int numNotesGuitar;
        public float excellentWindow;
        public float goodWindow;
        public float badWindow;
        public float[] noteTimesDrum;
        public float[] noteTimesGuitar;
        public int[] noteLocationsDrum;
        public int[] noteLocationsGuitar;
        public int[] noteTypesGuitar;
        public float songTime;
    }

    void Awake()
    {
        beatMapBlueprint = JsonUtility.FromJson<BeatMapBlueprint>(beatMapFile.text);
        approachTimeDrum = beatMapBlueprint.approachTimeDrum;
        approachTimeGuitar = beatMapBlueprint.approachTimeGuitar;
        numNotesDrum = beatMapBlueprint.numNotesDrum;
        numNotesGuitar = beatMapBlueprint.numNotesGuitar;
        excellentWindow = beatMapBlueprint.excellentWindow;
        goodWindow = beatMapBlueprint.goodWindow;
        badWindow = beatMapBlueprint.badWindow;
        noteTimesDrum = beatMapBlueprint.noteTimesDrum;
        noteTimesGuitar = beatMapBlueprint.noteTimesGuitar;
        noteLocationsDrum = beatMapBlueprint.noteLocationsDrum;
        noteLocationsGuitar = beatMapBlueprint.noteLocationsGuitar;
        noteTypesGuitar = beatMapBlueprint.noteTypesGuitar;
        songTime = beatMapBlueprint.songTime;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
