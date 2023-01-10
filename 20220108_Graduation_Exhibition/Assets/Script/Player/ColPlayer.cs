using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColPlayer : MonoBehaviour
{
    // UIcontroller
    [SerializeField, Header("UI")]
    private BaseUI uiObj;
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
    }
}
