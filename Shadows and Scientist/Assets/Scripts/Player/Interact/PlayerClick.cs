using UnityEngine;
using WindowNamespace;

namespace PlayerNamespace
{
    public class PlayerClick
    {
        public void TryClick()
        {
            IClickable clickable = PlayerRaycast.Instance.RayCast<IClickable>();

            if (clickable == null) return;
            
            Debug.Log("Clicked");
            clickable.Click();
        }
    }
}