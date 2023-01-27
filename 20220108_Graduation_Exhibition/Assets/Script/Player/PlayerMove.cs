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
        public void Move()
        {
            var pos = new Vector3();

            if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= tmpPlayer.DataPlayer.PlayerSpeed * Time.deltaTime;
                tmpPlayer.PlayerMoveFlags = BasePlayer.PlayerMoveFlag.LEFT;
            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += tmpPlayer.DataPlayer.PlayerSpeed * Time.deltaTime;
                tmpPlayer.PlayerMoveFlags = BasePlayer.PlayerMoveFlag.RIGHT;
            }
            // 何もキーが押されていない場合はステート初期化
            else
                tmpPlayer.PlayerStatus = BasePlayer.PlayerState.DEFAULT;

            tmpPlayer.gameObject.transform.position += pos;
        }
        
        // ジャンプ挙動
        // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
        public async void Jump()
        {
            // フラグがたってない場合
            if(!tmpPlayer.DataPlayer.JumpFlag)
            {
                tmpPlayer.DataPlayer.JumpFlag = true;
                tmpPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, tmpPlayer.DataPlayer.PlayerJumpPower, 0));
                // 1秒後にフラグを折る
                await jumpCoolTime();

                // ステート初期化
                tmpPlayer.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
            }
        }
        
        // 一秒後にジャンプフラグを折る
        private async UniTask jumpCoolTime()  
        {
            await UniTask.Delay(tmpPlayer.DataPlayer.JunpFlagTimer * Const.CHANGE_SECOND);  
            tmpPlayer.DataPlayer.JumpFlag = false;
            Debug.Log("Unitask完了");  
        }
    }
}