using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lap;

    public Transform[] target;

    private Vector3 dir;

    private int targetIndex;

    private Animator ani;

    public float speed ;
    public int hp;
    public int maxhp;
    public int givecoin;
    public bool isDead = false;

    public SpriteRenderer sprite;
     public CapsuleCollider2D cr;
    // Start is called before the first frame update
    private void Awake() {
              cr= GetComponent<CapsuleCollider2D>();
              ani = GetComponent<Animator>();
              sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        targetIndex = 1;
        maxhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPause)
            return;
        if (isDead)
            return;

        Move();

        if(lap==3 && targetIndex==2)
        Gohome();

    }

    private void Gohome()
    {
          
    this.transform.position = Vector2.MoveTowards(this.transform.position, GameManager.instance.startPos.position, Time.deltaTime * speed * 5);
     if (Vector2.Distance(this.transform.position, GameManager.instance.startPos.position) < 0.05f)
    {
         
         GameManager.instance.life--;
         GameManager.instance.count--;
         Destroy(gameObject);
    }

    }

    private void Move()
    {
        if (targetIndex < 6)
        {
            dir = target[targetIndex].position - this.transform.position;
            dir = dir.normalized * 0.03f;
            if (dir.x > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            // speed = dir.magnitude;

            //  this.transform.position += dir;
            this.transform.position = Vector2.MoveTowards(this.transform.position, target[targetIndex].position, Time.deltaTime * speed);

            // Debug.LogFormat("Distance : {0}",Vector2.Distance(this.transform.position,target[targetIndex].position));


            if (Vector2.Distance(this.transform.position, target[targetIndex].position) < 0.02f)
            {
                targetIndex += 1;
                if (targetIndex == 6)
                {
                    lap ++;  
                    targetIndex = 1;
                }
            }
        }
        ani.SetFloat("Speed", speed);
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
        GameManager.instance.GetCoin(givecoin);
        Destroy(gameObject);
        GameManager.instance.aliveenemy.Remove(this.gameObject);
    }
}
