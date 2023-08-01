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

    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        targetIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
}
