using UnityEngine;
using System.Collections;
using System;

public sealed class RecieveButton : MonoBehaviour
{ 
    public int CurrentIndex => _currentIndex;
    public AudioSource[] Recordings => _recordings; 
    public bool IsPressed { get;  set; }
    [SerializeField] private AudioSource[] _recordings;
    [SerializeField] private Transform _broadcast;
    [SerializeField] private Pressure _pressure;
    [SerializeField] private TransmissionButton _transmission;
    [SerializeField] private SoundsMayDay _soundsMayDay;
    [SerializeField] private MayDayTransmissionButton _mayDay;

    private int _firstRecornding;
    private int _currentIndex;
    private int _numberOfClicks;

    public void OnPlayDown()
    {

        if (!_transmission.IsPressed && RadioState.CanWork() && !_recordings[_currentIndex].isPlaying && !_mayDay.IsPressed)
        {
            if (!_soundsMayDay.IsPressed && !Retainer.IsPressed && !Tone.IsPressed)
            {
                IsPressed = true;
                _soundsMayDay.Recordings[_soundsMayDay.CurrentIndex].Stop();
                ButtonAnimations.PlayBack(_broadcast);

            }
        }
    }
    public void OnPlayUp()
    { 
        if (RadioState.CanWork())
        {
            _recordings[_currentIndex].Stop();
            IsPressed = false;
            _soundsMayDay.Recordings[_soundsMayDay.CurrentIndex].Stop();
            ButtonAnimations.PlayInStart(_broadcast);
        }
    }

    private void Play()
    {

        if (_currentIndex == _recordings.Length)
        {
            _currentIndex = 0;
            _recordings[_firstRecornding].Play();
            _currentIndex++;
        }
        else if (_currentIndex < _recordings.Length)
        {
            if (!_recordings[_currentIndex].isPlaying)
            {
                if (_currentIndex == 0)
                {
                    _recordings[_firstRecornding].Play();
                    _currentIndex++;
                    return;
                }
                else if (_currentIndex > 0 && _currentIndex < _recordings.Length && !_recordings[_firstRecornding].isPlaying)
                {
                    _currentIndex++;
                    _recordings[_currentIndex].Play();
                }
            }
            if(_recordings[_firstRecornding].isPlaying && _recordings[1].isPlaying)
            {
                _recordings[1].Stop();
            }

        }
        else
        {
            throw new InvalidOperationException("Invalid index value");
        }
        
    }
    private void Update()
    {
        if (IsPressed && RadioState.CanWork())
        {
            Play();

        }
    }
}
