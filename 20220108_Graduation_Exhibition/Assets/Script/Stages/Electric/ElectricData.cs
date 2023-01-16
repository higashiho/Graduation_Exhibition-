using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create ElectricData")]
public class ElectricData : ScriptableObject
{
    [SerializeField,Header("電力最大値")]
    private int maxElectric;
    public int MaxElectric{get{return maxElectric;}private set{maxElectric = value;}}
}
