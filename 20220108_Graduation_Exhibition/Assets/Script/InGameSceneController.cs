using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;
using Player;
using UI;
using EnemyLight;
using DG.Tweening;


public class InGameSceneController : MonoBehaviour
{
    // UI
    public static BaseUI UI{get;private set;}

    // Player
    public static BasePlayer Player{get;private set;}

    // エネミー関係
    public static BaseLight enemyLight{get;private set;}


    
    // obujectPool
    public static FactoryBullet BulletObjectPool{get;private set;}
    public static FactoryTrump TrumpObjectPool{get;private set;}


    void Awake()
    {
        UI = GameObject.FindWithTag("UI").GetComponent<BaseUI>();
        Player = GameObject.FindWithTag("Player").GetComponent<BasePlayer>();
        BulletObjectPool = GameObject.FindWithTag("Factory").GetComponent<FactoryBullet>();
        TrumpObjectPool = GameObject.FindWithTag("Factory").GetComponent<FactoryTrump>();
    }


    void OnDestroy()
    {

        DOTween.KillAll();
    }
}
