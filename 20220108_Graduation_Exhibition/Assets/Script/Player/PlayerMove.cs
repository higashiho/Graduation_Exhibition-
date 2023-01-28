using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Audio;


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
                if(!BaseAudio.PlayerAoudio.isPlaying)
                    BaseAudio.PlayerAoudio.PlayOneShot(InGameSceneController.AudioInstance.MovePlayer);
                pos.x -= tmpPlayer.DataPlayer.PlayerSpeed * Time.deltaTime;
                tmpPlayer.PlayerRenderer.sprite = tmpPlayer.LeftPlayerSprite;
            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(!BaseAudio.PlayerAoudio.isPlaying)
                    BaseAudio.PlayerAoudio.PlayOneShot(InGameSceneController.AudioInstance.MovePlayer);
                pos.x += tmpPlayer.DataPlayer.PlayerSpeed * Time.deltaTime;
                tmpPlayer.PlayerRenderer.sprite = tmpPlayer.RightPlayerSprite;
            }
            // 何もキーが押されていない場合はステート初期化
            else
            {
                tmpPlayer.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
                //InGameSceneController.AudioInstance.PlayerAoudio.Stop();
            }
            tmpPlayer.gameObject.transform.position += pos;
        }
        
        // ジャンプ挙動
        // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
        public void Jump()
        {
            // 地面と接地している場合
            if(tmpPlayer.OnGrount)
            {
                tmpPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, tmpPlayer.DataPlayer.PlayerJumpPower, 0));
                
                // ステート初期化
                tmpPlayer.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
            }
        }
    }
}