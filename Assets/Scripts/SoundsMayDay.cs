using UnityEngine;
using System;
using System.Collections;

public sealed class SoundsMayDay : MonoBehaviour, IRulingAudio
{
    public int NumberOfClicks => _numberOfClicks;
    public AudioSource[] Recordings => _recordings;
    public int CurrentIndex => _currentIndex;
    public bool IsPressed { get; set; }
    [SerializeField] private AudioSource[] _recordings;
    [SerializeField] private MayDayTransmissionButton _mayDay;
    [SerializeField] private TransmissionButton _transmission; 
    [SerializeField] private GameObject _retainer;
    [SerializeField] private RecieveButton _recieve;
    [SerializeField] private Transform _retainerUp;
    [SerializeField] private Transform _retainerDown;
    private int _currentIndex;
    private int _numberOfClicks;

    private void Play()
    {
        _recordings[_currentIndex].Play();
        
    }
    public void OnClick()
    { 
        if(RadioState.CanWork())
        _numberOfClicks++;
        if (RadioState.CanWork() && _numberOfClicks == 3)
            _currentIndex--;
       
        if (_numberOfClicks == 2 && RadioState.CanWork() || _numberOfClicks == 3 && RadioState.CanWork())
        {
            if (!_recieve.IsPressed && !Retainer.IsPressed && !Tone.IsPressed && !_mayDay.IsPressed && !_transmission.IsPressed)
            {
                IsPressed = true;
                _retainer.transform.position = _retainerUp.position;
                _recieve.Recordings[_recieve.CurrentIndex].Stop();
            }
        }
        if (_numberOfClicks == 4 && RadioState.CanWork())
        {
            if (!_recieve.IsPressed && !Retainer.IsPressed && !Tone.IsPressed && !_mayDay.IsPressed && !_transmission.IsPressed)
            {
                _numberOfClicks = 0;
                IsPressed = false;
                StopAudio();
                _recieve.Recordings[_recieve.CurrentIndex].Stop();
            }
        }
    }

    private void Update()
    {
        if (!_recordings[_currentIndex].isPlaying && IsPressed && RadioState.CanWork() && !_recieve.IsPressed)
        {  
            if (_currentIndex >= 5)
            {
                _currentIndex = 0;
                _recordings[_currentIndex].Play();
            }
            else if(_currentIndex < _recordings.Length)
            {
                _currentIndex++;
                _recordings[_currentIndex].Play();
            }
        }
    }
    public void StopAudio()
    {
        _recordings[_currentIndex].Stop();
        _retainer.transform.position = _retainerDown.position;
       
    }
 
}
