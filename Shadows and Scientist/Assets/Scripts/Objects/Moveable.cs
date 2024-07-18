using UnityEngine;

namespace GadgetsNamespace
{
    public class Moveable : MonoBehaviour
    {
        private Vector3 _startOffset;

        public virtual void PickUp(Vector3 position)
        {
            _startOffset = position - transform.position;
        }

        public virtual void Move(Vector3 position)
        {
            Vector3 movement = position - _startOffset;

            /*
            float newX = Mathf.Clamp(movement.x,
                Map.Instance.HorizontalBorders.x,
                Map.Instance.HorizontalBorders.y);

            float newY = Mathf.Clamp(movement.y,
                Map.Instance.VerticalBorders.x,
                Map.Instance.VerticalBorders.y);
            */

            transform.position = movement;
        }

        public virtual void LayDown()
        {
            _startOffset = Vector3.zero;
        }
    }
}