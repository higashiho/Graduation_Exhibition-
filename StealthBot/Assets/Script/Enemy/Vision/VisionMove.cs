using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Vision
{
    public class VisionMove
    {
        // 挙動
        public void Move(BaseVision tmpVision)
        {
            // 親の座標とオフセットを合わせる
            tmpVision.transform.position = tmpVision.transform.parent.transform.position + tmpVision.Offset;
        }

        // オフセット初期化
        public void StartOffset(BaseVision tmpVision)
        {
            // 自分の座標から親の座標を引いてオフセットに代入
            tmpVision.Offset = tmpVision.transform.position - tmpVision.transform.parent.transform.position;
        }
    }
}