using CursorNamespace;
using InWorldUINamespace;
using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerTip
    {
        private float _startTippingDelay = 0.5f;

        private ITipable _currentTippable;
        private float _currentTippingTime;

        public void TryTip()
        {
            ITipable tip = PlayerRaycast.Instance.RayCast<ITipable>();

            if (tip == null)
            {
                VoidTipable();
                return;
            }

            if(tip != _currentTippable)
            {
                VoidTipable();
                _currentTippable = tip;
                Tip();
                return;
            }

            Tip();
        }

        private void VoidTipable()
        {
            _currentTippable = null;
            CursorUI.Instance.StopTipping();
            _currentTippingTime = 0;
        }

        private void Tip()
        {
            if (_currentTippable == null) return;

            if(_currentTippingTime >= _startTippingDelay)
            {
                CursorUI.Instance.TipObject(_currentTippable.GetTipableType());
            }
            else
            {
                _currentTippingTime += Time.deltaTime;
            }
        }
    }
}