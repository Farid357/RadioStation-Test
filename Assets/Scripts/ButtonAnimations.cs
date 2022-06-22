using UnityEngine;

public sealed class ButtonAnimations : MonoBehaviour
{


    public static void PlayBack(Transform broadcast)
    {
        broadcast.rotation  = Quaternion.Euler(broadcast.rotation.x, broadcast.rotation.y, 0); 
    }
    public static void PlayInStart(Transform broadcast)
    {
        broadcast.rotation = Quaternion.Euler(broadcast.rotation.x, broadcast.rotation.y, 7);
    }
    public static void PlayTransmission(Transform broadcast)
    {
        broadcast.Rotate(broadcast.rotation.x, broadcast.rotation.y, -6);
    }
    public static void TonePlay(Transform broadcast, Transform broadcast2)
    {
        PlayInStart(broadcast);
        PlayTransmission(broadcast2);
    }
    public static void ToneBackPlay(Transform broadcast, Transform broadcast2)
    {
        PlayBack(broadcast);
        PlayBack(broadcast2);
    }
}
