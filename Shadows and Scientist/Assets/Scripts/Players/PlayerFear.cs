using SmallPlayerNamespace;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerFear : MonoBehaviour
    {
        [SerializeField] private FearPanel _fearPanel;

        [Header("Settings")]
        [SerializeField] private float _maxFear;
        [SerializeField] private float _minFearDistance;
        [SerializeField] private float _maxFearDistance;

        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        [SerializeField] private float _healthRegenerationSpeed;

        private List<IScary> _scaries = new List<IScary>();

        private void Update()
        {
            Debug.Log(_scaries.Count);
            if (_scaries.Count == 0) 
            {
                Regenerate();
            }
            else
            {
                UpdateFear();
            }

            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            float ratio = (_maxHealth - _currentHealth) / _maxHealth;
            SetHealth(ratio);
        }

        private void Regenerate()
        {
            _currentHealth += _healthRegenerationSpeed * Time.deltaTime;
        }

        private void UpdateFear()
        {
            float fear = 0;

            foreach (var scary in _scaries)
            {
                float distance = (scary.GetPosition() - SmallPlayer.Instance.transform.position).magnitude;

                fear += scary.GetScareness() * GetFearRatio(distance);
            }

            Debug.Log(fear);

            _currentHealth -= fear * Time.deltaTime;
        }

        private float GetFearRatio(float distance)
        {
            if (distance <= _maxFearDistance)
            {
                return 1f;
            }
            else if (distance >= _minFearDistance)
            {
                return 0f;
            }
            else
            {
                float t = (_minFearDistance - distance) / (_minFearDistance - _maxFearDistance);
                return Mathf.Clamp01(t);
            }
        }

        private void SetHealth(float ratio)
        {
            _fearPanel.SetFear(ratio);
        }

        public void RegisterScary(IScary scary)
        {
            if (_scaries.Contains(scary)) return;
            _scaries.Add(scary);
        }
        
        public void DeregisterScary(IScary scary)
        {
            if(_scaries.Contains(scary) == false) return;
            _scaries.Remove(scary);
        }
    }
}
