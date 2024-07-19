using UnityEngine;
using DG.Tweening;

namespace ObjectsNamespace
{
    public class Moveable : MonoBehaviour, ISelectable
    {
        [SerializeField] private RaycastSortingLayer _sortingLayer;

        private float _scaleRatio = 1.1f; 
        private float _scaleTime = 0.3f; 

        private Vector3 _startOffset;

        public virtual void PickUp(Vector3 position)
        {
            _startOffset = position - transform.position;
        }

        public virtual void Move(Vector3 position)
        {
            Vector3 movement = position - _startOffset;

            float newX = Mathf.Clamp(movement.x,
                Map.Instance.HorizontalBorders.x,
                Map.Instance.HorizontalBorders.y);

            float newY = Mathf.Clamp(movement.y,
                Map.Instance.VerticalBorders.x,
                Map.Instance.VerticalBorders.y);
            

            transform.position = new Vector3(newX, newY, (int)_sortingLayer);
        }

        public virtual void LayDown()
        {
            _startOffset = Vector3.zero;
        }

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
            Material = -1,
            Objects
        }
    }
}