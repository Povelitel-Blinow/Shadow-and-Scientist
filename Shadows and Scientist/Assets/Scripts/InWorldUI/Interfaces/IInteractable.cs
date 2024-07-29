using UnityEngine;

namespace CraftNamespace
{
    public interface IInteractable
    {
        public void Interact();
        public virtual void Deinteract() { }
        public Vector3 GetPosition();
    }
}