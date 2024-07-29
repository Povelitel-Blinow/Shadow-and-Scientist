using UnityEngine;

namespace SmallPlayerNamespace
{
    public class PlayerAnimate : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string IsWalking = "IsWalking";
        private const string IsRunning = "IsRunning";

        public void SetIsWalking(bool isWalking)
        {
            _animator.SetBool(IsWalking, isWalking);
        }
    }
}