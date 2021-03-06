﻿using UnityEngine;
using System.Collections;

 public class LookTowardMouse : MonoBehaviour {
 
     // Update is called once per frame
     void Update () 
     {
         
         //Get the Screen positions of the object
         Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
         
         //Get the Screen position of the mouse
         Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
         //Get the angle between the points
         float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
 
         //Ta Daaa
         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler (new Vector3(0f,0f,angle-90)), Time.time * 0.01f);
     }
 
     float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
 
 }