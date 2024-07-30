using UnityEngine;

namespace EnemyNamespace
{
    [RequireComponent(typeof(EnemyLook))]
    [RequireComponent(typeof(EnemyMove))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyLook _look;
        [SerializeField] private EnemyMove _move;

        private void Update()
        {
            _look.UpdateLook();
            _move.UpdateMove();

            if (_look.State != EnemyLookStates.Looking)
            {
                Vector2 pos = _look.GetMovePos();

                _move.MoveTo(pos);
                return;
            }
        }

        private void OnValidate()
        {
            _look ??= GetComponent<EnemyLook>();
            _move ??= GetComponent<EnemyMove>();
        }
    }
}