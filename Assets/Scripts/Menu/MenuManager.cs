using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using Core;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject modeMenu;
    [SerializeField] private GameObject multiplayerMenu;
    [SerializeField] private GameObject serverMenu;
    [SerializeField] private GameObject configMenu;
    [SerializeField] private GameObject characterMenu;
    [SerializeField] private GameObject stageMenu;
    [SerializeField] private GameObject confirmMenu;
    [SerializeField] private GameObject scoreMenu;

    [SerializeField, HideInInspector] private static Dictionary<string, GameObject> s_menus = new Dictionary<string, GameObject>();

    void Awake()
    {
        foreach(Transform child in canvas.transform)
        {
            if(child.CompareTag("Menu"))
                s_menus.Add(child.gameObject.name, child.gameObject);
        }

        LoadMenu("MainMenu");

        // TODO: fetch this information from the menus, later
        s_MatchSettings.mode = Mode.HOST;
        s_MatchSettings.character = CharacterID.NULL;
        s_MatchSettings.stage = StageID.NULL;
        s_MatchSettings.nRounds = 10;
        s_MatchSettings.nPlayers = 1;
        s_MatchSettings.bonuses = false;
        s_MatchSettings.randomEvents = false;
    }

    public void DisableAll()
    {
        foreach(var (key, value) in s_menus)
            s_menus[key].SetActive(false);
    }

    public void LoadMenu(string name)
    {
        DisableAll();
        s_menus[name].SetActive(true);
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void LoadScene()
    {
        NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}