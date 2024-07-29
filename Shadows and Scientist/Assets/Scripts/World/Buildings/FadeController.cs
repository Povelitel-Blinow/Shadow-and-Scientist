using System.Collections;
using UnityEngine;

namespace BuildingNameSpace
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FadeController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private float _duration;

        private Color _startColor;

        void Start()
        {
            _startColor = _spriteRenderer.color;
        }

        public void FadeOut()
        {
            StopAllCoroutines();
            StartCoroutine(FadingOut());
        }

        private IEnumerator FadingOut()
        {
            float startA = _spriteRenderer.color.a;
            float time = 0;
            while (time < _duration)
            {
                float alpha = Mathf.Lerp(startA, 0f, time / _duration);
                Color newColor = new Color(_startColor.r, _startColor.g, _startColor.b, alpha);
                _spriteRenderer.color = newColor;
                time += Time.deltaTime;
                yield return null;
            }

            _spriteRenderer.color = new Color(_startColor.r, _startColor.g, _startColor.b, 0f);
        }

        public void FadeIn()
        {
            StopAllCoroutines();
            StartCoroutine(FadingIn());
        }

        private IEnumerator FadingIn()
        {
            float startA = _spriteRenderer.color.a;

            float time = 0;
            while (time < _duration)
            {
                float alpha = Mathf.Lerp(startA, 1, time / _duration);
                Color newColor = new Color(_startColor.r, _startColor.g, _startColor.b, alpha);
                _spriteRenderer.color = newColor;
                time += Time.deltaTime;
                yield return null;
            }

            _spriteRenderer.color = new Color(_startColor.r, _startColor.g, _startColor.b, 1f);
        }

        private void OnValidate()
        {
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
        }
    }
}