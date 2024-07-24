using UnityEngine;

namespace InWorldUINamespace
{
    public class InWorldUI : MonoBehaviour
    {

    }

    /// <summary>
    /// <b>WARNING</b> <br></br> If the Layer Number is >10
    /// the object will be placed <b>outside</b> the camera
    /// </summary>

    public enum RaycastSortingLayer
    {
        Object = 0,
        SlidingButton = 1,
        Window = 2,
        Button = 3,
        Material = 4
    }
}

