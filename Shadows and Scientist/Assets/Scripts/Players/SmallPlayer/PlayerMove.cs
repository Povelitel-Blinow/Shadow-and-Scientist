using UnityEngine;
using WorldNamespace;

namespace SmallPlayerNamespace
{
    public class PlayerMove : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed;

        [Header("Collisions")]
        [SerializeField] private Transform _raycastPoint;
        [SerializeField] private LayerMask _wallLayerMask;
        [SerializeField] private float _colideDistance;

        [Header("Sound")]
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private float _stepDistance;

        private float _distance;

        public void Move(Vector2 input)
        {
            // I hate Rigidbody :)

            Vector2 movement = input.normalized * _speed * Time.deltaTime;

            float distance = movement.magnitude + _colideDistance * input.magnitude;

            if (Physics2D.Raycast(_raycastPoint.position, input, distance, _wallLayerMask))
            {
                movement = Vector2.zero;
            }

            _distance += movement.magnitude;

            if(_distance >= _stepDistance)
            {
                _distance = 0;
                _soundManager.PlaySound();
            }

            transform.position += (Vector3)movement;
        }
    }
}