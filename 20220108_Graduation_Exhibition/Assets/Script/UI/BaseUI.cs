using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks; 
using System.Threading;


namespace UI
{
    public class BaseUI : MonoBehaviour
    {
        // タスク用
        public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  

        [Header("Title")]
        [SerializeField, Header("タイトルのイメージ")]
        protected Image[] titleImage = new Image[7];
        public Image[] TitleImage{get{return titleImage;}}
        
        [SerializeField, Header("ボタン")]
        protected Button moveButton;
        public Button MoveButton{get{return moveButton;}}

        [SerializeField,Header("挙動させるイメージ")]
        protected GameObject moveImage;
        public GameObject MoveImage{get{return moveImage;}}
        // 挙動させるイメージの初期座標
        public Vector3 StartPlayPos{get; protected set;}
        // インスタンス化
        protected TitleMove titleMove;
        [Header("InGame")]
        [SerializeField, Header("トランプUI")]
        protected Slider trumpSlider;
        public Slider TrumpSlider{get{return trumpSlider;}}
        [SerializeField, Header("トランプのUI")]
        protected TrumpData trumpData;

        // スライダー用タスク
        protected UniTask? sliderTask;
        public UniTask? SliderTask{get{return sliderTask;}set {sliderTask = value;}}
        [SerializeField, Header("アイテムのUI")]
        protected Text itemsUI;
        public Text ItemsUI{get {return itemsUI;}}

        // アイテムの取得数
        protected static int haveItems;
        public static int HaveItem      // 静的変数な為どこで代入されたかわかりやすいように代入された場合はLogを出す
        {get{return haveItems;}set{Debug.Log("haveItem++");haveItems = value;}}

        // 出現アイテム格納用
        [SerializeField, Header("出現アイテム")]
        protected GameObject[] items = new GameObject[4];
        public GameObject[] Items{get{return items;}set{items = value;}}

        // 説明テキスト
        [SerializeField, Header("説明テキスト")]
        protected TextMeshProUGUI[] expText = new TextMeshProUGUI[2];
        public TextMeshProUGUI[] ExpText{get{return expText;}}

        [Header("Result")]
        [SerializeField, Header("スコアテキスト")]
        protected TextMeshProUGUI  scoreText;
        public TextMeshProUGUI  ScoreText{get{return scoreText;}}
        [SerializeField, Header("ゲームオーバーテキスト")]
        protected TextMeshProUGUI gameOverText;
        public TextMeshProUGUI  GameOverText{get{return gameOverText;}}
        [SerializeField,Header("鉄格子")]
        protected RawImage jail;
        public RawImage Jail{get{return jail;}}
        [SerializeField, Header("ダイアモンドのエフェクト")]
        protected ParticleSystem diamondEfect;
        public ParticleSystem DiamondEfect{get{return diamondEfect;} set{diamondEfect = value;}}
        
        [SerializeField, Header("アクトテキスト")]
        protected TextMeshProUGUI aktText;
        public TextMeshProUGUI AktText{get{return aktText;}}
    }
}