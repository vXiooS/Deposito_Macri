using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GestionaleScript : MonoBehaviour
{
    [SerializeField] public TMP_InputField nomeInputField;
    [SerializeField] public TMP_InputField cognomeInputField;
    [SerializeField] public TMP_InputField etaInputField;
    [SerializeField] public TMP_Dropdown classDropdown;
    [SerializeField] public Slider votoSlider;
    [SerializeField] public Button saveButton;
    [SerializeField] public Button resetButton;
    [SerializeField] public GameObject studentePrefab;
    [SerializeField] public Transform content;

    List<Studente> studenti = new List<Studente>();


    void Start()
    {
        List<string> options = new List<string>
        {
            "Classe 1A",
            "Classe 1B",
            "Classe 1C",
            "Classe 1D",
            "Classe 2A",
            "Classe 2B",

        };
        classDropdown.ClearOptions();
        classDropdown.AddOptions(options);
        //classDropdown.onValueChanged.AddListener(delegate { ClassSelection(classDropdown); });

        //votoSlider.onValueChanged.AddListener(VotoSliderChange);
        saveButton.onClick.AddListener(ButtonSave);
        resetButton.onClick.AddListener(ButtonReset);
    }

    public void ButtonSave()
    {
        if (nomeInputField != null && cognomeInputField != null && etaInputField != null)
        {
            Studente s = new Studente();
            s.nome = nomeInputField.text;
            s.cognome = cognomeInputField.text;
            s.eta = int.Parse(etaInputField.text);
            s.classe = classDropdown.options[classDropdown.value].text;
            s.voto = votoSlider.value;

            studenti.Add(s);
            AddToScroll(s);
        }
    }

    public void ButtonReset()
    {
        studenti.Clear();

        foreach (Transform t in content)
        {
            Destroy(t.gameObject);
        }
    }

    public void AddToScroll(Studente s)
    {
        GameObject o = Instantiate(studentePrefab, content);

        o.transform.Find("NomeCognomeText").GetComponent<TextMeshProUGUI>().text = s.nome + " " + s.cognome;
        o.transform.Find("EtaText").GetComponent<TextMeshProUGUI>().text = s.eta.ToString();
        o.transform.Find("ClasseText").GetComponent<TextMeshProUGUI>().text = s.classe;
        o.transform.Find("VMText").GetComponent<TextMeshProUGUI>().text = s.voto.ToString("F1");

        // Canvas.ForceUpdateCanvases();
        // ScrollRect scrollRect = content.GetComponentInParent<ScrollRect>();
        // scrollRect.verticalNormalizedPosition = 0f; // Scorri verso il basso
    }

    public class Studente
    {
        public string nome;
        public string cognome;
        public int eta;
        public string classe;
        public float voto;
    }
}
