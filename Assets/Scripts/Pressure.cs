using UnityEngine;
using System.Collections;
using TMPro;

public sealed class Pressure : MonoBehaviour
{   
    public static bool IsActive { get; set; }
    public GameObject PressurePanel => _pressurePanel;
    [SerializeField] private TextMeshProUGUI _pressureText;
    [SerializeField] private GameObject _pressurePanel;
    private const string PressureMessage = "Давление повышено!";
    private const int RandomDelay = 10;

    private void Start()
    {
        InvokeRepeating("TryToRaise", RandomDelay, 10);
    }
  
    private IEnumerator ToRaise()
    {
        yield return new WaitForSeconds(RandomDelay);
        _pressurePanel.SetActive(true);
        _pressureText.text = PressureMessage;
        IsActive = true;

    }
    private void TryToRaise()
    {
        if (RadioState.CanWork())
        {
            StartCoroutine(ToRaise());
        }
    }
}
