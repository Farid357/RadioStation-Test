using UnityEngine;
using TMPro;
using System;
using System.Collections;

public sealed class TransmissionButton : MonoBehaviour
{   
    public bool IsPressed { get; private set; }
    [SerializeField] private SoundsMayDay _soundsMayDay;
    [SerializeField] private GameObject _transmissionPanel;
    [SerializeField] private GameObject _retainer;
    [SerializeField] private TextMeshProUGUI _transferText;

    [SerializeField] private string _transferMessage;

    [SerializeField] private Pressure _pressure;
    [SerializeField] private RecieveButton _recieveButton;
    [SerializeField] private MayDayTransmissionButton _mayDay;

    [SerializeField] private Transform _retainerUp;
    [SerializeField] private Transform _retainerDown;

    private const int _messageDelay = 3;
    private int _numberOfClicks;
   
    public void HandOver()
    {
        if(_transferMessage == null)
        {
            throw new NullReferenceException("_transferMessage is null!");
        }
        else if(RadioState.CanWork() && !_recieveButton.IsPressed && !Retainer.IsPressed && !_soundsMayDay.IsPressed && !Tone.IsPressed)
        {
            _numberOfClicks++;

            if(_numberOfClicks == 2 || _numberOfClicks == 3)
            {
                IsPressed = true;
                _retainer.transform.position = _retainerUp.position; 
            }
            if(_numberOfClicks == 4)
            {
                IsPressed = false;
                _numberOfClicks = 0;
                _retainer.transform.position = _retainerDown.position;
                DisableMessage();
            }
        }   
    }
   private void ShowMessage()
    {

        _transmissionPanel.SetActive(true);
        _transferText.text = _transferMessage;
        
    }
    private void DisableMessage()
    {
        _transmissionPanel.SetActive(false);
        _transferText.text = null;
        IsPressed = false;
    }
   private void Update()
    {
        if(IsPressed)
        {
            ShowMessage();
            _mayDay.TransmissionPanel.SetActive(false);
        }
    }
    
}
