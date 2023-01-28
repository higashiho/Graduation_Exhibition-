using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class DiamondController : BaseDiamond
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
        
        void OnDestroy()
        {
            cts?.Cancel();
        }
    }
}

