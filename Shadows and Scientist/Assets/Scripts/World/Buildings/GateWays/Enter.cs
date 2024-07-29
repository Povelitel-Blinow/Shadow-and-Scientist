namespace WorldNamespace
{
    public class Enter : GateWay
    {
        protected override void OnInteract()
        {
            PlayerManager.Instance.GetInBuilding(_building);
            _building.HideRoof();
        }
    }
}