using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BaseButton : MonoBehaviour
    {
        [SerializeField, Header("ボタン")]
        protected Button moveButton;

        [SerializeField,Header("挙動させるイメージ")]
        protected Image moveImage;
    }
}