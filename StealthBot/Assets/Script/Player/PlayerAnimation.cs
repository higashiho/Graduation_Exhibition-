using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation
    {
        public void PlayerAnimator(BasePlayer tmpPlayer)
        {
            switch(tmpPlayer.PlayerStatus)
            {
                case BasePlayer.PlayerState.MOVE:             //右移動と左移動の切り替え
                    if(tmpPlayer.PlayerMoveFlags == BasePlayer.PlayerMoveFlag.LEFT)
                    {
                        tmpPlayer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = tmpPlayer.LeftPlayer;
                    }
                    else if(tmpPlayer.PlayerMoveFlags == BasePlayer.PlayerMoveFlag.RIGHT)
                    {
                        tmpPlayer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = tmpPlayer.RightPlayer;
                    }
                        break;
                default:
                        break;
            }
        }
    }
}