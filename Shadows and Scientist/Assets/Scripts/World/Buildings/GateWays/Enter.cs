using EnemyNamespace;
using UnityEngine;

namespace WorldNamespace
{
    public class Enter : GateWay
    {
        protected override void OnInteract()
        {
            PlayerManager.Instance.GetInBuilding(_building);
            _building?.HideRoof();
        }

        protected override void OnBreakIn(Enemy enemy)
        {
            Instantiate(enemy, OutPos, Quaternion.identity);
        }
    }
}