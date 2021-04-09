using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //what points platform is going to be moving between, not score
    public Vector3[] points;
    public int pointNumber = 0;
    public bool automatic;
    public AudioSource mechcanicalSound;

    public float tolerance;
    public float speed;
    public float lingerTime;

    private float lingerStart;
    private Vector3 current_target;
    
    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != current_target)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
        
    }
    void MovePlatform()
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            mechcanicalSound.Stop();
            transform.position = current_target;
            lingerStart = Time.time;
        }
    }
    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - lingerStart > lingerTime)
            {
                NextPlatform();
            }
        }
    }
    void NextPlatform()
    {
        mechcanicalSound.Play();
        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        current_target = points[pointNumber];
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
