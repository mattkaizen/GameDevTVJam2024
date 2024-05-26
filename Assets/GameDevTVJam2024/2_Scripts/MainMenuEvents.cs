using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
   private UIDocument _document;
   private Button startButton;
   private List<Button> _menuButtons = new List<Button>();
   private AudioSource buttonSound;
   private void Awake()
   {
        buttonSound = GetComponent<AudioSource>();
       _document = GetComponent<UIDocument>();
       startButton = _document.rootVisualElement.Q("StartButton") as Button;
       startButton.RegisterCallback<ClickEvent>(OnPlayGameClick);
       _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
       for (int i = 0; i < _menuButtons.Count; i++)
       {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
       }
   }
private void OnDisable()
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
   private void OnAllButtonsClick (ClickEvent evt)
   {
    buttonSound.Play();
   }
}
