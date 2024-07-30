using UnityEngine;

namespace EnemyNamespace
{
    public class PatrollingMap : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrollPoints;

        public static PatrollingMap Instance { get; private set; }

        private void Start()
        {
            if(Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        public Transform GetPatrollPoint()
        {
            int rand = Random.Range(0, _patrollPoints.Length);

            return _patrollPoints[rand];
        }
    }
}