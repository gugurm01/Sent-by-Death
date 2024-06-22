using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public GameObject Battle;
    public BoxCollider2D col;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Battle.SetActive(true);
            Destroy(col);
            BattleManager.Instance.StartBattle();
            Destroy(this.gameObject);
        }
    }

}
