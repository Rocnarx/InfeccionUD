using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public string[] itemName;
    [SerializeField]
    private GameObject InventoryUI;
    public Sprite coroteSprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject InventoryUI = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activateGUI();
        }

        
    }

    public void activateGUI()
    {
        if (InventoryUI.activeSelf)
        {
        InventoryUI.SetActive(false);

        }
        else
        {
            InventoryUI.SetActive(true);

        }
        
    }
}