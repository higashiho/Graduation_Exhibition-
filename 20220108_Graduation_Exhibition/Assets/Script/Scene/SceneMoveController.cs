using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneMove
{
    /// <summary>
    /// シーン挙動管理クラス
    /// </summary>
    public class SceneMoveController : BaseSceneMove
    {
        // Start is called before the first frame update
        void Start()
        {
            
            // インスタンス化されたBaseSceneが自身でない場合削除
            if(SceneInstance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            // 初めての生成の場合の初期化処理
            startSet();
        }

        // Update is called once per frame
        void Update()
        {
            TmpSceneMove.Move();
        }


    }
}
