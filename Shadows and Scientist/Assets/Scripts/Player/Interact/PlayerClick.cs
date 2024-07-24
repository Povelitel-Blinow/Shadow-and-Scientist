using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerClick
    {
        public void TryClick()
        {
            IClickable clickable = PlayerRaycast.Instance.RayCast<IClickable>();

            if (clickable == null) return;

            Debug.Log(2);

            clickable.Click();
        }
    }
}