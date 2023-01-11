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
    public const float TMPENEMY_POS_ADJUST = 1;         // チェンジ座標目標地点調整用
    

    // エネミー用定数
    

    // 説明テキスト表示用定数
    public static readonly float[] EXPLANATION_DISPLAY_POS = {-4.0f,-1.0f,-8.0f,-2.0f};
    public const float MAX_ALPHA = 1.0f;                // 透明度最大値

    // Debug用定数
    public const float MOUSE_POS_X = 10.0f;               // マウス座標の正規化


    // Task用定数
    public const int CHANGE_SECOND = 1000;              // nミリ秒を秒に変換用
}
