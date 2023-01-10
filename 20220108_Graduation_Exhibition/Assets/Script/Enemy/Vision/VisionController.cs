using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : BaseVision
{
    // Start is called before the first frame update
    void Start()
    {
        VisionMove.MoveVision.StartOffset(this, enemy);
    }

    // Update is called once per frame
    void Update()
    {
        VisionMove.MoveVision.Move(this, enemy);
    }
}
