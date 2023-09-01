using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corote : Pickup
{
    private AudioSource audioSource;
    private bool alrUsed = false;
    

    void Start(){
        audioSource = GetComponent<AudioSource>();
        nameObject = "Corote";
    }

    private void Destruir()
    {
      PlayerUses();
      Destroy(gameObject);
    }
    
    protected override void Interact()
    {
      if (!alrUsed)
      {
        alrUsed = !alrUsed;
        audioSource.Play();
        Invoke("Destruir", audioSource.clip.length);
        
      }
    }

}