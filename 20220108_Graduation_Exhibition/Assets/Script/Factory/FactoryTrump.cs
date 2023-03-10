using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trump;


namespace Factory
{
    public class FactoryTrump : MonoBehaviour
    {
        [SerializeField]    // 弾格納リスト
        private List<BaseTrump> bulletList = new List<BaseTrump>(15);
        public List<BaseTrump> BulletList{get{return bulletList;}private set{bulletList = value;}}


        private void Awake() 
        {
        }

        // 生成関数　第一引数：座標　
        // 第三引数：Listでの生成　第四引数：表示したいオブジェクト
        public BaseTrump Launch
        (Vector3 _pos, List<BaseTrump> tmpList, BaseTrump obj)
        {
            BaseTrump tmpObj = null;
            // オブジェクトを取り出す
            tmpObj = judgObj(obj);
        
            // オブジェクトがnullで帰ってきたら新規作成
            if (tmpObj == null) 
            {
                tmpObj = Instantiate(obj, _pos, Quaternion.identity,transform);
                tmpList.Add(tmpObj);
                tmpObj.objectPoolCallBack = Collect;
            }


            // 座標設定
            showInStage(_pos, tmpObj);
            // 表示
            tmpObj.gameObject.SetActive(true);
            //呼び出し元に渡す
            return tmpObj;
        }

        
        // 生成されるオブジェクトが何か判断
        private BaseTrump judgObj(BaseTrump target)
        {
            BaseTrump tmpObj = null;

            foreach(BaseTrump obj in BulletList)
            {   // 非アクティブかつ表示したいオブジェクトか確認
                if(!obj.gameObject.activeSelf && obj.gameObject.tag == target.gameObject.tag)
                    tmpObj = obj;
            }
            return tmpObj;
            
        }

        // 回収処理　第一引数：格納するList 第二引数：回収されるオブジェクト
        public static void Collect(BaseTrump obj)
        {
            //トランプを飛んでいく音を止める
            //InGameSceneController.AudioInstance.audioSource.Stop();
            //ゲームオブジェクトを非表示
            obj?.gameObject.SetActive(false);
        }

        // 座標設定関数 第一引数：生成する座標 第二引数：生成されるオブジェクト
        private void showInStage(Vector3 _pos, BaseTrump obj)
        {
            obj.transform.position = _pos;
        }
    }
}
