using GadgetNamespace;
using UnityEngine;

namespace InWorldUINamespace
{
    public class EnergySeekerButton : Button
    {
        [SerializeField] private EnergySeeker _energySeeker;

        public override void OnClick()
        {
            _energySeeker.Spawn();
        }
    }
}