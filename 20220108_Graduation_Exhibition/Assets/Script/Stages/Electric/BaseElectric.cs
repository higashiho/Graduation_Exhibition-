using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using System.Threading;

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

        [SerializeField, Header("UIマスク")]
        protected RectMask2D[] electricUI = new RectMask2D[3];
        public RectMask2D[] ElectricUI{get{return electricUI;} private set{electricUI = value;}}

        // タスク管理用
        public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  
 

        // インスタンス化
        protected ElectricMove electricMove = new ElectricMove();
    }
}