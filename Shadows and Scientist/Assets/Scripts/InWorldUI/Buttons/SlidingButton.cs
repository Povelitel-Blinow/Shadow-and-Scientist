using DG.Tweening;
using GameDesign;
using UnityEngine;

namespace InWorldUINamespace
{
    public abstract class SlidingButton : MonoBehaviour, IClickable, ISelectable
    {
        [SerializeField] private SlideButtonSettings _settings;

        [SerializeField] private Transform _defaultPos;
        [SerializeField] private Transform _selectedPos;

        [SerializeField] private float _selectTime => _settings.SelectTime;

        public void Click()
        {
            OnClick();
        }

        public virtual void OnClick() { }

        public void Deselect()
        {
            transform.DOLocalMove(_defaultPos.localPosition, _selectTime);
        }

        public void Select()
        {
            transform.DOLocalMove(_selectedPos.localPosition, _selectTime);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}