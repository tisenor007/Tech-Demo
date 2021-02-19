using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollectable : MonoBehaviour
{
    public bool collected = false;
    public bool respawning = false;
    float timecollected = 0.0f;
    float respawntime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        if (collected == true)
        {
            if (!respawning)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                timecollected = Time.time;
            }
            respawning = true;
        }
        if (respawning)
        {
            float TimeElapsed = Time.time - timecollected;
            if (respawntime <= TimeElapsed)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
                collected = false;
                respawning = false;
            }
        }
    }
}
