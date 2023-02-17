using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class BaseAudio : MonoBehaviour
    {
        public static AudioSource audioSource{get; protected set;}
        public static AudioSource PlayerAoudio{get;protected set;}
        // メインシーンBGM
        public AudioClip MainBGM;
        // プレイヤー移動音
        public AudioClip MovePlayer;
        // トランプを投げる音
        public AudioClip ThrowTramp;
        //トランプが飛んでいく音
        public AudioClip MoveTramp;
        //エネミー発見音
        public AudioClip EnemyFound;
        //エネミー攻撃音
        public AudioClip EnemyAttack;
        //プレイヤーがエネミーに見つかる音
        public AudioClip Fiald;
        //ゲームオーバーシーンBGM
        public AudioClip GameOverBGM;
        //鉄格子が閉まっている音
        public AudioClip GameOverCloseDore;
        //鉄格子が閉まり切った音
        public AudioClip ClosingDore;
        //入れ替わり音
        public AudioClip Change;
    }
}
