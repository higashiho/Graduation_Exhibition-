using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : BaseCamera
{
    public static CameraMove MoveCamera{get;private set;} = new CameraMove();

    // カメラ挙動
    public void Move(GameObject obj)
    {
        // プレイヤーの座標取得
        var playerPos = InGameController.Player.gameObject.transform.position;

        // カメラを一定一以上に行かないように設定
        moveStop(ref playerPos);

        // 位置更新
        obj.transform.position = playerPos + offset;
    }

    // カメラの移動可能範囲確認用
    private void moveStop(ref Vector3 pos)
    {
        // 移動可能ｙ座標
        if(pos.y <= 0)
            pos.y = 0;
        
        if(pos.y >= Const.CAMERA_MOVE_MAX_Y)
            pos.y = Const.CAMERA_MOVE_MAX_Y;


        // 移動可能ｘ座標
        if(pos.x <= 0)
            pos.x = 0;
        
        if(pos.x >= Const.CAMERA_MOVE_MAX_X)
            pos.x = Const.CAMERA_MOVE_MAX_X;
    }
}
