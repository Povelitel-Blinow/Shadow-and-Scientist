using UnityEngine;
using UnityEngine.AI;
using WorldNamespace;

namespace EnemyNamespace
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        [SerializeField] private EnemyAnimate _animate;

        [Header("Sound")]
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private float _stepDistance;

        private float _distance;

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

            _distance += (transform.position - _lastPos).magnitude;

            if(_distance >= _stepDistance) 
            {
                _distance = 0;
                _soundManager.PlaySound();
            }

            _lastPos = transform.position;
        }

        public void MoveTo(Vector2 target)
        {
            _lastPos = transform.position;
            _agent.SetDestination(target);
        }
    }
}