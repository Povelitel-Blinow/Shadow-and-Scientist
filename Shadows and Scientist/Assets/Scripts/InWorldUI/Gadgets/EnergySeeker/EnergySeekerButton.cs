using GadgetNamespace;
using UnityEngine;

namespace InWorldUINamespace
{
    public class EnergySeekerButton : Button
    {
        [SerializeField] private EnergySeeker _energySeeker;

        protected override void OnClick()
        {
            _energySeeker.Spawn();
        }
    }
}