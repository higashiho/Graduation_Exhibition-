using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseUI : MonoBehaviour
{
    [Header("Title")]
    [Header("InGame")]
    [SerializeField, Header("トランプUI")]
    protected Slider trumpSlider;
    public Slider TrumpSlider{get{return trumpSlider;}private set{trumpSlider = value;}}

    [SerializeField, Header("アイテムのUI")]
    protected Text itemsUI;
    public Text ItemsUI{get {return itemsUI;}private set{itemsUI = value;}}

    // アイテムの取得数
    protected static int haveItems;
    public static int HaveItem      // 静的変数な為どこで代入されたかわかりやすいように代入された場合はLogを出す
    {get{return haveItems;}set{Debug.Log("haveItem++");haveItems = value;}}

    // 出現アイテム格納用
    [SerializeField, Header("出現アイテム")]
    protected GameObject[] items = new GameObject[4];
    public GameObject[] Items{get{return items;}set{items = value;}}

    [Header("Result")]
    [SerializeField, Header("スコアテキスト")]
    protected TextMeshProUGUI  scoreText;
    public TextMeshProUGUI  ScoreText{get{return scoreText;}private set{scoreText = value;}}
}
