using System;
using UnityEngine;
using WorldNamespace;

namespace WindowNamespace
{
    public abstract class CraftBlockWindow : MonoBehaviour
    {
        [Header("Tip")]
        [SerializeField] private TipButton _tipButton;

        public Action<bool> OnWork;
        public Action<float> OnLineTimerChange;
        protected bool _canWork = true;

        public void Init()
        {
            gameObject.SetActive(false);

            transform.parent = WorkPlace.Instance.transform;
            transform.localPosition = Vector3.zero;

            OnInit();
        }

        protected virtual void OnInit() { }

        public void ShowUp()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetCanWork(bool canWork)
        {
            _canWork = canWork;
            if(_canWork == false)
                Hide();
        }
    }
}