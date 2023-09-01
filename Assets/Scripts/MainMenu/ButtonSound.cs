using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

public AudioSource audioSourceClick;
public AudioSource audioSourcePointerEnter;



public void Click(){

    audioSourceClick.Play();
}

public void PointerEnterButton(){
    audioSourcePointerEnter.Play();
}
}
