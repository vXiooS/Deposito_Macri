using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SVButtonHandler : MonoBehaviour
{
    public int buttonNumber; // Il numero del pulsante
    public TextMeshProUGUI buttonText; 

    public TextMeshProUGUI outputText; //riferimento al testo esterno di output

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        outputText.text = $"Button pressed: {buttonNumber}";
    }

    public void SetButtonNumber(int number)
    {
        buttonNumber = number;
        if (buttonText != null)
        {
            buttonText.text = "Button " + number;
        }
    }

    public void SetOutputText(TextMeshProUGUI o)
    {
        outputText = o;
    }

}
