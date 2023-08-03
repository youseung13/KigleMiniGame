using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] target;

    public Vector3 dir;

    public int targetIndex;

    public Animator ani;

    public float speed =0;
    public int hp;
    public int maxhp;
    public bool isDead = false;

    public SpriteRenderer sprite;
     public CapsuleCollider2D cr;
    // Start is called before the first frame update
    private void Awake() {
              cr= GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {
        targetIndex = 1;
        maxhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPause)
        return;
        if(isDead)
        return;


        speed = 0;


        if(targetIndex <6)
        {
            dir = target[targetIndex].position - this.transform.position;
            dir = dir.normalized * 0.03f;
            if(dir.x > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            speed = dir.magnitude;

        this.transform.position += dir;

       // Debug.LogFormat("Distance : {0}",Vector2.Distance(this.transform.position,target[targetIndex].position));


            if(Vector2.Distance(this.transform.position,target[targetIndex].position) < 0.02f)
            {
                targetIndex += 1;
                if(targetIndex == 6 )
                {
                    targetIndex = 1;
                }
            }
        }
        ani.SetFloat("Speed",speed);
        
    }



    public void TakeDamage(int _damage)
   {
        hp -= _damage;

   // GetComponent<Entity>().DamageImpact();
    //fx.StartCoroutine("FlashFX");

     if(hp <0  && !isDead)
     {
        isDead =true;
        ani.SetTrigger("Dead");
     }
   }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.instance.aliveenemy.Remove(this.gameObject);
    }
}
