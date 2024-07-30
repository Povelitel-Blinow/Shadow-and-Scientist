using UnityEngine;

namespace WorldNamespace
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private AudioClip[] _sounds;

        public void PlaySound()
        {
            AudioClip sound = _sounds[Random.Range(0, _sounds.Length)];

            _audioSource.PlayOneShot(sound);
        }

        public void StopSound()
        {
            _audioSource.Stop();
        }

        private void OnValidate()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }
    }
}