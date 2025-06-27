using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SVButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab; 
    public RectTransform contentPanel; // Il pannello Content della Scroll View
    public int numberOfButtons = 20; 
    [SerializeField] public TextMeshProUGUI outputText; //riferimento al testo di output

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        for (int i = 0; i < numberOfButtons; i++)
        {
            // Istanzia il prefab del pulsante
            GameObject newButton = Instantiate(buttonPrefab);

            // Imposta il genitore (parent) dell'oggetto al pannello Content
            newButton.transform.SetParent(contentPanel, false);

            // Ottieni lo script ButtonClickHandler
            SVButtonHandler clickHandler = newButton.GetComponent<SVButtonHandler>();
            if (clickHandler != null)
            {
                // Imposta il numero del pulsante
                clickHandler.SetButtonNumber(i + 1);
                clickHandler.SetOutputText(outputText);
            }
            
        }
    }
}
