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
        // Start is called before the first frame update
        void Start()
        {
            movePlayer = new PlayerMove(InGameSceneController.Player);
            PlayerRenderer = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
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
                // 以下のステートの時は入力を受け付けない
                case PlayerState.CHANGE:
                case PlayerState.WARP:
                case PlayerState.RETRY:
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