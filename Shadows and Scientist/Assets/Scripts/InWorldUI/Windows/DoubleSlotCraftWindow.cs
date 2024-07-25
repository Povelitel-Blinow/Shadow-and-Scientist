using CraftNamespace;
using MaterialNamespace;
using SlotNamespace;
using System.Collections;
using UnityEngine;

namespace WindowNamespace
{
    public class DoubleSlotCraftWindow : CraftBlockWindow
    {
        [Header("Slots")]
        [SerializeField] private CraftSlot _inputSlot1;
        [SerializeField] private CraftSlot _inputSlot2;
        [SerializeField] private OutPutSlot _outputSlot;

        [Header("View")]
        [SerializeField] private LineTimer _lineTimer;

        [Header("Crafting")]
        [SerializeField] private Recipe[] _recipes;

        private void Awake()
        {
            _inputSlot1.OnPut += TryMake;
            _inputSlot2.OnPut += TryMake;
        }

        public void TryMake()
        {
            if (_inputSlot1.Material == null) return;
            if (_inputSlot2.Material == null) return;

            foreach(Recipe r in _recipes)
            {
                if (_inputSlot1.Material.MaterialType != r.Material1) continue;
                if (_inputSlot2.Material.MaterialType != r.Material2) continue;

                StartCoroutine(Crafting(r.CraftTime, r.Result));
            }
        }

        private IEnumerator Crafting(float time, InSlotPutable result)
        {
            float timer = 0;

            _animator?.SetIsWorking(true);

            while(timer < time)
            {
                timer += Time.deltaTime;
                _lineTimer.SetLine(timer/time);

                if (CheckMaterials() == false)
                {
                    FinishCrafting();
                    yield break;
                }

                yield return new WaitForEndOfFrame();
            }

            _inputSlot1.VoidSlot();
            _inputSlot2.VoidSlot();
            _outputSlot.PutInObject(result);

            FinishCrafting();
        }

        private bool CheckMaterials()
        {
            if (_inputSlot1.Material == null) return false;
            if (_inputSlot2.Material == null) return false;

            return true;
        }

        private void FinishCrafting()
        {
            _lineTimer.SetLine(0);
            _animator?.SetIsWorking(false);
        }

        [System.Serializable]
        private struct Recipe
        {
            public MaterialType Material1;
            public MaterialType Material2;

            public InSlotPutable Result;

            public float CraftTime;
        }
    }
}