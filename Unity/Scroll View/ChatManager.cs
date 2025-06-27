using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField nameInputField; // Riferimento all'InputField per il nome
    public TMP_InputField messageInputField; // Riferimento all'InputField per il messaggio
    public GameObject messagePrefab; // Prefab del messaggio
    public Transform content; // Riferimento al Content della Scroll View

    public void SendMessage()
    {
        string name = nameInputField.text;
        string message = messageInputField.text;

        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(message))
        {
            GameObject newMessage = Instantiate(messagePrefab, content);
            TMP_Text messageText = newMessage.GetComponent<TMP_Text>();
            messageText.text = $"{name}: {message}";

            // Pulisci l'InputField del messaggio
            messageInputField.text = "";

            // Scorri verso il basso
            Canvas.ForceUpdateCanvases();
            ScrollRect scrollRect = content.GetComponentInParent<ScrollRect>();
            scrollRect.verticalNormalizedPosition = 0f; // Scorri verso il basso
        }
    }
}