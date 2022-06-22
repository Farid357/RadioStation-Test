using UnityEngine;
using System.Collections;
using System;

public sealed class Retainer : MonoBehaviour
{
    public static bool IsPressed { get;  set; }
    [SerializeField] private Tone _toneSystem;
    public AudioSource ToneSound => _tone;
    [SerializeField] private AudioSource _tone;
    [SerializeField] private GameObject _retainer;
    [SerializeField] private Transform _broadCast;
    [SerializeField] private Transform _broadCast1;
    [SerializeField] private SoundsMayDay _soundsMayDay;
    [SerializeField] private RecieveButton _recieveButton;
    [SerializeField] private TransmissionButton _transmissionButton;
    [SerializeField] private MayDayTransmissionButton _mayDayTransmissionButton;

    
    public void OnUpTone()
    {
        if (RadioState.CanWork())
        {
            IsPressed = false;
            _tone.Stop();
            ButtonAnimations.TonePlay(_broadCast, _broadCast1);
        }
    }
    public void OnDownTone()
    {
        if (RadioState.CanWork() && !_mayDayTransmissionButton.IsPressed && !_transmissionButton.IsPressed && !_soundsMayDay.IsPressed && !_recieveButton.IsPressed)
        {
            IsPressed = true;
            ButtonAnimations.ToneBackPlay(_broadCast, _broadCast1);
        }
    }
   
    private void Update()
    {
        if(!RadioState.CanWork())
        {
            _tone.Stop();
            IsPressed = false;
        }
        if(RadioState.CanWork() && IsPressed  && _toneSystem.NumberOfClicks < 2 && !_mayDayTransmissionButton.IsPressed && !_transmissionButton.IsPressed && !_soundsMayDay.IsPressed && !_recieveButton.IsPressed)
        {   if(!_tone.isPlaying)
            _tone.Play();
        }
    }
}

