using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const
{
    // 以下カメラ用定数
    public const float CAMERA_MOVE_MAX_X = 9.0f;         // カメラが移動できる最大x座標
    public const float CAMERA_MOVE_MAX_Y = 27.0f;        // カメラが移動できる最大y座標
    // 以上カメラ用定数

    // 以下ステージ用定数
    public const float CHANGE_ELECTRIC_TIME = 500.0f;           // 電力回復時間(1/3なので合計15秒)
    public const float PADDING_UP_NAM = 0.2f;                   // 一回転で減るPaddingの値
    public const int ELECTRIC_WAIT_TIME = 10;                   // 回復時の遅延時間（0.01秒）
    public const float PADDING_TOP_MAX = 100.0f;                // padding最大値
    // 以上ステージ用定数

    // 以下player用定数
    public const float GAME_CLEAR_POS_Y = 32.0f;        // ゲームクリア座標
    public const int START_GRAVITY_SCALE = 1;           // 初期重力量
    public const float WARP_TIME = 1.5f;                // ワープの一動作ごとの間隔
    // 以上player用定数
    

    // 以下エネミー用定数
    public const float LIGHT_MOVE_TIME = 25f;            // ライトの移動間隔
    public const int LIGHT_ACTIVE_RETUN_TIME = 10;       // ライトのActiveが戻る時間
    // 以上エネミー定数

    // 以下テキスト表用定数
    public static readonly float[] EXPLANATION_DISPLAY_POS = {-4.0f,-1.0f,-8.0f,-2.0f}; // 説明テキスト表示される範囲
    public const float MAX_ALPHA = 1.0f;                                                // 透明度最大値
    // 以上テキスト用定数

    // 以下Debug用定数
    public const float MOUSE_POS_X = 10.0f;               // マウス座標の正規化
    // 以上Debug用定数


    // 以下Task用定数
    public const int CHANGE_SECOND = 1000;              // nミリ秒を秒に変換用
    // 以上Task用定数
}
