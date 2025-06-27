using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    [SerializeField] private Image _toggleImage;

    [SerializeField] private TextMeshProUGUI _status;

    void Start()
    {
        _toggle.onValueChanged.AddListener(ToggleImage);
    }

    public void ToggleImage(bool active)
    {
        _toggleImage.gameObject.SetActive(active);
        if (active)
        {
            _status.text = "Active";
        }
        else
        {
            _status.text = "Not Active";
        }
    }

}
