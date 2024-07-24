using GadgetNamespace;
using UnityEngine;

namespace WindowNamespace
{
    public class EnergySeekerButton : MonoBehaviour, IClickable
    {
        [SerializeField] private EnergySeeker _energySeeker;

        public void Click()
        {
            Debug.Log(1);
            _energySeeker.Spawn();
        }
    }
}