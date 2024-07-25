using CraftNamespace;
using UnityEngine;

namespace WindowNamespace
{
    public abstract class CraftBlockWindow : MonoBehaviour
    {
        protected CraftBlockAnimator _animator;
        public void Init(CraftBlockAnimator animator)
        {
            _animator = animator;
            gameObject.SetActive(false);
        }

        public void ShowUp()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}