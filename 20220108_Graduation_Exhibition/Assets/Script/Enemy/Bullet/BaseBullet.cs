using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

public class BaseBullet : MonoBehaviour
{

    [Header("弾丸のデータ")]
    [SerializeField]    
    protected BulletData bulletData;
    public BulletData BulletsData{get{return bulletData;}private set{bulletData = value;}}
    public UnityAction<BaseBullet> objectPoolCallBack;

    
    // 移動向き
    protected Vector3 shotForward;  
    public Vector3 ShotForward{get{return shotForward;}set{shotForward = value;}}
    
    // 時間計測
    protected float time;
    public float TimeManage{get{return time;}set {time = value;}}

    
    // タスク管理用
    public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  
}
