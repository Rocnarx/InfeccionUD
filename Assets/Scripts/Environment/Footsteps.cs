using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioSource audioSource;
    private CharacterController controller;
    private bool isGrounded;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isGrounded)
            audioSource.enabled = true;
            else
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
