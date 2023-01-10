using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debug時のみ使用可能でバック機能用クラス
#if UNITY_EDITOR
public class DebugMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }



    // Player座標移動
    private void movePlayer()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            var tmpMouse = Input.mousePosition;
            var tmpTarget = Camera.main.ScreenToWorldPoint(new Vector3(tmpMouse.x, tmpMouse.y, Const.MOUSE_POS_X));
            InGameController.Player.transform.position = tmpTarget;
        }
    }
}
#endif