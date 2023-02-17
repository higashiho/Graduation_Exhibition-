using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create TrumpData")]
public class TrumpData : ScriptableObject
{
    [SerializeField, Header("挙動スピード")]    // 挙動スピード
    private float trumpSpeed;
    public float TrumpSpeed{get{return trumpSpeed;}private set{trumpSpeed = value;}}

    
    [SerializeField, Header("消える時間")]    // 消える時間
    private int deleteTime;
    public int DeleteTime{get{return deleteTime;}private set{deleteTime = value;}}

    [SerializeField, Header("打つ間隔")]    // 打つ間隔
    private int shotTime;
    public int ShotTime{get{return shotTime;}private set{shotTime = value;}}

}
