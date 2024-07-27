using UnityEngine;

namespace InWorldUINamespace
{
    public interface ITipable
    {
        public TipableObjectNames GetTipableType();
    }

    public enum TipableObjectNames
    {
        Energy,
        Metall,
        Gold,
        Glass,
        Capsule,
        LightCapsule,
        Steel,
        Coin,
        Oven,
        Light,
        Workbench,
        CoinMachine,
        LightGenerator,
        Lathe,
        AccumulatingMachine,
        Torch
    }
}