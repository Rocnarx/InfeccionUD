using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    // Start is called before the first frame update
   public void ProcessLook(Vector2 input){
    float mouseX = input.x;
    float mouseY = input.y;
    //CALCULAR CAMARA
    xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
    xRotation = Mathf.Clamp(xRotation, -80, 80f);

    cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);
    //ROTAR JUGADOR
    transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
   }
}
