using SmallPlayerNamespace;
using System;
using UnityEngine;

namespace EnemyNamespace
{
    public class PatrollingEnemy : MonoBehaviour, IScary
    {
        [SerializeField] private EnemyLook _look;
        [SerializeField] private EnemyMove _move;

        [Header("Settings")]
        [SerializeField] private float _fearfulness;

        public Action<Vector3> OnSpotted;

        public bool Spotted { get; private set; } = false;

        private void OnEnable()
        {
            _look.OnSpot += Spot;
            _look.OnDespot += Despot;
        }

        public void Init()
        {
            transform.parent = null;
            _look.OnSpot += Spot;
            _look.OnDespot += Despot;
        }

        private void Spot(Fearable fearable)
        {
            fearable.RegisterScary(this);
            OnSpotted?.Invoke(fearable.transform.position);
        }

        private void Despot(Fearable fearable)
        {
            fearable.DeregisterScary(this);
        }

        public void UpdateEnemy()
        {
            _move.UpdateMove();
            _look.UpdateLook();
            TryFindSpotable();
        }

        public void TryFindSpotable()
        {
            if (_look.State != EnemyLookStates.Looking)
            {
                Vector2 pos = _look.GetMovePos();
                OnSpotted?.Invoke(pos);
                Spotted = true;
            }
            else
            {
                Spotted = false;
            }
        }

        public void MoveEnemy(Vector2 pos)
        {
            _move.MoveTo(pos);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public float GetScareness()
        {
            return _fearfulness;
        }

        private void OnDisable()
        {
            _look.OnSpot -= Spot;
            _look.OnDespot -= Despot;
        }
    }
}