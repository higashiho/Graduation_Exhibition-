using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class EnemyData : ScriptableObject
{
    // 挙動スピード
    [SerializeField, Header("移動スピード")]
    private float enemySpeed;
    public float EnemySpeed{get{return enemySpeed;}private set{enemySpeed = value;}}
    
}
