using DG.Tweening;
using PlayerNamespace;
using SlotNamespace;
using UnityEngine;

namespace VoiderNamespace
{
    public class Voider : MonoBehaviour, IClickable
    {
        [SerializeField] private BothPutSlot _slot;

        [SerializeField] private Transform _defaultPos;
        [SerializeField] private Transform _openPos;
        [SerializeField] private float _openTime;

        private bool _isActive = false;

        public void Click()
        {
            PlayerTips.Instance.ShowVoidTip();

            Debug.Log(_isActive);

            transform.DOComplete();
            _isActive = !_isActive;

            if (_isActive)
                transform.DOLocalMove(_openPos.localPosition, _openTime);
            else
                transform.DOLocalMove(_defaultPos.localPosition, _openTime);
        }

        public void VoidSlot()
        {
            _slot.VoidSlot();
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}