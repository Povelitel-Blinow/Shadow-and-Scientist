using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerNamespace
{
    public class PlayerFear : MonoBehaviour
    {
        [SerializeField] private FearPanel _panel;

        [Header("Settings")]
        [SerializeField] private float _maxFear;
        [SerializeField] private float _minFearDistance;
        [SerializeField] private float _maxFearDistance;

        private List<IScary> _scaries = new List<IScary>();

        private void Update()
        {
            if (_scaries.Count == 0) return;

            float fear = 0;

            foreach(var scary in _scaries)
            {
                float distance = (scary.GetPosition() - transform.position).magnitude;

                fear += scary.GetScareness() * GetFearRatio(distance);
            }
            SetFear(fear);
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

        private void SetFear(float fear)
        {
            float fearRatio = Mathf.Lerp(0, 0.9f, fear / _maxFear);

            _panel.SetFear(fearRatio);
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
