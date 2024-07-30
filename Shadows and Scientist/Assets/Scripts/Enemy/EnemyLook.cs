using SmallPlayerNamespace;
using System;
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

        public EnemyLookStates State { get; private set; } = EnemyLookStates.Looking;

        public Action<Fearable> OnSpot;
        public Action<Fearable> OnDespot;

        public Vector2 GetMovePos()
        {
            if( State == EnemyLookStates.Aimming)
                return _spotable.GetPosition();
            if(State == EnemyLookStates.KnowLastPosition)
                return _lastSeenPos;

            return Vector2.zero;
        }

        public void UpdateLook()
        {
            if (State == EnemyLookStates.Aimming)
                LookAtPlayer();
            else
                LookForPlayer();
        }

        private void LookForPlayer()
        {
            RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position,
                _raycastPoint.transform.right, _lookDistance, _mask);

            Debug.DrawRay(_raycastPoint.position, _raycastPoint.transform.right, Color.red, _lookDistance);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out Spotable spot))
                {
                    _spotable = spot;
                    if(_spotable.TryGetComponent(out Fearable fearable))
                    {
                        OnSpot?.Invoke(fearable);
                    }

                    _lastSeenPos = _spotable.GetPosition();
                    State = EnemyLookStates.Aimming;
                    return;
                }
            }

            RotateView();
            State = EnemyLookStates.Looking;
            return;
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
                    State = EnemyLookStates.Aimming;
                    return;
                }
            }

            if(_timeSinceLastSeen < _followTimeSinceLastSeen)
            {
                _timeSinceLastSeen += Time.deltaTime;
                _lastSeenPos = _spotable.GetPosition();
                State = EnemyLookStates.Aimming;
            }
            else
            {
                _timeSinceLastSeen = 0;
                if (_spotable.TryGetComponent(out Fearable fearable))
                {
                    OnDespot?.Invoke(fearable);
                }
                _spotable = null;
                State = EnemyLookStates.KnowLastPosition;
            }
        }

        private void RotateView()
        {
            _raycastPoint.rotation *= Quaternion.Euler(0, 0, _rotSpeed * Time.deltaTime);
        }
    }

    public enum EnemyLookStates
    {
        Looking,
        Aimming,
        KnowLastPosition
    }
}
