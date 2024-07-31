using CraftNamespace;
using System.Collections;
using UnityEngine;
using MaterialNamespace;
using SlotNamespace;
using PlayerNamespace;

namespace GadgetNamespace
{
    public class Materializer : MonoBehaviour
    {
        [SerializeField] private MaterializerSlider _slider;
        [SerializeField] private LineTimer _lineTimer;
        [SerializeField] private float _workTime;

        [Header("Slots")]
        [SerializeField] private CraftSlot _inputSlot;
        [SerializeField] private OutPutSlot _outputSlot;

        [Header("Metarials")]
        [SerializeField] private MaterialsList[] _materials;

        private void OnEnable()
        {
            PlayerTips.Instance.ShowMaterializerTip();
        }

        public void TryMaterialize()
        {
            MaterialType material = _slider.GetMaterialType();

            StartCoroutine(Materializing(material));
        }

        private IEnumerator Materializing(MaterialType type)
        {
            if (_outputSlot.InSlot != null)
                yield break;

            if (_inputSlot.InSlot == null)
                yield break;

            if (_inputSlot.Material == null)
                yield break;

            if (_inputSlot.Material.MaterialType != MaterialType.Energy)
                yield break;
                
            float timer = 0f;
            while (timer < _workTime)
            {
                if(_inputSlot.InSlot == null)
                {
                    _lineTimer.SetLine(0);
                    yield break;
                }

                timer += Time.deltaTime;
                _lineTimer.SetLine(timer / _workTime);
                yield return new WaitForEndOfFrame();
            }

            _lineTimer.SetLine(0);

            TheMaterial spawnMaterial = _materials[0].Material;

            foreach(var m in _materials)
            {
                if(m.Type == type)
                {
                    spawnMaterial = m.Material;
                    break;
                }
            }

            _inputSlot.VoidSlot();
            _outputSlot.PutInObject(spawnMaterial.InSlotPutable);
        }


        [System.Serializable]
        private struct MaterialsList
        {
            //How to make a readonly field appear in the inspector?
            public MaterialType Type;
            public TheMaterial Material;
        }
    }
}