using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;
using Cysharp.Threading.Tasks; 

namespace UI
{
    public class BaseDiamond : MonoBehaviour
    {
        // 回収イベント
        public static UnityAction objectPoolCallBack;
        // 回収時間
        protected int deleteTime = 3;
        
        // タスク用
        public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  
        
        protected async void OnEnable()
        {
            // 指定秒後に回収
            await Callback(cts.Token);
        }

        public async UniTask Callback( CancellationToken token)
        {
            await UniTask.Delay(deleteTime * Const.CHANGE_SECOND);

            // キャンセルが要求されている場合
            if ( token.IsCancellationRequested )
            {
                Debug.Log ( "Canceled." );
                return;
            }
            
            // されていない場合
            Debug.Log("pool格納");
            // オブジェクトプールに回収
            this.gameObject.SetActive(false);
        }
    }   
}

