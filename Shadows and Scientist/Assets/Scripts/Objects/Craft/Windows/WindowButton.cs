using DG.Tweening;
using ObjectsNamespace;
using UnityEngine;

namespace WindowNamespace
{
    public abstract class WindowButton : MonoBehaviour, ISelectable, IClickable
    {
        [SerializeField] private Transform _defaultPos;
        [SerializeField] private Transform _selectedPos;

        [SerializeField] private float _selectTime;

        public abstract void Click();

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