using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Checkpointtext;
    public Vector3 SpawnPosition;
    //public Vector3 DefaultSpawnPos;
    public GameObject player;
    public AudioSource pickupsound;
   
    public AudioSource Checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition = player.transform.position;
        //DefaultSpawnPos = new Vector3(0.09f, 0.78f, -18.6f);
        Debug.Log(SpawnPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killbox")
        {
            player.transform.position = SpawnPosition;
            
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            Checkpointtext.SetActive(true);
            Debug.Log("Check Point Set!");
            SpawnPosition = player.transform.position;
            Debug.Log(SpawnPosition);
            Checkpoint.Play();
        }
        if (other.gameObject.tag == "Pickups")
        {
            other.gameObject.GetComponent<RespawnCollectable>().collected = true;
            pickupsound.Play();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            player.transform.position = SpawnPosition;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            Checkpointtext.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
