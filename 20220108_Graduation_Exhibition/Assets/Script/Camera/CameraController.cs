using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraMove.MoveCamera.Offset = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove.MoveCamera.Move(this.gameObject);
    }
}
