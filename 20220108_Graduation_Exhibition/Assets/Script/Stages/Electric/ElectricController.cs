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
            
        }

        // Update is called once per frame
        void Update()
        {
            electricMove.Move(this);
            electricMove.ElectricManage(this);
        }
    }
}