using UnityEngine;

namespace CraftNamespace
{
    public interface IInteractable
    {
        public void Interact();

        public Vector3 GetPosition();
    }
}