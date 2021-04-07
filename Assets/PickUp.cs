using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioSource pickUpSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUpSound.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
