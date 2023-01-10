using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    // UI
    public static BaseUI UI{get;private set;}

    // Player
    public static BasePlayer Player{get;private set;}


    void Awake()
    {
        UI = GameObject.FindWithTag("UI").GetComponent<BaseUI>();
        Player = GameObject.FindWithTag("Player").GetComponent<BasePlayer>();
        
    }
}
