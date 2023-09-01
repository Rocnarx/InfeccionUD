using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    private void Play(){
        

        StartCoroutine(StartGame());
         

    }

    private IEnumerator StartGame(){
        animator.SetTrigger("Fade");
        audioSource.Play();
         yield return new WaitForSeconds(2.0f);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

    public void Exit(){
        Debug.Log("Exit");
        Application.Quit();
    }
}
