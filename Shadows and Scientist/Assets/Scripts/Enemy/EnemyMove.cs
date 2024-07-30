using UnityEngine;
using UnityEngine.AI;

namespace EnemyNamespace
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        [SerializeField] private EnemyAnimate _animate;

        private Vector3 _lastPos;

        public void UpdateMove()
        {
            if (_lastPos != transform.position)
            {
                _animate.SetIsRunning(true);
                _animate.SetMoveRight(transform.position.x - _lastPos.x >= 0);
            }
            else
                _animate.SetIsRunning(false);

            _lastPos = transform.position;
        }

        public void MoveTo(Vector2 target)
        {
            _lastPos = transform.position;
            _agent.SetDestination(target);
        }
    }
}