
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public bool isTrigged;
    [SerializeField]
    GameObject[] enemiesToSpawnIn;
    [SerializeField]
    Collider2D currentRoomSpawnableArea;

    GameObject[] enemiesInScene;

    [SerializeField] GameObject walls;

    GameObject player;
    [SerializeField] BoxCollider2D col;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Vector2 exitDir = (collision.transform.position - col.bounds.center).normalized;

            //if (exitDir.x > 0)
            //{
                BattleManager.instance.SpawnEnemies(currentRoomSpawnableArea, enemiesToSpawnIn);
                isTrigged = true;
            //}
            //else if (exitDir.y > 0)
            //{
                //BattleManager.instance.SpawnEnemies(currentRoomSpawnableArea, enemiesToSpawnIn);
                //isTrigged = true;
            //}
        }

    }

    public void FixedUpdate()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        Battle();
    }

    public void Battle()
    {
        if (isTrigged)
        {
            if (enemiesInScene.Length > 0)
            {
                walls.SetActive(true);
                Destroy(col);
            }
            else if (enemiesInScene.Length <= 0)
            {
                walls.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}
