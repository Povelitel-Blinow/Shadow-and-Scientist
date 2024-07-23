using UnityEngine;
using DG.Tweening;

namespace ObjectsNamespace
{
    public class Moveable : MonoBehaviour, ISelectable
    {
        [Header("Moveable params:")]
        [SerializeField] private RaycastSortingLayer _sortingLayer;

        private float _scaleRatio = 1.05f; 
        private float _scaleTime = 0.2f; 

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

        public void Select()
        {
            transform.DOScale(new Vector3(_scaleRatio, _scaleRatio, 1), _scaleTime);
        }

        public void Deselect()
        {
            //Smb might call it stupidity. I call it a solution :D
            //(It actually fixes a bug)
            if (_startOffset != Vector3.zero) return;

            transform.DOScale(1, _scaleTime);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        private enum RaycastSortingLayer
        {
            Object = 0,
            Window = 1,
            Material = 2
        }
    }
}