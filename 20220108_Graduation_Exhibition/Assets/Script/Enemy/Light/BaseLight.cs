using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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

        [SerializeField,Header("エネミー")]
        protected GameObject[] enemys;
        public GameObject[] Enemys{get{return enemys;}set{enemys = value;}}
        
        // タスク管理用
        public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  

        // インスタンス化
        protected LightMove lightMove = new LightMove();
    }
}