using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  public float delayTimer;

  public float delayMax;

  public float range ;

  public int cost;

  public Animator ani;

  public GameManager gm;

  public Transform target;

  public float minDistance = 9999;

  public GameObject bullet;

  private void Update()
  {
    
    delayTimer -= Time.deltaTime;

    if(delayTimer<0 && target != null)
    {
     // Debug.Log("공격!");
      delayTimer = delayMax;
      ani.SetTrigger("attack");

      GameObject temp = Instantiate(bullet);
      temp.transform.position = transform.position;
      temp.GetComponent<Missile>().target = target;
    }

    if(target== null)
    {
      minDistance = 99999;
      for (int i = 0; i < gm.enemys.childCount; i++)
      {
        if(Vector3.Distance(gm.enemys.GetChild(i).position,transform.position) < minDistance)
        {
          minDistance = Vector3.Distance(gm.enemys.GetChild(i).position,transform.position);
          target = gm.enemys.GetChild(i);
        }
      }
    }
    else
    {
        if(Vector3.Distance(target.position,transform.position) > minDistance)
      {
        target = null;
      }

    }
    


  }
}
