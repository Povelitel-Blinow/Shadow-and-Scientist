using UnityEngine;

namespace InWorldUINamespace
{
    public interface IMoveable
    {
        public void PickUp(Vector3 position);

        public void Move(Vector3 position);

        public void LayDown();
    }
}