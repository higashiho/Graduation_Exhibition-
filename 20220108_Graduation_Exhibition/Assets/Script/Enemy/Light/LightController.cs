using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace EnemyLight
{
    public class LightController : BaseLight
    {
        // Start is called before the first frame update
        void Start()
        {
            // 初期化
            Items = GameObject.FindGameObjectsWithTag("Item");
            
            // アイテムの配列をvector3配列に変換
            for(int i = 0; i< Items.Length; i++)
                ItemsPos[i] = Items[i].transform.position;
                
            
            lightMove.Move(this);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        // 消えた後の処理
        private async void OnDisable() 
        {
            await lightMove.ActiveReturn(this, cts.Token);
        }

        private void OnDestroy()
        {
            
             // ライトの再出現をキャンセル
            cts.Cancel();
        }
    }
}