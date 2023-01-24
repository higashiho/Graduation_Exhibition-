using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks; 
using System.Threading;

namespace EnemyLight
{
    public class LightMove
    {
        // 挙動
        public void Move(BaseLight tmpLight)
        {
            // アイテムの座標に回る
            tmpLight.transform.DOPath(tmpLight.ItemsPos, Const.LIGHT_MOVE_TIME).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }

        // 消えた後指定秒後に再出現
        public async UniTask ActiveReturn(BaseLight tmpLight, CancellationToken token)
        {
            await UniTask.Delay(Const.LIGHT_ACTIVE_RETUN_TIME * Const.CHANGE_SECOND);

            
            // キャンセルが要求されている場合
            if ( token.IsCancellationRequested )
            {
                Debug.Log ( "Canceled." );
                return;
            }
            
            tmpLight.gameObject.SetActive(true);
        }
    }
}