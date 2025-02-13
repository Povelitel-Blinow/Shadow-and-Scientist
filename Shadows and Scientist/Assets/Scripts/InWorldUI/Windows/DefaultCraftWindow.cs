using CraftNamespace;
using MaterialNamespace;
using PlayerNamespace;
using SlotNamespace;
using System.Collections;
using UnityEngine;

namespace WindowNamespace
{
    public class DefaultCraftWindow : CraftBlockWindow
    {
        [SerializeField] private CraftSlot _inputSlot;
        [SerializeField] private OutPutSlot _outputSlot;

        [SerializeField] private InSlotPutable _craftResult;

        [SerializeField] private LineTimer _lineTimer;

        [SerializeField] private float _craftTime;

        private void OnEnable()
        {
            PlayerTips.Instance.ShowCraftWindowTip();

            _inputSlot.OnPut += TryMake;
            _outputSlot.OnPutOut += TryMake;
        }

        private void  Start()
        {
            _inputSlot.OnPut += TryMake;
            _outputSlot.OnPutOut += TryMake;
        }

        public void TryMake()
        {
            if (_inputSlot.Material == null) return;

            if (_outputSlot.InSlot != null) return;

            if (_inputSlot.Material.MaterialType != MaterialType.Metall) return;

            StartCoroutine(Crafting());
        }

        private IEnumerator Crafting()
        {
            _lineTimer.SetLine(0);
            float timer = 0f;
            while (timer < _craftTime)
            {
                if(_inputSlot.Material == null)
                {
                    _lineTimer.SetLine(0);
                    yield break;
                }

                timer += Time.deltaTime;
                _lineTimer.SetLine(timer/_craftTime);
                yield return new WaitForEndOfFrame();
            }

            _inputSlot.VoidSlot();
            _outputSlot.PutInObject(_craftResult);
            _lineTimer.SetLine(0);
        }

        private void OnDisable()
        {
            _inputSlot.OnPut -= TryMake;
            _outputSlot.OnPutOut -= TryMake;
        }
    }
}