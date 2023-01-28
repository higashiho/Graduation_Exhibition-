using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class BaseAudio : MonoBehaviour
    {
        // メインシーンBGM
        public AudioSource MainBGM;
        // プレイヤー移動音
        public AudioSource PalyerMove;
        // トランプを投げる音
        public AudioSource ThrowTramp;
        //トランプが飛んでいく音
        public AudioSource MoveTramp;
        //エネミー発見音
        public AudioSource EnemyFound;
        //エネミー攻撃音
        public AudioSource EnemyAttack;
        //プレイヤーがエネミーに見つかる音
        public AudioSource Fiald;
        //ゲームオーバーシーンBGM
        public AudioSource GameOverBGM;
        //鉄格子が閉まっている音
        public AudioSource GameOverCloseDore;
        //鉄格子が閉まり切った音
        public AudioSource ClosingDore;
    }
}
