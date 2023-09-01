using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance;

    public float sensitivity = 10;
    public bool soundEnabled = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
