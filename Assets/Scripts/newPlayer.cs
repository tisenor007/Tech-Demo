using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayer : MonoBehaviour
{
    //public Vector3 DefaultSpawnPos;
    public GameObject player;
    public float jumpHeight = 5.0f;
    public float speed;
    public AudioSource death;
    public LayerMask layerMask;
    public bool isGrounded;
    private Vector3 SpawnPosition;
    private Rigidbody rb;
    private float Yposition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (other.gameObject.tag == "Death")
        {
            death.Play();
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            SpawnPosition = player.transform.position;
        }
        if (other.gameObject.tag == "Pickups")
        {
            other.gameObject.GetComponent<RespawnCollectable>().collected = true;
           
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            player.transform.position = SpawnPosition;
           
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        //move
        float Xaxis = Input.GetAxis("Horizontal") * speed;
        float Zaxis = Input.GetAxis("Vertical") * speed;

        Vector3 movePos = transform.right * Xaxis + transform.forward * Zaxis;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

        rb.velocity = newMovePos;

        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, layerMask);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpHeight, rb.velocity.z);
        }
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 4f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - 4f;
        }
        

        //gameObject.transform.Translate(Xaxis, Yposition, Zaxis);

       
        
    }
}
