using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumNote : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.001f, 0.001f, 0);
    public float hitTime;
    public float shrinkRate;
    

    public void initialize(float hitTime, float approachTime)
    {
        this.hitTime = hitTime;
        shrinkRate = (2 - 0.6f) / approachTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x >= 0)
            gameObject.transform.localScale -= shrinkRate * new Vector3(1, 1, 0) * Time.deltaTime;
    }
}
