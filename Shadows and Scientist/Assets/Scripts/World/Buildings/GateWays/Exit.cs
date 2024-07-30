using UnityEngine;

namespace WorldNamespace
{
    public class Exit : GateWay
    {
        protected override void OnInteract()
        {
            PlayerManager.Instance.GetOutBuilding();
            _building?.ShowRoof();
        }
    }
}