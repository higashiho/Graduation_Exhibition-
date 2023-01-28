using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class TitleImageController : BaseTitleImage
    {
        // Start is called before the first frame update
        void Start()
        {
            StartPos = this.transform.localPosition;
        }

        // Update is called once per frame
        void Update()
        {
        }
        
        void OnDestroy()
        {
            
            DOTween.KillAll();
        }
    }
}

