using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerTips : MonoBehaviour
    {
        [SerializeField] private GameObject _materializerTip;
        [SerializeField] private GameObject _energySeekerTip;
        [SerializeField] private GameObject _craftWindowTip;
        [SerializeField] private GameObject _backPackTip;
        [SerializeField] private GameObject _voidTip;
        [SerializeField] private GameObject _rentTip;

        [SerializeField] private GameObject _finalTip;

        [SerializeField] private int _maxShowedTip;

        private int _tipShowed = 0;

        private bool _showed1 = false;
        private bool _showed2 = false;
        private bool _showed3 = false;
        private bool _showed4 = false;
        private bool _showed5 = false;
        private bool _showed6 = false;

        public static PlayerTips Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }

        public void ShowMaterializerTip()
        {
            if (_showed1) return;

            _showed1 = true;
            _materializerTip.SetActive(true);
            Tick();
        }

        public void ShowEnergySeekerTip()
        {
            if (_showed2) return;

            _showed2 = true;

            _energySeekerTip.SetActive(true);
            Tick();
        }

        public void ShowCraftWindowTip()
        {
            if (_showed3) return;

            _showed3 = true;

            _craftWindowTip.SetActive(true);
            Tick();
        }

        public void ShowBackPackTip()
        {
            if (_showed4) return;

            _showed4 = true;

            _backPackTip.SetActive(true);
            Tick();
        }

        public void ShowVoidTip()
        {
            if (_showed5) return;

            _showed5 = true;

            _voidTip.SetActive(true);
            Tick();
        }

        public void ShowRentTip()
        {
            if (_showed6) return;

            _showed6 = true;

            _rentTip.SetActive(true);
            Tick();
        }

        private void Tick()
        {
            _tipShowed++;

            if(_tipShowed >= _maxShowedTip)
            {
                _finalTip.SetActive(true);
            }
        }
    }
}