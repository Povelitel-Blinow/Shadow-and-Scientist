using CraftNamespace;
using MaterialNamespace;
using PlayerNamespace;
using SlotNamespace;
using SmallWorldNamespace;
using UnityEngine;
using WorldNamespace;

namespace GadgetNamespace
{
    public class EnergySeeker : MonoBehaviour
    {
        [SerializeField] private InSlotPutable _energyPrefab;
        [SerializeField] private OutPutSlot _slot;

        [SerializeField] private LineTimer _line;

        [Header("Catching Energy")]
        [SerializeField] private float _catchRatio;

        [Header("Sound")]
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private float _minDelay;
        [SerializeField] private float _maxDelay;

        private float _ratio = 0f;
        private float _timer = 0f;
        public static EnergySeeker Instance { get; private set; }

        private void OnEnable()
        {
            PlayerTips.Instance.ShowEnergySeekerTip();
        }

        public void Init()
        {
            Instance = this;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_ratio == 0) return;

            float tickTime = Mathf.Lerp(_maxDelay, _minDelay, _ratio);

            if(_timer >= tickTime)
            {
                _timer = 0;
                _soundManager.PlaySound();
            }
        }

        public void SetEnergyRangeRatio(float ratio)
        {
            _ratio = ratio;
            _line.SetLine(ratio);
        }

        public void Spawn()
        {
            if (_ratio >= _catchRatio)
            {
                if (_slot.InSlot != null) return;
                if (SmallEnergySeeker.Instance.TryCatchEnergy() == false) return;


                _slot.PutInObject(_energyPrefab);
            }
        }
    }
}