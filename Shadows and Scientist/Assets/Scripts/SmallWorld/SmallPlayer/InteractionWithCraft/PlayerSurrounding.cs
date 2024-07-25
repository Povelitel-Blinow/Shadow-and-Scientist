using CraftNamespace;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SmallPlayerNamespace
{
    public class PlayerSurrounding : MonoBehaviour
    {
        [SerializeField] private GameObject _tipUI;

        private List<CraftingBlock> _blocks = new List<CraftingBlock>();

        public void RegisterCraftBlock(CraftingBlock block)
        {
            if (_blocks.Contains(block)) return;

            _blocks.Add(block);
            ShowTip();
        }

        private void ShowTip()
        {
            if(_blocks.Count == 0) 
                _tipUI.SetActive(false);
            else
                _tipUI.SetActive(true);
        }

        public void UnregisterCraftBlock(CraftingBlock block)
        {
            if (_blocks.Contains(block) == false) return;

            _blocks.Remove(block);
            ShowTip();
        }

        public void TryInteract()
        {
            if(_blocks.Count == 0) return;

            float distance = (_blocks.First().transform.position - transform.position).magnitude;
            CraftingBlock closestblock = _blocks.First();

            foreach (var b in _blocks)
            {
                float currentDist = (b.transform.position - transform.position).magnitude;

                if (distance > currentDist)
                {
                    distance = currentDist;
                    closestblock = b;
                }
            }

            closestblock.Interact();
        }
    }
}