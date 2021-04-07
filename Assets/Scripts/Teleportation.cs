using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject DestinationPortal;
    
    private Vector3 destination;
    public int direction;
    public AudioSource portalsound;
    // Start is called before the first frame update
    void Start()
    {
        if (direction == 1)
        {
            destination = DestinationPortal.transform.position + new Vector3(0,0,2);
        }
        else if (direction == 2)
        {
            destination = DestinationPortal.transform.position + new Vector3(0, 0, -2);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        
            other.gameObject.transform.position = destination;
            portalsound.Play();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
