using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColVision : MonoBehaviour
{
    [SerializeField]    // 親オブジェクト
    private BaseEnemy enemy;
    // 当たり判定
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Detection();
        }
    }

    // 親オブジェのエネミーのステートを攻撃に変更
    private void Detection()
    {
        enemy.EnemysStatus = BaseEnemy.EnemyState.ATTACK;
    }
}
