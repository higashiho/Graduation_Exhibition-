using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using DG.Tweening;
using Enemy;
using Player;


namespace Trump
{
    public class ColTrump : MonoBehaviour
    {
        [SerializeField]
        private BaseTrump trump;

        // プレイヤーとエネミー入れ替え関数
        private async void changePos(Collision2D col )
        {
            var tmpEnemy = col.gameObject.GetComponent<BaseEnemy>();
            // プレイヤーの座標とエネミーの座標を変更
            // プレイヤーの座標を一旦別変数に格納
            var tmpPlayerPos = InGameSceneController.Player.transform.position;
            var tmpEnemyPos = tmpEnemy.transform.position;
            
            // 当たり判定
            var tmpPlayerCol = InGameSceneController.Player.PlayerRenderer.GetComponent<BoxCollider2D>();
            // 親の当たり判定と子の当たり判定を取得
            var tmpEnemysCol = tmpEnemy.GetComponent<BoxCollider2D>();                      // 親の当たり判定
            var tmpEnemyCol = tmpEnemy.transform.GetChild(0).GetComponent<BoxCollider2D>(); // 子の当たり判定

            // 重力処理を取得
            var tmpPlayerRb = InGameSceneController.Player.GetComponent<Rigidbody2D>();
            var tmpEnemyRb = tmpEnemy.GetComponent<Rigidbody2D>();

            
            // 座標を更新している最中は当たり判定と重力を削除
            tmpPlayerCol.enabled = false;
            tmpPlayerRb.gravityScale = 0;
            tmpEnemysCol.enabled = false;
            tmpEnemyCol.enabled = false;
            tmpEnemyRb.gravityScale = 0;

            // 処理中はステートを更新
            changeState(BasePlayer.PlayerState.CHANGE,BaseEnemy.EnemyState.CHANGE, tmpEnemy);


            // 座標を更新 指定秒後に処理終了
            await changeMove(tmpEnemy,tmpEnemyPos,tmpPlayerPos);

            // 処理が終わったらステートを初期化
            changeState(BasePlayer.PlayerState.DEFAULT,BaseEnemy.EnemyState.MOVE, tmpEnemy);
            
            // 処理が終わるころに当たり判定と重力を直す
            tmpPlayerCol.enabled = true;
            tmpPlayerRb.gravityScale = Const.START_GRAVITY_SCALE;
            tmpEnemysCol.enabled = true;
            tmpEnemyCol.enabled = true;
            tmpEnemyRb.gravityScale = Const.START_GRAVITY_SCALE;
        }

        // 移動処理
        private async UniTask changeMove(BaseEnemy tmpEnemy,Vector3 tmpEnemyPos, Vector3 tmpPlayerPos)
        {
            
            // (ChangeTimer)秒間かけて指定座標に移動
            // エネミーの位置変更
            tmpEnemy.transform.DOMove(tmpPlayerPos, InGameSceneController.Player.DataPlayer.ChangeTimer).SetEase(Ease.Flash).OnComplete(() =>
            {
                Debug.Log("OnComplete!");
            });
            // プレイヤーの位置変更
            var playerTween = InGameSceneController.Player.transform.DOMove(tmpEnemyPos, InGameSceneController.Player.DataPlayer.ChangeTimer).SetEase(Ease.Flash).OnComplete(() =>
            {
                Debug.Log("OnComplete!");
            });

            // PlayerのTweenが終わるまで待つ
            await playerTween.AsyncWaitForCompletion();
            // posがTMPENEMYの＋１～ー１の範囲内に行くまで止まる
            // await UniTask.WaitWhile(() => InGameController.Player.transform.position.x >= tmpEnemyPos.x + Const.TMPENEMY_POS_ADJUST || 
            //                                InGameController.Player.transform.position.x <= tmpEnemyPos.x - Const.TMPENEMY_POS_ADJUST);
        }

        // ステート更新
        protected void changeState(BasePlayer.PlayerState tmpPlayerState , BaseEnemy.EnemyState tmpEnemyState, BaseEnemy tmpEnemy)
        {
            InGameSceneController.Player.PlayerStatus = tmpPlayerState;
            tmpEnemy.EnemysStatus = tmpEnemyState;
        }

        // 当たり判定
        private void OnCollisionEnter2D(Collision2D col) 
        {
            if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Bullet")
            {
                // 非同期をキャンセルしてプールに格納
                trump.cts.Cancel();
                
                trump.objectPoolCallBack?.Invoke(trump);
            }

            if(col.gameObject.tag == "Enemy")
            {
                // 位置変更
                changePos(col);

                
            // 位置変更音
            InGameSceneController.AudioInstance.audioSource.PlayOneShot(InGameSceneController.AudioInstance.Change);

            // 非同期をキャンセルしてプールに格納
            trump.cts.Cancel();
            trump.objectPoolCallBack?.Invoke(trump);
            }
        }
    }
}
