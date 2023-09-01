using UnityEngine;
using UnityEngine.UI;

public class HealthItem : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Inventory inventory;
    private AudioSource audioSource;
    private bool alrUsed = false;

    private void Start()
    {
        Button buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(UseButtonClick);
        audioSource = GetComponent<AudioSource>();
    }

    public void UseButtonClick()
    {
        if (!alrUsed)
      {
        alrUsed = !alrUsed;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.RestoreHealth(25);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        audioSource.Play();
        Invoke("destroyItemGUI", audioSource.clip.length);
      }
    }

    public void destroyItemGUI()
    {
    Destroy(gameObject);
    }
}