using CraftNamespace;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SmallPlayerNamespace
{
    public class PlayerSurrounding : MonoBehaviour
    {
        [SerializeField] private GameObject _tipUI;

        private List<IInteractable> _blocks = new List<IInteractable>();

        public void RegisterCraftBlock(IInteractable block)
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

        public void UnregisterCraftBlock(IInteractable block)
        {
            if (_blocks.Contains(block) == false) return;

            block.Deinteract();
            _blocks.Remove(block);
            ShowTip();
        }

        public void TryInteract()
        {
            if(_blocks.Count == 0) return;

            float distance = (_blocks.First().GetPosition() - transform.position).magnitude;
            IInteractable closestblock = _blocks.First();

            foreach (var b in _blocks)
            {
                float currentDist = (b.GetPosition() - transform.position).magnitude;

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