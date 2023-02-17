using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;
using Player;
using UI;
using Enemy;
using EnemyLight;
using DG.Tweening;
using Audio;

public class InGameSceneController : MonoBehaviour
{
    // UI
    public static BaseUI UI{get;private set;}

    // Player
    public static BasePlayer Player{get;private set;}

    // エネミー関係
    public static BaseLight enemyLight{get;private set;}
    private GameObject[] enemys = new GameObject[20];
    public static BaseEnemy[] Enemys = new BaseEnemy[20];
    
    // obujectPool
    public static FactoryBullet BulletObjectPool{get;private set;}
    public static FactoryTrump TrumpObjectPool{get;private set;}

    public static BaseAudio AudioInstance{get; private set;}
    void Awake()
    {
        UI = GameObject.FindWithTag("UI").GetComponent<BaseUI>();
        Player = GameObject.FindWithTag("Player").GetComponent<BasePlayer>();
        BulletObjectPool = GameObject.FindWithTag("Factory").GetComponent<FactoryBullet>();
        TrumpObjectPool = GameObject.FindWithTag("Factory").GetComponent<FactoryTrump>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        AudioInstance = GameObject.Find("Audio Source").GetComponent<AudioController>();

        for(int i = 0; i < enemys.Length; i++)
        {
            Enemys[i] = enemys[i].GetComponent<BaseEnemy>();
        }
    }


    void OnDestroy()
    {

        DOTween.KillAll();
    }
}
