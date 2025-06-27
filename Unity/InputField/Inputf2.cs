using TMPro;
using UnityEngine;

public class Inputf2 : MonoBehaviour
{
    [SerializeField] public TMP_InputField numberInputField;
    [SerializeField] public TextMeshProUGUI resultDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resultDisplay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            VerifyNumber();
            resultDisplay.gameObject.SetActive(true);
        }
    }

    public void VerifyNumber()
    {
        int x = int.Parse(numberInputField.text);

        if (numberInputField != null && resultDisplay != null)
        {
            if (x >= 100)
            {
                resultDisplay.text = "True!";
            }
            else
            {
                resultDisplay.text = "False!";
            }
        }
    }
}
