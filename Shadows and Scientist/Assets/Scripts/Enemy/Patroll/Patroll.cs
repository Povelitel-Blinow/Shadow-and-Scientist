using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyNamespace
{
    public class Patroll : MonoBehaviour
    {
        [Header("Navigation")]
        [SerializeField] private NavMeshAgent _agent;

        [Header("Other")]
        [SerializeField] private Transform[] _moveFormation;
        [SerializeField] private Transform[] _attackFormation;
        [SerializeField] private PatrollingEnemy[] _enemies;

        [Header("Settings")]
        [SerializeField] private float _waitTime;

        private bool _spotted = false;
        private Transform _targetPatrollPoint;

        private void OnEnable()
        {
            foreach (var e in _enemies)
            {
                e.OnSpotted += Spot;
            }
        }

        private void Start()
        {
            foreach(var e in _enemies)
            {
                e.OnSpotted += Spot;
                e.Init();
            }
        }

        private void Update()
        {
            if(CheckEnemies() == false)
                MoveToPatrollPoint();

            foreach (var e in _enemies)
            {
                e.UpdateEnemy();
            }

            for(int i = 0; i < _enemies.Length; i++)
            {
                Transform t = _spotted? _attackFormation[i] : _moveFormation[i];
                _enemies[i].MoveEnemy(t.position);
            }
        }

        private bool CheckEnemies()
        {
            foreach(var e in _enemies)
            {
                if(e.Spotted)
                    return true;
            }
            return false;
        }

        private void MoveToPatrollPoint()
        {
            if(_targetPatrollPoint == null)
                _targetPatrollPoint = PatrollingMap.Instance.GetPatrollPoint();

            if ((transform.position - _targetPatrollPoint.position).magnitude
                <= _agent.stoppingDistance)
                StartCoroutine(Waiting());

            _agent.SetDestination(_targetPatrollPoint.position);
        }

        private IEnumerator Waiting()
        {
            float timer = 0;
            while(timer < _waitTime)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            _targetPatrollPoint = PatrollingMap.Instance.GetPatrollPoint();
        }

        private void Spot(Vector3 pos)
        {
            StopAllCoroutines();
            _spotted = true;
            _agent.SetDestination(pos);
        }

        private void OnDisable()
        {
            foreach (var e in _enemies)
            {
                e.OnSpotted -= Spot;
            }
        }
    }
}
