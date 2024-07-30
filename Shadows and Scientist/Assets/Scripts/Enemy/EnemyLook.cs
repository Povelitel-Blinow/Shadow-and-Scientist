using UnityEngine;

namespace EnemyNamespace
{
    public class EnemyLook : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private Transform _raycastPoint;
        [SerializeField] private float _lookDistance;
        [SerializeField] private float _rotSpeed;

        [SerializeField] private float _followTimeSinceLastSeen;

        private Spotable _spotable;
        private Vector2 _lastSeenPos;
        private float _timeSinceLastSeen = 0;

        public bool SeeSpotable() => _spotable != null;

        public Vector2 TrySawSpotable()
        {
            if( _spotable != null)
            {
                LookAtPlayer();
            }
            else
            {
                TryFindPlayer();
            }

            if (_spotable != null)
                return _spotable.GetPosition();

            return _lastSeenPos;
        }

        private void LookAtPlayer()
        {
            Vector2 direction = _spotable.transform.position - _raycastPoint.position;

            Debug.DrawRay(_raycastPoint.position, direction, Color.black, _lookDistance);

            RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position,
                direction, _lookDistance, _mask);

            if(hit.collider != null)
            {
                if(hit.collider.TryGetComponent(out Spotable spot))
                {
                    _lastSeenPos = spot.GetPosition();
                    return;
                }
            }

            if(_timeSinceLastSeen < _followTimeSinceLastSeen)
            {
                _timeSinceLastSeen += Time.deltaTime;
                _lastSeenPos = _spotable.GetPosition();
            }
            else
            {
                _timeSinceLastSeen = 0;
                _spotable = null;
            }
        }

        private void TryFindPlayer()
        {
            RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position,
                _raycastPoint.transform.right, _lookDistance, _mask);

            Debug.DrawRay(_raycastPoint.position, _raycastPoint.transform.right, Color.red, _lookDistance);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out Spotable spot))
                {
                    _spotable = spot;
                    _lastSeenPos = _spotable.GetPosition();
                    return;
                }
            }

            RotateView();

            return;
        }

        private void RotateView()
        {
            _raycastPoint.rotation *= Quaternion.Euler(0, 0, _rotSpeed * Time.deltaTime);
        }
    }
}
