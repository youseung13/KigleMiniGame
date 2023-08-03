using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
   public Transform target;
   public Transform oritarget;
   public CapsuleCollider2D cr;

   public float speed = 0.7f;
   public int damage;

   public Vector3 dir;

   private void Awake() {
      cr= GetComponent<CapsuleCollider2D>();
      oritarget = target;
   }

   void Update()
    {
      if(target == null || oritarget !=target)
      {
         Destroy(gameObject,2f);
      }

      
      if(target !=null)
      {
         dir = target.position - this.transform.position;
        dir = dir.normalized * speed *Time.deltaTime;;
         this.transform.position += dir;
      }

       




       // Debug.LogFormat("Distance : {0}",Vector2.Distance(this.transform.position,target[targetIndex].position));

    }

    private void Attack(int _damage)
    {

    }


    private void OnTriggerEnter2D(Collider2D hit) 
    {
      if(hit.GetComponent<Enemy>() != null)
      {
         if(hit.gameObject.transform == target)
         {
            hit.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
         }
      }
    }
}
