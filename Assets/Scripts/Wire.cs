using UnityEngine;

public sealed class Wire : MonoBehaviour
{   
    public static bool IsConnect { get; set; }
    [SerializeField] private GameObject _wire;
    [SerializeField] private GameObject _wire2;
    private int _numberOfClicks;

   public void Connect()
    {

        _wire.SetActive(true);
        _wire2.SetActive(false);
        IsConnect = true;
        _numberOfClicks++;
        TryDisconnect();
    }
    private void TryDisconnect()
    {
        if (_numberOfClicks == 2)
        {
            IsConnect = false;
            _wire.SetActive(false);
            _wire2.SetActive(true);
            _numberOfClicks = 0;
        }
    }
   
}
