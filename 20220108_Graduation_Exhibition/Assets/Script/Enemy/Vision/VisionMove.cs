using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionMove
{
    public static VisionMove MoveVision{get;private set;} = new VisionMove();

    public void Move(BaseVision tmpVision, BaseEnemy tmpEnemy)
    {
        tmpVision.transform.position = tmpEnemy.transform.position + tmpVision.Offset;
    }

    // オフセット初期化
    public void StartOffset(BaseVision tmpVision, BaseEnemy tmpEnemy)
    {
        tmpVision.Offset = tmpVision.transform.position - tmpEnemy.transform.position;
    }
}
