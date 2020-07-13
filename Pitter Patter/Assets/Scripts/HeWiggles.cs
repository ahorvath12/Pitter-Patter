using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeWiggles : MonoBehaviour
{
    Vector3 startPosition;
    public Vector3 target;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    private bool direction;
    // Total distance between the markers.
    private float journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        direction=true;
        startPosition=this.transform.position;
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startPosition, target);

    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = ((Time.time - startTime) * speed)%speed;
        if(this.transform.position==target){
            direction=false;
        }
        else if(this.transform.position==startPosition){
            direction=true;
        }
        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, target, (Mathf.Cos(speed*Time.time)+1)/2);
/*
        if(direction)
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPosition, target, fractionOfJourney);
        else
            transform.position = Vector3.Lerp(target, startPosition, fractionOfJourney);
            */
    }
}
