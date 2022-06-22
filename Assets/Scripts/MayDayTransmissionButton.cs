using UnityEngine;
using TMPro;

public sealed class MayDayTransmissionButton : MonoBehaviour
{
    public bool IsPressed { get; set; }
    public GameObject TransmissionPanel => _transmissionPanel;
    [SerializeField] private GameObject _transmissionPanel;
    [SerializeField] private TextMeshProUGUI _transferText;
    [SerializeField] private Transform _broadcast;
    [SerializeField] private string _transferMessage;
    [SerializeField] private SoundsMayDay _soundsMayDay;
    [SerializeField] private RecieveButton _recieve;

    public void OnDownShowText()
    {
        if (RadioState.CanWork() && !_soundsMayDay.IsPressed && !Retainer.IsPressed && !_recieve.IsPressed && !Tone.IsPressed)
        {
            IsPressed = true;
            ButtonAnimations.PlayTransmission(_broadcast);

        }
    }
    public void OnUpShowText()
    {  
        if (RadioState.CanWork())
        {
            IsPressed = false;
            DisableText();
            ButtonAnimations.PlayBack(_broadcast);
        }
    }

    private void DisableText()
    {
        if(RadioState.CanWork() && !Retainer.IsPressed)
        {
            _transmissionPanel.SetActive(false);
        }
    }
    private void Update()
    {
        if(IsPressed)
        {
            _transmissionPanel.SetActive(true);
        }
    }

}
