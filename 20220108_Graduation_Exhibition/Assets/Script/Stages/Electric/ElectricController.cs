using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electric
{
    public class ElectricController : BaseElectric
    {
        // Start is called before the first frame update
        void Start()
        {
            // このトランスフォームを取得
            for(int i = 0; i < ElectricUIPos.Length; i++)
            ElectricUIPos[i] = electricUI[i].transform.GetChild(0).transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            electricMove.Move(this);
        }
    }
}