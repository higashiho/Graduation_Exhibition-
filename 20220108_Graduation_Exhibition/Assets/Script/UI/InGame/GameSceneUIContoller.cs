using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIContoller : BaseUI
{
    // Start is called before the first frame update
    void Start()
    {
        ItemUI.Items.FindItems(this);
    }

    // Update is called once per frame
    void Update()
    {
        TrumpUI.Trumps.Move(this);
        ItemUI.Items.ItemCount(this);
    }
}
