using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMapLoader : MonoBehaviour
{
    public TextAsset beatMapFile;
    public BeatMap beatMap;
    public List<DrumNoteInfo> drumNoteInfo;

    public class BeatMap
    {
        public float approachTimeDrum;
        public float approachTimeGuitar;
        public float numNotesDrum;
        public float numNotesGuitar;
        public float excellentWindow;
        public float goodWindow;
        public float badWindow;
        public float[] noteTimesDrum;
        public float[] noteTimesGuitar;
        public int[] noteLocationsDrum;
        public int[] noteLocationsGuitar;
        public int[] noteTypesGuitar;
    }

    public BeatMapLoader(string beatMapPath)
    {
        beatMapFile = Resources.Load(beatMapPath) as TextAsset;

    }

    

    public struct DrumNoteInfo
    {
        public float time;
        public int location;

        public DrumNoteInfo(float v1, int v2) : this()
        {
            time = v1;
            location = v2;
        }
    }


    private void initializeNotes()
    {
        for (int i = 0; i < numNotes; i++)
        {
            drumNoteInfo[i] = new DrumNoteInfo(drumNoteTimes[i], drumNoteLocations[i]);
        }
    }
}
