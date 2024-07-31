using UnityEngine;

namespace PlayerNamespace
{
    public class Soundtrack : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Settings")]
        [SerializeField] private float _maxVolume;
        [SerializeField] private float _increaseSpeed;

        private float _currentRatio = 0;

        public void SetVolume(float ratio)
        {
            if(_currentRatio <= 0.01f && ratio > 0)
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(_audioClip);
            }

            ratio = Mathf.Clamp01(ratio);

            _currentRatio += Mathf.Lerp(0, ratio-_currentRatio, Time.deltaTime * _increaseSpeed);

            _currentRatio = Mathf.Clamp01(_currentRatio);

            _audioSource.volume = Mathf.Lerp(0, _maxVolume, _currentRatio);
        }
    }
}