using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button b;
    // void Start()
    // {
    //     b.onClick.AddListener(ClickLog);
    // }

    public void ClickLog()
    {
        Debug.Log("Button clicked!");
    }
}
