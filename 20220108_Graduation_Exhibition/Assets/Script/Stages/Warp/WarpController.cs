using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Warp
{
    public class WarpController : BaseWarp
    {
        // Start is called before the first frame update
        void Start()
        {
            warpMove = new WarpMove(this);
        }

        // Update is called once per frame
        void Update()
        {
            warpCheck();

            // プレイヤーと接地しているか
            if(OnPlayer)
                warpMove.Move();
        }
    }
}