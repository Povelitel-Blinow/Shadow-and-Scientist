using UnityEngine;
using UnityEngine.AI;

namespace EnemyNamespace
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        public void MoveTo(Vector2 target)
        {
            _agent.SetDestination(target);
        }
    }
}