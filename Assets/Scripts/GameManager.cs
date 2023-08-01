using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int[,] enemyData = 
    {
        {0,0,2,0,3,0,4,0},
        {0,0,0,0,1,1,1,1},
        {1,1,1,1,1,1,1,1}
    };
    //생성할 프리팹
    public GameObject[] enemy01;
    public GameObject[] towers;

    //생성될 위치
    public Transform startPos;

    public Transform[] target;

    public GameObject buttons;
    public Transform ground;


    public float time =0;
    public float timeMax = 2f;

    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(count <8)
        {
            time -= Time.deltaTime;
            if(time <0)
            {
                GameObject temp = Instantiate(enemy01[enemyData[1,count]]);
                temp.transform.position = startPos.position;
                temp.GetComponent<Enemy>().target = target;

                time = timeMax;
                count++;
            }
        }
        /*
        
       if(Input.GetKeyDown(KeyCode.Space))
       {
        GameObject temp = Instantiate(enemy01);
        temp.transform.position = startPos.position;
        temp.GetComponent<Enemy>().target = target;
       }
       */
    }

    public void OnClickGround(Transform tr)
    {
        ground = tr;
        buttons.SetActive(true);

    }

    public void CreateTower(int index)
    {
        if(ground.childCount == 0)
        {
              GameObject temp = Instantiate(towers[index]);
        temp.transform.parent = ground;
        temp.transform.localPosition = Vector3.zero;

        }
     

        buttons.SetActive(false);
        

    }
}
