using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmCancelScript : MonoBehaviour
{

    [SerializeField] private Image _windowImage;
    [SerializeField] private TextMeshProUGUI _confirmText;

    private void Start()
    {
        _windowImage.gameObject.SetActive(false);
        _confirmText.gameObject.SetActive(false);
    }

    public void OpenWindow()
    {
        _windowImage.gameObject.SetActive(true);
    }

    public void Confirm()
    {
        _confirmText.text = "Confirmed!";
        _confirmText.gameObject.SetActive(true);
        _windowImage.gameObject.SetActive(false);
    }

    public void Cancel()
    {
        _windowImage.gameObject.SetActive(false);
    }



}
