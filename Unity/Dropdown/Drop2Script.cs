using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Drop2Script : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private TextMeshProUGUI _difficultyText;
    private string _currentDifficulty;

    void Start()
    {
        List<string> options = new List<string>
        {
            "Easy",
            "Medium",
            "Hard"
        };
        _dropdown.ClearOptions();
        _dropdown.AddOptions(options);

        _dropdown.onValueChanged.AddListener(DifficultyChange);
    }

    public void DifficultyChange(int i)
    {
        switch (i)
        {
            case 0:
                _currentDifficulty = "Difficulty: Easy";
                break;
            case 1:
                _currentDifficulty = "Difficulty: Medium";
                break;
            case 2:
                _currentDifficulty = "Difficulty: Hard";
                break;
        }
        _difficultyText.text = _currentDifficulty;
    }
}
