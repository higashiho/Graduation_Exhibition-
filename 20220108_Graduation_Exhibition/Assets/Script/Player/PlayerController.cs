using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trump;

namespace Player
{
    public class PlayerController : BasePlayer
    {

        [SerializeField]    // 生成するトランプ
        private BaseTrump trump;

        // インスタンス化
        private PlayerMove movePlayer;
        private CreateTrump createTrump = new CreateTrump(); 
        // Start is called before the first frame update
        void Start()
        {
            movePlayer = new PlayerMove(InGameSceneController.Player);
        }

        // Update is called once per frame
        void Update()
        {
            playerUpdate();
        }

        // 更新関数
        private void playerUpdate()
        {

            // プレイヤー挙動関係
            switch(playerStatus)
            {
                // 移動挙動
                case PlayerState.MOVE:
                    movePlayer.Move();
                    break;
                // ジャンプ挙動
                case PlayerState.JUMP:
                    movePlayer.Jump();
                    break;
                // 通常時
                case PlayerState.DEFAULT:
                    imput();
                    break;
                // エネミーとの座標変更時
                case PlayerState.CHANGE:
                case PlayerState.WARP:
                    break;
                default:
                    break;
            }

            // 移動中と座標変更時はトランプ生成できないように設定
            if(playerStatus == PlayerState.MOVE || playerStatus == PlayerState.CHANGE)
                return;

            // トランプ生成
            createTrump.Move(this, trump, InGameSceneController.UI);         
        }
    }
}