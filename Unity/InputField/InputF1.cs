using TMPro;
using UnityEngine;

public class InputF1 : MonoBehaviour
{

    [SerializeField] public TMP_InputField nameInputField; // Riferimento all'InputField
    [SerializeField] public TextMeshProUGUI nameDisplay; // Riferimento al TextMeshProUGUI


    void Start()
    {
        nameDisplay.gameObject.SetActive(false);
    }

    void Update()
    {
        // Controlla se il tasto Enter è premuto
        if (Input.GetKeyDown(KeyCode.Z))
        {
            nameDisplay.gameObject.SetActive(true);
            DisplayName();
        }
    }

    public void DisplayName()
    {
        if (nameInputField != null && nameDisplay != null)
        {
            nameDisplay.text = "Ciao, " + nameInputField.text + "!";
        }
    }
}
