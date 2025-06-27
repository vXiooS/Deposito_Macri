using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Button up;
    public Button down;

    [SerializeField] private TextMeshProUGUI _numberText;
    private float _currentNumber = 0;

    public void NumberUp()
    {
        _currentNumber++;
        Update();
    }

    public void NumberDown()
    {
        _currentNumber--;
        Update();
    }

    private void Update()
    {
        _numberText.text = _currentNumber.ToString();
    }
}
