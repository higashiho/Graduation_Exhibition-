using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyMove
    {
        // 挙動処理
        // 第一引数：動かすオブジェクト
        public void Move(BaseEnemy tmpEnemy)
        {
            // 座標を保存
            var tmpPos = tmpEnemy.transform.position;

            switch(tmpEnemy.EnemyMoveFlags)
            {
                case BaseEnemy.EnemyMoveFlag.LEFT:
                    tmpPos.x -= tmpEnemy.EnemysData.EnemySpeed * Time.deltaTime;
                    // 左の視界が消えていて右の視界が表示されている時表示視界変換
                    if(!tmpEnemy.LeftVision.activeSelf || tmpEnemy.RightVision.activeSelf)
                    {
                        tmpEnemy.LeftVision.SetActive(true);    tmpEnemy.RightVision.SetActive(false);
                    }
                    break;
                case BaseEnemy.EnemyMoveFlag.RIGHT:
                    tmpPos.x += tmpEnemy.EnemysData.EnemySpeed * Time.deltaTime;
                    // 右の視界が消えていて左の視界が表示されている時表示視界変換
                    if(tmpEnemy.LeftVision.activeSelf || !tmpEnemy.RightVision.activeSelf)
                    {
                        tmpEnemy.LeftVision.SetActive(false);    tmpEnemy.RightVision.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
            tmpEnemy.transform.position = tmpPos;
        }

        // ステータス初期化
        public void StatusReset(BaseEnemy tmpEnemy)
        {
            Debug.Log("OutCamera");
            tmpEnemy.EnemysStatus = BaseEnemy.EnemyState.MOVE;
        }

        // チェンジ時に重力判定がある場合消す
        public void VelocityClear(BaseEnemy tmpEnemy)
        {
            
            // 非アクティブ確認
            if(tmpEnemy.LeftVision.activeSelf || tmpEnemy.RightVision.activeSelf)
            {
                // アクティブの場合非アクティブにする
                tmpEnemy.LeftVision.SetActive(false);
                tmpEnemy.RightVision.SetActive(false);
            }
            tmpEnemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        public int distanse(BaseEnemy tmpEnemy)
        {
            float tmpPlayerToEnemyDis = InGameController.Player.transform.position.x - tmpEnemy.transform.position.x;
            int playerToEnemyDis = (int)tmpPlayerToEnemyDis;
            return playerToEnemyDis;
        }
    }
} 