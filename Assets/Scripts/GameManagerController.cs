using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{

    public int npcMission;
    int dayMissions;
    BoxCollider2D boxCollider;

    public TextMeshProUGUI contadorPrimeraMision;

    public TextMeshProUGUI contadorMisionNotas;

    public float contadorNotas = 0;
    public float contadorZonas = 0;

    [SerializeField] private GameObject misionCumplida;

    //misiones subrayadas
    [SerializeField] private GameObject mision1Completada;
    [SerializeField] private GameObject mision2Completada;
    [SerializeField] private GameObject mision3Completada;

    //misiones completadas icon
    [SerializeField] private GameObject mision1Icon;
    [SerializeField] private GameObject mision2Icon;
    [SerializeField] private GameObject mision3Icon;


    // Start is called before the first frame update
    void Start()
    {
        npcMission = 0;
        contadorNotas = 0;
        contadorZonas = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        contadorPrimeraMision.text= $"{npcMission}" + "/" + "5";
        contadorMisionNotas.text= $"{contadorNotas}" + "/" + "10";
    }
    public void NPCMission()
    {
        npcMission++;
        if(npcMission == 5)
        {
            mision1Completada.SetActive(true);
            mision1Icon.SetActive(true);
            CompletingDayMissions();
        }
    }
    public void CompletingDayMissions()
    {
        dayMissions++;
        if(dayMissions == 3)
        {
            boxCollider.enabled = true;
            misionCumplida.SetActive(true);
        }
    }

    public void GetNotes(int amount)
    {
        contadorNotas += amount;
        if(contadorNotas == 10)
        {
            mision3Completada.SetActive(true);
            mision3Icon.SetActive(true);
            CompletingDayMissions();
        }
    }

    public void GetZones(int amount)
    {
        contadorZonas += amount;
        if(contadorZonas == 2)
        {
            mision2Completada.SetActive(true);
            mision2Icon.SetActive(true);
            CompletingDayMissions();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("IntroNoche");
    }
}
