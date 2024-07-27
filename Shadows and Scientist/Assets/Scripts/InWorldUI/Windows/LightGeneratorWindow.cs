using SlotNamespace;
using MaterialNamespace;
using UnityEngine;
using System.Collections;
using CraftNamespace;

namespace WindowNamespace
{
    public class LightGeneratorWindow : CraftBlockWindow
    {
        [SerializeField] private CraftSlot[] _slots;

        [SerializeField] private OutPutSlot _outputSlot;

        [SerializeField] private InSlotPutable _result;

        [SerializeField] private LightGeneratorButton _button;

        [SerializeField] private float _craftTime;
        [SerializeField] private LineTimer _lineTimer;

        protected override void OnInit()
        {
            foreach (var slot in _slots)
            {
                slot.OnPut += TryCraft;
            }
        }

        private void TryCraft()
        {
            if (_outputSlot.InSlot != null) return;

            foreach(var slot in _slots)
            {
                if (slot.Material == null) return;
                if (slot.Material.MaterialType != MaterialType.EnergyCapsule) return;
            }

            StartCoroutine(Crafting());
        }

        private IEnumerator Crafting()
        {
            if (_canWork == false) yield break;

            OnWork.Invoke(true);

            float timer = 0;
            while (timer < _craftTime)
            {
                timer += Time.deltaTime;
                _lineTimer.SetLine(timer / _craftTime);

                if(CheckSlots() == false)
                {
                    StopWorking();
                    yield break;
                }

                yield return new WaitForEndOfFrame();
            }

            foreach (var slot in _slots)
            {
                slot.VoidSlot();
            }

            _outputSlot.PutInObject(_result);
            _button.Open();
            StopWorking();
        }

        private bool CheckSlots()
        {
            foreach( var slot in _slots)
            {
                if(slot.Material == null) 
                    return false;
                if(slot.Material.MaterialType != MaterialType.EnergyCapsule)
                    return false;
            }

            return true;
        }

        private void StopWorking()
        {
            _lineTimer.SetLine(0);
            OnWork.Invoke(false);
        }
    }
}