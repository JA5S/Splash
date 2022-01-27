using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrnHtWrap : MonoBehaviour
{
    //declare variables
    public Rigidbody2D raindrop;
    public Transform spawner;

    private WaterMeter waterMeter;
    private Vector2 pos;
    private float ScrWth;
    private float ScrHt;

    void Start()
    {
        //calc screen width in units from pixels
        ScrWth = Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
        ScrHt = Camera.main.orthographicSize;

        //reference water meter slider
        waterMeter = GameObject.FindWithTag("LoseCon").GetComponent<WaterMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenHtWrap();
    }

    void ScreenHtWrap()
    {
        pos = transform.position;

        //vertical screen wrapping
        if (pos.y <= -ScrHt)
        {
            pos = new Vector2(Random.Range(-ScrWth, ScrWth), spawner.position.y);
            waterMeter.IncreaseWater();
            //reset velocity (so a of g doesn't loop increase of v)
            raindrop.velocity = new Vector2(0, 0);
            //add particle effect?
        }

        transform.position = pos;
    }
}
