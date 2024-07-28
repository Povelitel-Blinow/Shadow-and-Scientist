using DG.Tweening;
using InWorldUINamespace;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace CursorNamespace
{
    public class TipText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetTip(TipableObjectNames name)
        {
            gameObject.SetActive(true);

            // I don't know how it works but ot works
            _text.text = Regex.Replace(name.ToString(), "([a-z])([A-Z])", "$1 $2");
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _text.text = "";
        }
    }
}