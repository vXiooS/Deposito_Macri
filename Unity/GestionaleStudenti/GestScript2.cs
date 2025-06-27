using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class GestioneStudenti : MonoBehaviour
{
    [SerializeField] public Image inputImage;
    [SerializeField] public Button inputWindowButton;
    [SerializeField] public TMP_InputField inputNome;
    [SerializeField] public TMP_InputField inputCognome;
    [SerializeField] public TMP_InputField inputEta;
    [SerializeField] public TMP_Dropdown dropdownClasse;
    [SerializeField] public Slider sliderVoto;
    [SerializeField] public Toggle ripetenteToggle;
    [SerializeField] public Button bottoneAggiungi;
    [SerializeField] public Button bottoneCancel;
    [SerializeField] public Button bottoneReset;
    [SerializeField] public Transform contenitoreStudenti;
    [SerializeField] public GameObject prefabStudente;

    private List<Studente> listaStudenti = new List<Studente>();

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
        dropdownClasse.ClearOptions();
        dropdownClasse.AddOptions(options);

        inputImage.gameObject.SetActive(false);
        inputWindowButton.onClick.AddListener(AggiungiWindow);

        bottoneAggiungi.onClick.AddListener(AggiungiStudente);
        bottoneCancel.onClick.AddListener(CancelAggiungiStudente);
        bottoneReset.onClick.AddListener(ResetLista);
    }

    void AggiungiWindow()
    {
        inputImage.gameObject.SetActive(true);
    }

    void AggiungiStudente()
    {
        Studente nuovo = new Studente
        {
            nome = inputNome.text,
            cognome = inputCognome.text,
            eta = int.Parse(inputEta.text),
            classe = dropdownClasse.options[dropdownClasse.value].text,
            voto = sliderVoto.value,
            ripetente = ripetenteToggle
        };

        listaStudenti.Add(nuovo);
        VisualizzaStudente(nuovo);
        inputImage.gameObject.SetActive(false);
    }

    public void CancelAggiungiStudente()
    {
        inputImage.gameObject.SetActive(false);
    }


    void VisualizzaStudente(Studente studente)
    {
        GameObject elemento = Instantiate(prefabStudente, contenitoreStudenti);

        elemento.transform.Find("NomeCognomeText").GetComponent<TextMeshProUGUI>().text = studente.nome + " " + studente.cognome;
        elemento.transform.Find("EtaText").GetComponent<TextMeshProUGUI>().text = "età: "+ studente.eta.ToString();
        elemento.transform.Find("ClasseText").GetComponent<TextMeshProUGUI>().text = "classe: "+studente.classe;
        elemento.transform.Find("VMText").GetComponent<TextMeshProUGUI>().text = "voto medio: "+studente.voto.ToString("F1");
        elemento.transform.Find("RipetenteText").GetComponent<TextMeshProUGUI>().text = "ripetente: "+ studente.ripetente.ToString();

        Button btnModifica = elemento.transform.Find("ModificaButton").GetComponent<Button>();
        Button btnRimuovi = elemento.transform.Find("EliminaButton").GetComponent<Button>();

        btnRimuovi.onClick.AddListener(() => RimuoviStudente(studente, elemento));
        btnModifica.onClick.AddListener(() => ModificaStudente(studente, elemento));
    }

    private void RimuoviStudente(Studente s, GameObject e)
    {
        listaStudenti.Remove(s);
        Destroy(e);
    }

    public void ModificaStudente(Studente s, GameObject e)
    {
        inputNome.text = s.nome;
        inputCognome.text = s.cognome;
        inputEta.text = s.eta.ToString();
        dropdownClasse.value = dropdownClasse.options.FindIndex(o => o.text == s.classe);
        sliderVoto.value = s.voto;

        listaStudenti.Remove(s);
        Destroy(e);
    }


    public void ResetLista()
    {
        listaStudenti.Clear();

        foreach (Transform figlio in contenitoreStudenti)
        {
            Destroy(figlio.gameObject);
        }
    }
}

[System.Serializable]
public class Studente
{
    public string nome;
    public string cognome;
    public int eta;
    public string classe;
    public float voto;
    public bool ripetente;
}
