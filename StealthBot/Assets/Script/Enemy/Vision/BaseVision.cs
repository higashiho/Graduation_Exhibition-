using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Vision
{
    public class BaseVision : MonoBehaviour
    {
        // 親オブジェクトとの距離感格納用
        protected Vector3 offset;    
        public Vector3 Offset{get {return offset;}set{offset = value;}}  
    }
}