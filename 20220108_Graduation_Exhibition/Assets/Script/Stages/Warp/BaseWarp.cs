using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Warp
{
    public class BaseWarp : MonoBehaviour
    {
        [SerializeField, Header("ワープできるか")]
        protected bool onWarp = false;
        public bool OnWarp{get{return onWarp;}set{onWarp = value;}}

        // インスタンス化
        protected WarpMove warpMove = new WarpMove();

        /// <summary>
        /// ワープできるか確認関数
        /// </summary>
        protected void warpCheck()
        {
            // フラグがたっていたら色変更
            if(OnWarp)
                this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}