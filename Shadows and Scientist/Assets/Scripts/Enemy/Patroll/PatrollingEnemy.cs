using System;
using UnityEngine;

namespace EnemyNamespace
{
    public class PatrollingEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyLook _look;
        [SerializeField] private EnemyMove _move;

        public Action<Vector3> OnSpotted;

        public bool Spotted { get; private set; } = false;

        public void Init()
        {
            transform.parent = null;
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
    }
}