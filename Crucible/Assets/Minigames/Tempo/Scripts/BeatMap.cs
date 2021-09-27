using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DrumNoteInfo {
    public float time;
    public int location;

    public DrumNoteInfo(float v1, int v2) : this() {
        time = v1;
        location = v2;
    }
}
public class BeatMap : MonoBehaviour
{
    public static float approachTime;
    public static float excellentWindow;
    public static float goodWindow;
    public static float badWindow;
    public static int numNotes = 3;
    public static float[] drumNoteTimes = { 1, 2, 3 };
    public static int[] drumNoteLocations = { 0, 0, 1 };
    public static List<DrumNoteInfo> drumNoteInfo = new List<DrumNoteInfo>(numNotes);



    private void initializeNotes() {
        for (int i = 0; i < numNotes; i++) {
            drumNoteInfo[i] = new DrumNoteInfo(drumNoteTimes[i], drumNoteLocations[i]);
        }
    }
}
