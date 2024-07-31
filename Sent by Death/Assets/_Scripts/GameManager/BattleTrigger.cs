using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemiesToSpawnIn;
    [SerializeField]
    Collider2D currentRoomSpawnableArea;


    GameObject player;
    [SerializeField] BoxCollider2D col;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            Vector2 exitDir = (collision.transform.position - col.bounds.center).normalized;

            if (exitDir.x > 0)
            {
                BattleManager.instance.SpawnEnemies(currentRoomSpawnableArea, enemiesToSpawnIn);
            }
        }

    }

}
