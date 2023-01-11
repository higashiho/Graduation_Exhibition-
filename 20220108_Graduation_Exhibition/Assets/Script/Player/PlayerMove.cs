using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 



namespace Player
{
    public class PlayerMove
    {
        
        public static PlayerMove MovePlayer{get;private set;} = new PlayerMove();
        // プレイヤー挙動
        // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
        public void Move(BasePlayer obj, PlayerData playerData)
        {
            var pos = new Vector3();

            if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow))
                pos.x -= playerData.PlayerSpeed * Time.deltaTime;

            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                pos.x += playerData.PlayerSpeed * Time.deltaTime;
            // 何もキーが押されていない場合はステート初期化
            else
                obj.PlayerStatus = BasePlayer.PlayerState.DEFAULT;

            obj.gameObject.transform.position += pos;
        }
        
        // ジャンプ挙動
        // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
        public async void Jump(BasePlayer obj, PlayerData playerData)
        {
            // フラグがたってない場合
            if(!playerData.JumpFlag)
            {
                playerData.JumpFlag = true;
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,playerData.PlayerJumpPower,0));
                // 1秒後にフラグを折る
                await jumpCoolTime(playerData);

                // ステート初期化
                obj.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
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