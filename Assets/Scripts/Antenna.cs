using UnityEngine;

public sealed class Antenna : MonoBehaviour
{   
    public static bool IsConnect { get; set; }

    [SerializeField] private GameObject _antenna;
    [SerializeField] private GameObject _startAntenna;
    [SerializeField] private Transform _antennaPosition;
    [SerializeField] private Transform _startPosition;
    private int _numberOfClicks;

    public void OnClickAntenna()
    { 
        if (_numberOfClicks == 0)
        {
            _startAntenna.SetActive(false);
            _antenna.SetActive(true);
            _numberOfClicks++;
            return;
        }
        if(_numberOfClicks == 1)
        {
            _antenna.transform.position = _antennaPosition.position;
            _numberOfClicks++;
            IsConnect = true;
            return;
        }
        
    }
    public void OnClickAntennaPlace()
    {
        if (_numberOfClicks == 2)
        {
            _startAntenna.SetActive(true);
            _antenna.SetActive(false);
            _antenna.transform.position = _startPosition.position;
            IsConnect = false;
            _numberOfClicks = 0;
        }
    }
}
