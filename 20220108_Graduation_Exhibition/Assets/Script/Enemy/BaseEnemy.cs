using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    // エネミーの状態
    public enum EnemyState
    {
        MOVE,
        ATTACK,
        CHANGE
    }
    [Header("エネミーのステータス")]
    [SerializeField]
    protected EnemyState enemyStatus;
    public EnemyState EnemysStatus{get{return enemyStatus;}set {enemyStatus = value;}}

    // どっちに移動するかフラグ
    public enum EnemyMoveFlag
    {
        DEFAULT,
        LEFT,
        RIGHT
    } 
    [Header("移動フラグ")]
    [SerializeField]
    protected EnemyMoveFlag enemyMoveFlag = EnemyMoveFlag.DEFAULT;
    public EnemyMoveFlag EnemyMoveFlags{get {return enemyMoveFlag;}set {enemyMoveFlag = value;}}

    [Header("エネミーのデータ")]
    [SerializeField]
    protected EnemyData enemyData;
    public EnemyData EnemysData{get{return enemyData;}private set{enemyData = value;}}

    [Header("視界オブジェクト")]
    [SerializeField]
    protected GameObject leftVision;
    public GameObject LeftVision{get{return leftVision;}private set{leftVision = value;}}
    [SerializeField]
    protected GameObject rightVision;
    public GameObject RightVision{get{return rightVision;}private set{rightVision = value;}}

    [Header("攻撃弾")]
    [SerializeField]
    protected BaseBullet bullet; 

}
