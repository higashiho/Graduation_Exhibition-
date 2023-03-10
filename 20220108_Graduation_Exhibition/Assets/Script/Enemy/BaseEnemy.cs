using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Bullet;
using UnityEngine.Rendering.Universal;


namespace Enemy
{
    public class BaseEnemy : MonoBehaviour
    {
        // 初期座標
        protected Vector3 startPos;
        public Vector3 StartPos{get{return startPos;}set{startPos = value;}}
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
        
        [SerializeField, Header("自身のライト")]
        protected Light2D myLight;
        public Light2D MyLight{get{return myLight;}protected set{myLight = value;}}

        [Header("攻撃弾")]
        [SerializeField]
        protected BaseBullet bullet; 

        [SerializeField]
        protected SpriteRenderer targetRenderer;    // 判定したいオブジェクトのrendererへの参照

        //右向き左向き
        [SerializeField, Header("右向き")]
        protected Sprite rightEnemy;
        public Sprite RightEnemy{get{return rightEnemy;}}
        [SerializeField, Header("左向き")]
        protected Sprite leftEnemy;
        public Sprite LeftEnemy{get{return leftEnemy;}}
        

        //スクリプト参照
        public EnemyMove MoveEnemy{get; private set;} = new EnemyMove();

    }
}