using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{

    public int npcMission;
    int dayMissions;
    BoxCollider2D boxCollider;

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
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("");
    }
}
