using UnityEngine;

namespace SmallPlayerNamespace
{
    public class PlayerVisualBody : MonoBehaviour
    {
        [SerializeField] private Transform _visualBody;

        private bool _currentLookRight = true;

        public void ChangeDirection(Vector2 input)
        {
            if (input.x == 0) return;

            bool lookRight = input.x >= 0;

            if (lookRight == _currentLookRight) return;

            //I know about SpriteRenderer.Flip.X

            if(lookRight) 
                transform.localScale = Vector3.one;
            else
                transform.localScale = new Vector3(-1, 1, 1);

            _currentLookRight = lookRight;
        }
    }
}
