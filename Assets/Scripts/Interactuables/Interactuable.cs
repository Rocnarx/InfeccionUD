using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactuable : MonoBehaviour
{
    //ESTE MENSAJE SERA LO QUE VEA EL PLAYER
    public string promptMessage;

    
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact(){

    }
}
