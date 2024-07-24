using UnityEngine;

namespace InWorldUINamespace
{
    public class Moveable : MonoBehaviour, IMoveable
    {
        [Header("Moveable params:")]
        [SerializeField] private RaycastSortingLayer _sortingLayer;

        private Vector3 _startOffset;

        public void PickUp(Vector3 position)
        {
            _startOffset = position - transform.position;

            OnPickUp();
        }

        protected virtual void OnPickUp() { }

        public void Move(Vector3 position)
        {
            Vector3 movement = position - _startOffset;

            float newX = Mathf.Clamp(movement.x,
                Map.Instance.HorizontalBorders.x,
                Map.Instance.HorizontalBorders.y);

            float newY = Mathf.Clamp(movement.y,
                Map.Instance.VerticalBorders.x,
                Map.Instance.VerticalBorders.y);

            transform.position = new Vector3(newX, newY, 0) + GetSortingOffset();

            OnMove();
        }

        protected virtual void OnMove() { }

        /// <summary>
        /// Returns Z offset which is used to sort moveable object by raycast layers 
        /// (is not the same as "Physics Layers Sorting")
        /// </summary>
        /// <returns>Vector3.zero with Z offset</returns>
        protected Vector3 GetSortingOffset() => Vector3.forward * -(int)_sortingLayer;

        public virtual void LayDown()
        {
            _startOffset = Vector3.zero;
            OnLayDown();
        }

        protected virtual void OnLayDown() { }
    }
}