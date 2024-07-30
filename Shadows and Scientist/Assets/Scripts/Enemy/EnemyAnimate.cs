using UnityEngine;

namespace EnemyNamespace
{
    public class EnemyAnimate : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _body;

        private const string IsRunning = "IsRunning";

        public void SetIsRunning(bool isRunning)
        {
            _animator.SetBool(IsRunning, isRunning);
        }

        public void SetMoveRight(bool moveRight)
        {
            int scaleX = moveRight ? 1 : -1;
            _body.transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }
}