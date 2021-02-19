using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrig : MonoBehaviour
{
    public bool dooropen;
    public GameObject Door;
    public float closedPos;
    public float openPos;
    public Vector3 position;
    public int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        closedPos = Door.transform.position.y;
        openPos = closedPos - Door.transform.localScale.y;
        
    }
    public void OnTriggerEnter(Collider other)
    {
        dooropen = true;
    }
    public void OnTriggerExit(Collider other)
    {
        dooropen = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (dooropen == true)
        {
            if (Door.transform.position.y >= openPos)
            {
                Door.transform.position += new Vector3(0f, -(speed * Time.deltaTime), 0f);
            }
        }
        if (dooropen == false)
        {
            if (Door.transform.position.y <= closedPos)
            {
                Door.transform.position += new Vector3(0f, (speed * Time.deltaTime), 0f);
            }
        }
    }
}
