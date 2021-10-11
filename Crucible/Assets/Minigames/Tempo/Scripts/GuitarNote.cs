using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNote : MonoBehaviour
{
    public float hitTime;
    public int chordNote;
    public Vector3 velocity;

    public void initialize(float hitTime, int chordNote, float approachTime)
    {
        this.hitTime = hitTime;
        this.chordNote = chordNote;
        velocity = new Vector3(0, 8.5f, 0) / approachTime;
        if (chordNote == 1)
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition += velocity * Time.deltaTime;
    }
}
