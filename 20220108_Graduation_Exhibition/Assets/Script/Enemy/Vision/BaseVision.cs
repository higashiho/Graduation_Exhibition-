using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVision : MonoBehaviour
{
    // 親オブジェクトとの距離感格納用
    protected Vector3 offset;    
    public Vector3 Offset{get {return offset;}set{offset = value;}}  

    [Header("エネミー")]
    [SerializeField]
    protected BaseEnemy enemy;
}
