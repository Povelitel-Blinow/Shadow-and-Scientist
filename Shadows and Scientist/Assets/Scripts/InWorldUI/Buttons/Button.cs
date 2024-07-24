using DG.Tweening;
using GameDesign;
using UnityEngine;

namespace InWorldUINamespace
{
    public abstract class Button : MonoBehaviour, IClickable
    {
        [SerializeField] private ButtonSettings _settings;

        private float _clickScaleRatio => _settings.ClickScaleRatio;
        private float _clickTime => _settings.ClickTime;

        public void Click()
        {
            transform.DOComplete();

            OnClick();

            transform.DOScale(_clickScaleRatio, _clickTime).SetLoops(2, LoopType.Yoyo);
        }

        public virtual void OnClick() { }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}