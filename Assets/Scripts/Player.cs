using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject Checkpointtext;
    public Vector3 SpawnPosition;
    //public Vector3 DefaultSpawnPos;
    public GameObject player;
    public AudioSource pickupsound;
    public Transform playerbody;
    public float mousesensitivity = 100f;
    public float xRotation = 0f;
    public float YRotation = 0f;
    public float Jumpheight;
    private float Yposition;

    public AudioSource Checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        //move
        float Xaxis = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Yaxis = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //rotate body, gives camera child rotate effect
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        xRotation -= mouseY;
        YRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (Input.GetButtonDown("Jump"))
        {
            Yposition = Jumpheight;
        }
        if (Input.GetButtonUp("Jump"))
        {
            Yposition = 0f;
        }

        gameObject.transform.Translate(Xaxis, Yposition, Yaxis);
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
        playerbody.Rotate(Vector3.up * mouseX);
    }
}
