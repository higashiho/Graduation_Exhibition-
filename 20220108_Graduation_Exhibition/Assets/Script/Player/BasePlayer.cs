using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [Header("playerのデータ")]
    [SerializeField]    
    protected PlayerData playerData;
    public PlayerData DataPlayer{get {return playerData;}private set{playerData = value;}}
    public enum PlayerState
    {
        DEFAULT,
        MOVE,
        JUMP,
        CHANGE
    }
    [SerializeField]
    protected PlayerState playerStatus = PlayerState.DEFAULT;
    public PlayerState PlayerStatus{get{return playerStatus;}set {playerStatus = value;}}

    
    // トランプを打てるかフラグ
    [SerializeField]
    protected bool shotFlag = true;
    public bool ShotFlag{get{return shotFlag;}set{shotFlag = value;}}

    // 入力関係
    protected void imput()
    {
        // 移動ボタンを押されたらステート更新
        if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            playerStatus = PlayerState.MOVE;

        // ジャンプボタンを押されたらステート更新
        if(Input.GetKeyDown(KeyCode.Space))
            playerStatus = PlayerState.JUMP;
        
    }
}
