using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using System.Threading;
using SceneMove;
using Audio;


namespace Trump
{
    public class TrumpMove
    {

        public void Move(BaseTrump tmpTrump)
        {
            // 弾に速度を与える
            tmpTrump.GetComponent<Rigidbody2D>().velocity = tmpTrump.ShotForward * tmpTrump.TrumpsData.TrumpSpeed;

            //トランプ飛んでいく音
            BaseAudio.audioSource.PlayOneShot(InGameSceneController.AudioInstance.MoveTramp);

        }

        // 指定秒後にキャンセルが要求されていなければプールに格納
        public async UniTask Callback(BaseTrump tmpObj, TrumpData trumpData, CancellationToken token)
        {
            await UniTask.Delay(trumpData.DeleteTime * Const.CHANGE_SECOND);

            // キャンセルが要求されている場合
            if ( token.IsCancellationRequested )
            {
                Debug.Log ( "Canceled." );
                return;
            }
            
            // されていない場合
            Debug.Log("pool格納");
            // オブジェクトプールに回収
            tmpObj.objectPoolCallBack?.Invoke(tmpObj);
        }

        // クリア条件判断用
        public void GameClear(BaseTrump tmpTrump)
        {
            if(tmpTrump.transform.position.y >= Const.GAME_CLEAR_POS_Y)
            {
                BaseSceneMove.SceneInstance.SceneState |= Const.SCENE_MAIN_GAME_CLEAR;
            }
        }
    }
}