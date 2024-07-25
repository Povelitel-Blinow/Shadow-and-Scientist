using UnityEngine;

namespace CraftNamespace
{
    [RequireComponent(typeof(Animator))]
    public class CraftBlockAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string IsWorking = "IsWorking";

        public void SetIsWorking(bool isWorking)
        {
            _animator.SetBool(IsWorking, isWorking);
        }

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }
    }
}