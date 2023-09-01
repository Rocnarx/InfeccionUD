using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip[] musicTracks; // Asigna los clips de audio en el Inspector

    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private bool activateBackMusic = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        while (activateBackMusic)
        {
            audioSource.clip = musicTracks[currentTrackIndex];
            Debug.Log(audioSource.clip.length);
            Debug.Log(currentTrackIndex);
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

            currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        }
    }

    private void stopMusic(){
        audioSource.Stop();
        activateBackMusic = false;
    }
}
