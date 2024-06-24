using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public GameObject wall, wall2, bau;
    public GameObject enemy;
    
    public static BattleManager Instance;
    
    public Transform[] spawnPoints;
    public int enemiesToSpawn;
    public GameObject[] noOfEnemies;
    public bool isFinalBattle = false;

    private void Start()
    {
        Instance = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartBattle();
        }
    }

    private void Update()
    {
        noOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(noOfEnemies.Length > 0)
        {
            wall.SetActive(true);
            wall2.SetActive(true);
        }
        else if (noOfEnemies.Length == 0)
        {
            EndBattle();
        }
    }

    public void StartBattle()
    {
        Destroy(boxCollider);
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Transform randomPos = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomPos.position, Quaternion.identity);
        }
        if (noOfEnemies.Length == 0)
        {
            EndBattle();
        }
    }

    public void EndBattle()
    {
        wall.SetActive(false);
        wall2.SetActive(false);
        if(isFinalBattle)
        {
            bau.SetActive(true);
        }
    }
}
