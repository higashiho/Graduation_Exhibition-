using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 



namespace Player
{
    public class PlayerMove
    {
        private BasePlayer tmpPlayer;

        public PlayerMove(BasePlayer tmp)
        {
            tmpPlayer = tmp;
        }
        // プレイヤー挙動
        // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
        public void Move( PlayerData playerData)
        {
            var pos = new Vector3();

            if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow))
                pos.x -= playerData.PlayerSpeed * Time.deltaTime;

            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                pos.x += playerData.PlayerSpeed * Time.deltaTime;
            // 何もキーが押されていない場合はステート初期化
            else
                tmpPlayer.PlayerStatus = BasePlayer.PlayerState.DEFAULT;

            tmpPlayer.gameObject.transform.position += pos;
        }
        
        // ジャンプ挙動
        // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
        public async void Jump( PlayerData playerData)
        {
            // フラグがたってない場合
            if(!playerData.JumpFlag)
            {
                playerData.JumpFlag = true;
                tmpPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,playerData.PlayerJumpPower,0));
                // 1秒後にフラグを折る
                await jumpCoolTime(playerData);

                // ステート初期化
                tmpPlayer.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
            }
        }
        
        // 一秒後にジャンプフラグを折る
        private async UniTask jumpCoolTime(PlayerData playerData)  
        {
            await UniTask.Delay(playerData.JunpFlagTimer * Const.CHANGE_SECOND);  
            playerData.JumpFlag = false;
            Debug.Log("Unitask完了");  
        }
    }
}