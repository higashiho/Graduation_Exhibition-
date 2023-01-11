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
        private PlayerMove movePlayer = new PlayerMove();
        private CreateTrump createTrump = new CreateTrump(); 
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // プレイヤー挙動関係
            switch(playerStatus)
            {
                // 移動挙動
                case PlayerState.MOVE:
                    movePlayer.Move(this, playerData);
                    break;
                // ジャンプ挙動
                case PlayerState.JUMP:
                    movePlayer.Junp(this, playerData);
                    break;
                // 通常時
                case PlayerState.DEFAULT:
                    imput();
                    break;
                // エネミーとの座標変更時
                case PlayerState.CHANGE:
                    break;
                default:
                    break;
            }

            // 移動中と座標変更時はトランプ生成できないように設定
            if(playerStatus != PlayerState.MOVE || playerStatus != PlayerState.CHANGE)
            // トランプ生成挙動
            {
                Debug.Log("stateInstanse");
                createTrump.Move(this, trump, InGameController.UI);  
            }               
        }

    }
}