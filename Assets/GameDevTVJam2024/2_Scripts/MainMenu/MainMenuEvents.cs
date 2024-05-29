using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class MainMenuEvents : MonoBehaviour
{
   private UIDocument _document;

   public VisualElement ui;

   private Button startButton;
   private Button optionsButton;
   private Button quitButton;

   /*private List<Button> _menuButtons = new List<Button>();
   private AudioSource buttonSound; */
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        /*
        buttonSound = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();
        startButton = _document.rootVisualElement.Q("StartButton") as Button;
        startButton.RegisterCallback<ClickEvent>(OnPlayGameClick);
        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }                     */
    }
    /*private void OnDisable()
    {
        startButton.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }                
    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("You pressed Start Button");
    }
    private void OnAllButtonsClick(ClickEvent evt)
    {
        buttonSound.Play();

    }                            */

    private void OnEnable()
    {
        startButton = ui.Q<Button>("StartButton");
        startButton.clicked += OnPlayButtonClicked;

        optionsButton = ui.Q<Button>("HowToButton");
        optionsButton.clicked += OnOptionsButtonClicked;

        quitButton = ui.Q<Button>("QuitButton");
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options"); 
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Lvl_1");
    }                           
   
}                                

