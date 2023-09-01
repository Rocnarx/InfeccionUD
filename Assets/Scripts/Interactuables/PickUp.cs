using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    //ESTE MENSAJE SERA LO QUE VEA EL PLAYER
    public string promptMessage;
    private Inventory inventory;
    public GameObject itemButton;
    protected string nameObject;

    private void Start()
    {
        
        
    }

    private void Update()
    {
    }

    
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact(){

    }

    protected void PlayerUses()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        

        for (int i=0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                inventory.itemName[i] = nameObject;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                break;
            }


        }
    }
}
