using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioSource checkPointSound;
    
    public GameObject checkPointText;

    private void OnTriggerEnter(Collider other)
    {
        checkPointText.SetActive(true);
        checkPointSound.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        checkPointText.SetActive(false);
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
