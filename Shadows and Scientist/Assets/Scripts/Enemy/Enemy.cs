using SmallPlayerNamespace;
using UnityEngine;

namespace EnemyNamespace
{
    [RequireComponent(typeof(EnemyLook))]
    [RequireComponent(typeof(EnemyMove))]
    public class Enemy : MonoBehaviour, IScary
    {
        [SerializeField] private EnemyLook _look;
        [SerializeField] private EnemyMove _move;

        [Header("Settings")]
        [SerializeField] private float _fearfulness;

        private void OnEnable()
        {
            _look.OnSpot += Spot;
            _look.OnDespot += Despot;
        }

        private void Start()
        {
            _look.OnSpot += Spot;
            _look.OnDespot += Despot;
        }

        private void Spot(Fearable fearable)
        {
            fearable.RegisterScary(this);
        }

        private void Despot(Fearable fearable)
        {
            fearable.DeregisterScary(this);
        }

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

        private void OnValidate()
        {
            _look ??= GetComponent<EnemyLook>();
            _move ??= GetComponent<EnemyMove>();
        }
    }
}