using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vision
{
    public class VisionController : BaseVision
    {

        // インスタンス化
        private VisionMove moveVision = new VisionMove();
        // Start is called before the first frame update
        void Start()
        {
            moveVision.StartOffset(this, enemy);
        }

        // Update is called once per frame
        void Update()
        {
            moveVision.Move(this, enemy);
        }
    }
}