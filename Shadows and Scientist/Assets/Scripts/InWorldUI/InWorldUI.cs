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
        Wall = -20,
        Materializer = -19,
        EnergySeeker = -18,
        DefaultCraftWindow = -17,
        BackPack = -16,
        Window1 = -15,
        Window2 = -14,
        Window3 = -13,
        Window4 = -12,
        Window5 = -11,
        Window6 = -10,

        Tip1 = -9,
        Tip2 = -8,
        Tip3 = -7,
        Tip4 = -6,
        Window7 = -5,

        Tip5 = -4,

        Object = 0,
        SlidingButton = 1,
        Window = 2,
        Button = 3,
        Material = 4,
    }
}

