using SmallPlayerNamespace;
using System;
using UnityEngine;

namespace CraftNamespace
{
    public class CraftingBlockTrigger : MonoBehaviour, IInteractable
    {
        public Action OnInteract;
        public Action OnDeinteract;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void Interact()
        {
            OnInteract?.Invoke();
        }

        public void Deinteract()
        {
            OnDeinteract?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out PlayerSurrounding player))
            {
                player.RegisterCraftBlock(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerSurrounding player))
            {
                player.UnregisterCraftBlock(this);
            }
        }
    }
}