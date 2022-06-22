using UnityEngine;

public sealed class Valve : MonoBehaviour
{
    [SerializeField] private Pressure _pressure;

    [SerializeField] private Transform _newValvePosition;
    [SerializeField] private Transform _startValvePosition;

    [SerializeField] private Transform _valve;
    private int _numberOfClicks;

    public void StopPressure()
    {

        if (Pressure.IsActive && _numberOfClicks == 0)
        {
            _numberOfClicks++;
           
            if(_numberOfClicks == 1)
            {
                _valve.position = _newValvePosition.position;
                _pressure.PressurePanel.SetActive(false);
                Pressure.IsActive = false;
            }
            
        }
        else if(!Pressure.IsActive && _numberOfClicks == 1)
        {
            _numberOfClicks = 0;
            _valve.position = _startValvePosition.position;
            
        }
    }
}
