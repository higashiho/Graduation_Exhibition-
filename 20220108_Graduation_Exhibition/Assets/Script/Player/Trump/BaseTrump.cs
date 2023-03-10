using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

namespace Trump
{
    public class BaseTrump : MonoBehaviour
    {
        [Header("トランプのデータ")]
        [SerializeField]    
        protected TrumpData trumpData;
        public TrumpData TrumpsData{get{return trumpData;}private set{trumpData = value;}}

        // 移動向き
        protected Vector3 shotForward;  
        public Vector3 ShotForward{get{return shotForward;}set{shotForward = value;}}



        // 回収イベント
        public UnityAction<BaseTrump> objectPoolCallBack;

        // タスク管理用
        public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  
    
        
        // インスタンス化
        protected TrumpMove moveTrump = new TrumpMove();
    }
}