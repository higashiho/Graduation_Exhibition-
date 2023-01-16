using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            if(col.gameObject.tag == "Bullet")
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.gameObject.tag == "Item")
            {
                // 表示を消して取得数を増やす
                other.gameObject.SetActive(false);
                BaseUI.HaveItem++;
            }
            if(other.gameObject.tag == "WarpMecha")
            {
                // スタートワープメカではないときの処理
                if(other.gameObject.name != "StartWarpMecha")
                {
                    var tmpObj = other.GetComponent<BaseWarp>();
                    // ワープできるフラグがたっていないと
                    if(!tmpObj.OnWarp)
                    {
                        // ワープ座標に設定してフラグを立てる
                        player.WarpPos = other.transform.position;
                        tmpObj.OnWarp = true;
                    }
                }
                // スタートワープメカの場合
                else
                {
                    var tmpObj = other.GetComponent<BaseWarp>();
                    // ワープできるフラグがたっていなくてスタートワープメカを格納していない場合
                    if(!tmpObj.OnWarp && !player.StartWarpMecha)
                    {
                        // スタートワープメカを格納してフラグを立てる
                        player.StartWarpMecha = tmpObj;
                        tmpObj.OnWarp = true;
                    }
                }
            }
        }
    }
}