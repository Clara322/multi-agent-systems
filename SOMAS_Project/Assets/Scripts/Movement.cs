using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PhotonView _pv;

    public float xMax = 50;
    public float zMax = 50;
    public float xMin = -50;
    public float zMin = -50;
         
    private float x;
    private float z;
    private float time;
    private float angle;
    private float maxSpeed = 0.2f;

     void Start ()
     {
         x = Random.Range(-maxSpeed, maxSpeed);
         z = Random.Range(-maxSpeed, maxSpeed);
         angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
         transform.localRotation = Quaternion.Euler( 0, angle, 0);
     }
     
     // Update is called once per frame
     void Update () {
 
         time += Time.deltaTime;
 
         if (transform.localPosition.x > xMax) {
             x = Random.Range(-maxSpeed, 0.0f);
             angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             transform.localRotation = Quaternion.Euler(0, angle, 0);
             time = 0.0f; 
         }
         if (transform.localPosition.x < xMin) {
             x = Random.Range(0.0f, maxSpeed);
             angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             transform.localRotation = Quaternion.Euler(0, angle, 0); 
             time = 0.0f; 
         }
         if (transform.localPosition.z > zMax) {
             z = Random.Range(-maxSpeed, 0.0f);
             angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             transform.localRotation = Quaternion.Euler(0, angle, 0); 
             time = 0.0f; 
         }
         if (transform.localPosition.z < zMin) {
             z = Random.Range(0.0f, maxSpeed);
             angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             transform.localRotation = Quaternion.Euler(0, angle, 0);
             time = 0.0f; 
         }
         
         if (time > 1.0f) {
             x = Random.Range(-maxSpeed, maxSpeed);
             z = Random.Range(-maxSpeed, maxSpeed);
             angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
             transform.localRotation = Quaternion.Euler(0, angle, 0);
             time = 0.0f;
         }
 
         transform.localPosition = Vector3.Lerp(transform.position, transform.position + new Vector3(x, 0.0f, z), Time.time);
     }
}
