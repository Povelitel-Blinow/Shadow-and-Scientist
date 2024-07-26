using System.Collections;
using UnityEngine;

namespace CraftNamespace
{
    public class CraftBlockAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        [SerializeField] private Sprite _inactiveSprite;
        [SerializeField] private Sprite[] _workingSprite;

        [SerializeField] private float _spriteChangeDelay;

        [Header("LineTimer")]
        [SerializeField] private LineTimer _timer;

        private bool _isWorking;

        public void StopAnimating()
        {
            _timer.SetLine(0);
            _isWorking = false;
            StopAllCoroutines();
            _renderer.sprite = _inactiveSprite;
        }

        public void SetLine(float ratio)
        {
            _timer.SetLine(ratio);
        }

        public void SetIsWorking(bool isWorking)
        {
            _isWorking = isWorking;

            if(isWorking == false)
                _renderer.sprite = _inactiveSprite;

            StartCoroutine(Working());
        }

        private IEnumerator Working()
        {
            int index = 0;
            while (_isWorking)
            {
                index++;
                if(index >= _workingSprite.Length)
                    index = 0;

                _renderer.sprite = _workingSprite[index];

                yield return new WaitForSeconds(_spriteChangeDelay);
            }
            _timer.SetLine(0);
        }
    }
}