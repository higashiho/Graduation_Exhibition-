using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GameSceneUIContoller : BaseUI
    {

        // インスタンス化
        private ItemUI itemUI = new ItemUI();
        private TrumpUI trumpUI = new TrumpUI();

        // Start is called before the first frame update
        void Start()
        {
            itemUI.FindItems(this);
        }

        // Update is called once per frame
        void Update()
        {
            trumpUI.Move(this);
            itemUI.ItemCount(this);
        }
    }
}