using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

namespace Electric
{
    public class BaseElectric : MonoBehaviour
    {
        [SerializeField, Header("電力のデータ")]
        protected ElectricData electricData;
        public ElectricData ElectricsData{get{return electricData;}private set{electricData = value;}}

        [SerializeField,Header("メインのライト")]
        protected Light2D mainLight;
        public Light2D MainLight{get{return mainLight;}private set{mainLight = value;}}

        [SerializeField, Header("監視カメラのライト")]
         protected Light2D cameraLight;
        public Light2D CameraLight{get{return cameraLight;}private set{cameraLight = value;}}

        
        [SerializeField, Header("電力のUI")]
        protected Image[] electricUI = new Image[3];
        public Image[] ElectricUI{get{return electricUI;} private set{electricUI = value;}}

        [SerializeField, Header("UIマスクの初期座標")]
        protected Vector3[] electricUIPos = new Vector3[3];
        public Vector3[] ElectricUIPos{get{return electricUIPos;} private set{electricUIPos = value;}}


        // インスタンス化
        protected ElectricMove electricMove = new ElectricMove();
    }
}