using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Image _image;

    void Start()
    {
        List<string> options = new List<string>
        {
            "Rosso",
            "Verde",
            "Blu"
        };
        _dropdown.ClearOptions();
        _dropdown.AddOptions(options);    

        _dropdown.onValueChanged.AddListener(ColorChange);
    }

    public void ColorChange(int i)
    {
        switch (i)
        {
            case 0:
                _image.color = Color.red;
                break;
            case 1:
                _image.color = Color.green;
                break;
            case 2:
                _image.color = Color.blue;
                break;
        }
    }
}
