using CraftNamespace;
using System;
using UnityEngine;

namespace WindowNamespace
{
    public abstract class CraftBlockWindow : MonoBehaviour
    {
        public Action<bool> OnWork;
        public Action<float> OnLineTimerChange;
        protected bool _canWork = true;

        public void Init()
        {
            gameObject.SetActive(false);
        }

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