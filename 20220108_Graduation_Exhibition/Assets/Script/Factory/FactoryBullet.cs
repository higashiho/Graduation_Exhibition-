using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;


namespace Factory
{
    public class FactoryBullet : MonoBehaviour
    {
        [SerializeField]    // 弾格納リスト
        private List<BaseBullet> bulletList = new List<BaseBullet>(15);
        public List<BaseBullet> BulletList{get{return bulletList;}private set{bulletList = value;}}


        private void Awake() 
        {
        }

        // 生成関数　第一引数：座標　
        // 第三引数：Listでの生成　第四引数：表示したいオブジェクト
        public BaseBullet Launch
        (Vector3 _pos, List<BaseBullet> tmpList, BaseBullet obj)
        {
            BaseBullet tmpObj = null;
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
        private BaseBullet judgObj(BaseBullet target)
        {
            BaseBullet tmpObj = null;

            foreach(BaseBullet obj in BulletList)
            {   // 非アクティブかつ表示したいオブジェクトか確認
                if(!obj.gameObject.activeSelf && obj.gameObject.tag == target.gameObject.tag)
                    tmpObj = obj;
            }
            return tmpObj;
            
        }

        // 回収処理　第一引数：格納するList 第二引数：回収されるオブジェクト
        public static void Collect(BaseBullet obj)
        {
            obj.TimeManage = 0;
            //ゲームオブジェクトを非表示
            if(obj != null)
                obj.gameObject.SetActive(false);
        }

        // 座標設定関数 第一引数：生成する座標 第二引数：生成されるオブジェクト
        private void showInStage(Vector3 _pos, BaseBullet obj)
        {
            obj.transform.position = _pos;
        }
    }
}
