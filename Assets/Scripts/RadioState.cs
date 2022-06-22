using UnityEngine;

public sealed class RadioState : MonoBehaviour
{
    public static bool CanWork()
    {
        if(Antenna.IsConnect && Wire.IsConnect && !Pressure.IsActive)
        {
            return true;
        }
        return CantWork();
    }
    public static bool CantWork()
    {
        return false;
    }
}
