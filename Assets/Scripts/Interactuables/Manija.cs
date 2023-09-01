using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manija : Interactuable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource audioSource2;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        
        if (doorOpen)
        {
            audioSource.Play();
        }
        else
        {
            audioSource2.Play();
        }

    }
}
