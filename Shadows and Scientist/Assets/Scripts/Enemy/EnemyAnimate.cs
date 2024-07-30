using UnityEngine;

namespace EnemyNamespace
{
    public class EnemyAnimate : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string IsRunning = "IsRunning";

        public void SetIsRunning(bool isRunning)
        {
            _animator.SetBool(IsRunning, isRunning);
        }
    }
}