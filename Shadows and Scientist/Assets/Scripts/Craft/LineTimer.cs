using DG.Tweening;
using UnityEngine;

namespace CraftNamespace
{
    public class LineTimer : MonoBehaviour
    {
        [SerializeField] private Transform _line;

        [Header("Settings")]
        [SerializeField] private float _followTime;

        public void SetLine(float ratio)
        {
            _line.transform.DOScale(ratio, _followTime);
        }

        private void OnDestroy()
        {
            _line.transform.DOKill();
        }
    }
}