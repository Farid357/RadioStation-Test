using UnityEngine;
using System.Collections;

public sealed class Tone : MonoBehaviour
{
    public int NumberOfClicks => _number;
    public static bool IsPressed { get;  set; }
    public AudioSource Toner => _tone;
    [SerializeField] private AudioSource _tone;
    [SerializeField] private Retainer _retainerSystem;
    [SerializeField] private Pressure _pressure;
    [SerializeField] private GameObject _retainer;
    [SerializeField] private SoundsMayDay _soundsMayDay;
    [SerializeField] private RecieveButton _recieveButton;
    [SerializeField] private TransmissionButton _transmissionButton;
    [SerializeField] private MayDayTransmissionButton _mayDayTransmissionButton;
    [SerializeField] private Transform _retainerUp;
    [SerializeField] private Transform _retainerDown;
    private int _number;

    public void OnTurnTone()
    {
        if (RadioState.CanWork() && !_mayDayTransmissionButton.IsPressed && !_transmissionButton.IsPressed && !_soundsMayDay.IsPressed && !_recieveButton.IsPressed)
        {
            _number++;
            if (_number == 2 || _number == 3)
            { 
                _retainer.transform.position = _retainerUp.position;
                IsPressed = true;
            }
            if (_number == 4)
            {
                _retainer.transform.position = _retainerDown.position;
                StopAudio();
            }
        }
        
    }
    public void StopAudio()
    {
        IsPressed = false;
        _number = 0;
        _tone.Stop();
    }
   
    private void Update()
    {
        if (!RadioState.CanWork())
            StopAudio();
        if(RadioState.CanWork() && IsPressed && !Retainer.IsPressed && !_mayDayTransmissionButton.IsPressed && !_transmissionButton.IsPressed && !_soundsMayDay.IsPressed && !_recieveButton.IsPressed)
        { if(!_tone.isPlaying)
            _tone.Play();
        }
    }
}