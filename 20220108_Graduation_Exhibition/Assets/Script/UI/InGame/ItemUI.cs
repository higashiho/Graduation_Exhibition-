using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI
{
    public static ItemUI Items{get;private set;} = new ItemUI();
    // アイテムの最大値と取得個数を表示
    public void ItemCount(BaseUI tmpUI)
    {
        tmpUI.ItemsUI.text = BaseUI.HaveItem + "/" + tmpUI.Items.Length;
    }

    // アイテムの出現個数を確認
    public void FindItems(BaseUI tmpUI)
    {
        // 現在の要素数
        var i = 0;
        // 確認して配列に格納
        foreach(var tmpObj in GameObject.FindGameObjectsWithTag("Item"))
        {
            tmpUI.Items[i++] = tmpObj;
        }
    }
}
