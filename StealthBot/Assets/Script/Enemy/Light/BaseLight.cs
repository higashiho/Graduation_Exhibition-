using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.Rendering.Universal;


namespace EnemyLight
{
    public class BaseLight : MonoBehaviour
    {
        [SerializeField, Header("監視するアイテム")]
        protected GameObject[] items;
        public GameObject[] Items{get{return items;}set{items = value;}}
        
        [SerializeField, Header("監視するアイテムの座標")]
        protected Vector3[] itemsPos = new Vector3[4];
        public Vector3[] ItemsPos{get{return itemsPos;}set{itemsPos = value;}}

        // 現在のシーン
        public string NowScene{get;protected set;}
        
        [SerializeField, Header("リトライパネル")]
        protected Image retryPanel;
        public Image RetryPanel{get{return retryPanel;}}

        [SerializeField, Header("自身のライト")]
        protected Light2D myLight;
        public Light2D MyLight{get{return myLight;}protected set{myLight = value;}}
        
        // タスク管理用
        public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  

        // インスタンス化
        protected LightMove lightMove = new LightMove();
    }
}