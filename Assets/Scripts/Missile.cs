using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
   public Transform target;

   public float speed = 0.7f;

   public Vector3 dir;

   void Update()
    {
   
         dir = target.position - this.transform.position;
        dir = dir.normalized * speed *Time.deltaTime;;
       


        this.transform.position += dir;

       // Debug.LogFormat("Distance : {0}",Vector2.Distance(this.transform.position,target[targetIndex].position));


            if(Vector2.Distance(this.transform.position,target.position) < 0.5f)
            {
               Destroy(gameObject);
            }
    }
}
