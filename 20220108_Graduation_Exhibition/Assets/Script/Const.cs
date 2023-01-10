using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const
{
    // カメラ用定数
    public const float CAMERA_MOVE_MAX_X = 9.0f;         // カメラが移動できる最大x座標
    public const float CAMERA_MOVE_MAX_Y = 27.0f;        // カメラが移動できる最大y座標



    // player用定数
    public const float CHANGE_SPEED = 10.0f;            // 敵との入れ替え時スピード
    public const int CHANGE_DELAY_SPEED = 1;            // 入れ替え時の遅延時間
    public const float GAME_CLEAR_POS_Y = 32.0f;        // ゲームクリア座標
    public const int START_GRAVITY_SCALE = 1;           // 初期重力量
    

    // エネミー用定数
    


    // Debug用定数
    public const float MOUSE_POS_X = 10.0f;               // マウス座標の正規化


    // Task用定数
    public const int CHANGE_SECOND = 1000;              // nミリ秒を秒に変換用
}
