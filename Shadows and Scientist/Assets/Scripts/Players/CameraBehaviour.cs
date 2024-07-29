using UnityEngine;

namespace PlayerNamespace
{
    public class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _target;

        public void MoveTo(Transform target)
        {
            _target = target;
            Move();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_target == null) return;
            
            //parent object have -10 Z offset
            transform.position += (_target.transform.position - transform.position) * _speed * Time.deltaTime;
        }
    }
}