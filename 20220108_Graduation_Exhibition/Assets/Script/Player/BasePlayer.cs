using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Warp;
using UnityEngine.Rendering.Universal;


namespace Player
{
    public class BasePlayer : MonoBehaviour
    {
        [Header("playerのデータ")]
        [SerializeField]    
        protected PlayerData playerData;
        public PlayerData DataPlayer{get {return playerData;}private set{playerData = value;}}
        public enum PlayerState
        {
            DEFAULT,
            MOVE,
            JUMP,
            CHANGE,
            WARP,
            RETRY
        }
        [SerializeField]
        protected PlayerState playerStatus = PlayerState.DEFAULT;
        public PlayerState PlayerStatus{get{return playerStatus;}set {playerStatus = value;}}
        
        [SerializeField, Header("自身のライト")]
        protected Light2D myLight;
        public Light2D MyLight{get{return myLight;}protected set{myLight = value;}}
        

        [SerializeField, Header("ワープ時のマスク")]
        protected SpriteMask playerMask;
        public SpriteMask PlauerMask{get{return playerMask;}private set{playerMask = value;}}

        [SerializeField, Header("ワープする座標")]
        private Vector3 warpPos;
        public Vector3 WarpPos{get{return warpPos;}set{warpPos = value;}}

        [SerializeField, Header("スタートワープ装置")]
        protected BaseWarp startWarpMecha;
        public BaseWarp StartWarpMecha{get{return startWarpMecha;}set{startWarpMecha = value;}}
        
        // トランプを打てるかフラグ
        [SerializeField]
        protected bool shotFlag = true;
        public bool ShotFlag{get{return shotFlag;}set{shotFlag = value;}}

        // ワープ回数カウント
        [SerializeField]
        protected int warpCount = 0;
        public int WarpCount{get{return warpCount;}set{warpCount = value;}}

        // 入力関係
        protected void imput()
        {
            // 移動ボタンを押されたらステート更新
            if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                playerStatus = PlayerState.MOVE;

            // ジャンプボタンを押されたらステート更新
            if(Input.GetKeyDown(KeyCode.Space))
                playerStatus = PlayerState.JUMP;
            
        }
    }
}