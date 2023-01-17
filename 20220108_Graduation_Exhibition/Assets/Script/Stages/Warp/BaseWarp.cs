using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Warp
{
    public class BaseWarp : MonoBehaviour
    {
        [SerializeField, Header("電気のデータ")]
        protected ElectricData electricData;
        public ElectricData ElectricsData{get{return electricData;}private set{electricData = value;}}
        [SerializeField, Header("ワープできるか")]
        protected bool onWarp = false;
        public bool OnWarp{get{return onWarp;}set{onWarp = value;}}

        [SerializeField, Header("playerと当たっているか")]
        protected bool onPlayer;
        public bool OnPlayer{get{return onPlayer;}set{onPlayer =value;}}

        // インスタンス化
        protected WarpMove warpMove = new WarpMove();

        /// <summary>
        /// ワープできるか確認関数
        /// </summary>
        protected void warpCheck()
        {
            // フラグがたっていたら色変更
            if(OnWarp)
                this.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}