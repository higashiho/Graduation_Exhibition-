using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneMove;
using UI;
using Warp;


namespace Player
{
    public class ColPlayer : MonoBehaviour
    {
        // UIcontroller
        [SerializeField, Header("UI")]
        private BasePlayer player;
        // 当たり判定
        private void OnCollisionEnter2D(Collision2D col) 
        {
            if(col.gameObject.tag == "Bullet" && player.PlayerStatus != BasePlayer.PlayerState.WARP && player.PlayerStatus != BasePlayer.PlayerState.RETRY)
            {
                player.PlayerStatus = BasePlayer.PlayerState.RETRY;
                BaseSceneMove.SceneInstance.SceneState |= Const.SCENE_MAIN_GAME_OVER;
            }
            if(col.gameObject.tag == "Item")
            {
                // 表示を消して取得数を増やす
                col.gameObject.SetActive(false);
                BaseUI.HaveItem++;
            }
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {

            if(other.gameObject.tag == "WarpMecha")
            {
                var tmpObj = other.GetComponent<BaseWarp>();
                // スタートワープメカではないときの処理
                if(other.gameObject.name != "StartWarpMecha")
                {
                    // ワープできるフラグがたっていないと
                    if(!tmpObj.OnWarp)
                    {
                        // ワープ座標に設定してフラグを立てる
                        player.WarpPos = other.transform.position;
                        tmpObj.OnWarp = true;
                        tmpObj.OnPlayer = true;
                    }
                }
                // スタートワープメカの場合
                else
                {
                    // ワープできるフラグがたっていなくてスタートワープメカを格納していない場合
                    if(!tmpObj.OnWarp && !player.StartWarpMecha)
                    {
                        // スタートワープメカを格納してフラグを立てる
                        player.StartWarpMecha = tmpObj;
                        tmpObj.OnWarp = true;
                    
                    }
                }
                tmpObj.OnPlayer = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other) 
        {
            if(other.gameObject.tag == "WarpMecha")
            {
                    other.GetComponent<BaseWarp>().OnPlayer = false;
            }
        }
    }
}