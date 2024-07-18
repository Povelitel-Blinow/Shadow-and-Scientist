using UnityEngine;
using DG.Tweening;

namespace ObjectsNamespace
{
    public class Moveable : MonoBehaviour, ISelectable
    {
        [Header("Select Scaling")]
        [SerializeField] private float _scaleRatio; 
        [SerializeField] private float _scaleTime; 

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
            

            transform.position = new Vector3(newX, newY, 0);
        }

        public virtual void LayDown()
        {
            _startOffset = Vector3.zero;
        }

        public void Select()
        {
            transform.DOScale(_scaleRatio, _scaleTime);
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
    }
}