using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    
    

    [SerializeField]
    GameObject finishPenel;


    Vector3[] enemySpawnPos = new Vector3[11];

    float timer= 0;
    
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i <11; i++)
        {
            enemySpawnPos[i] = new Vector3(-130, 90, -190 + i * 19*2);
            // Debug.Log(enemySpawnPos[i] + " 이건 몇 번째? " + i);
            Instantiate(enemy, enemySpawnPos[i], enemy.transform.rotation);
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        
        
        timer = timer + Time.deltaTime;

        //Random Range(0,11)은 0부터 10까지 나온다 
        //배열은 어차피 마지막 값을 포함하지 않기 때문에 괜찮다.
        //ex)arr[10]은 0 1 2 3 4 5 6 7 8 9 이기 떄문에 Random.Range(0,10)사용 가능 
        //                                            이 값도 0 1 2 3 4 5 6 7 8 9

        if (timer >= 1)
        {
            EnemySpawn(enemy, enemySpawnPos[Random.Range(0, 11)]);
            timer = 0;
        }


    }


    void EnemySpawn(GameObject abcd, Vector3 pos)
    {
        Instantiate(abcd, pos, abcd.transform.rotation);
    }




}
