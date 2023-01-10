using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create PlayerData")]
public class PlayerData : ScriptableObject
{
    // 挙動スピード
    [SerializeField, Header("移動スピード")]
    private float playerSpeed;
    public float PlayerSpeed{get{return playerSpeed;}private set{playerSpeed = value;}}

    // ジャンプ力
    [SerializeField, Header("ジャンプ力")]
    private float playerJunpPower;
    public float PlayerJunpPower{get{return playerJunpPower;}private set{playerJunpPower = value;}}

    // ジャンプフラグ
    [SerializeField]
    private bool junpFlag;
    public bool JunpFlag{get {return junpFlag;}set {junpFlag = value;}} 


    // ジャンプフラグを折るタイマー
    [SerializeField, Header("ジャンプ間隔")]
    private int junpFlagTimer;
    public int JunpFlagTimer{get{return junpFlagTimer;}private set{junpFlagTimer = value;}}
    

    [SerializeField,Header("入れ替わる間隔時間")]
    private float changeTimer;
    public float ChangeTimer{get{return changeTimer;}private set{changeTimer = value;}}
}
