using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
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

    public Transform enemys;


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
                temp.transform.parent = enemys;

                time = timeMax;
                count++;
            }
        }

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
                temp.GetComponent<Tower>().gm = this;

        }
     

        buttons.SetActive(false);
        

    }
}
*/

public class GameManager : MonoBehaviour
{
    public int level;
     public int Maxlevel;
    public int[] levelData;

    public GameObject[] enemies;

    public int[] maxEnemy;

    //생성할 프리팹
    public GameObject[] enemyprefab;
    public GameObject[] towers;

    //생성될 위치
    public Transform startPos;

    public Transform[] target;

    public GameObject buttons;
    public Transform ground;

    public Transform enemys;


    public float time ;
    public float timeBetweenSpawn = 2f;

    public int count;
    // Start is called before the first frame update

    private void Awake() 
    {
       
        
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= timeBetweenSpawn && count != maxEnemy[level])
        {
            DoSpawn();
            time = 0;
        }    
    }
    
    public void DoSpawn()
    {
        
        if(count < maxEnemy[level])
        {

                GameObject temp = Instantiate(enemyprefab[Random.Range(0,5)]);
                temp.transform.position = startPos.position;
                temp.GetComponent<Enemy>().target = target;
                temp.transform.parent = enemys;

                count++;

        }
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
                temp.GetComponent<Tower>().gm = this;

        }
     

        buttons.SetActive(false);
        

    }
}