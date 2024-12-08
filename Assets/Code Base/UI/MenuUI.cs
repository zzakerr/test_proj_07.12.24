using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject editor;
    [SerializeField] private GameObject choiceSave;
    [Space]
    [Header("Menu Buttons")]
    [SerializeField] private Button gameButton;
    [SerializeField] private Button editorButton;
    [SerializeField] private Button exitButton;
    [Space]
    [Header("Editor Buttons")]
    [SerializeField] private Button newMapButton;
    [SerializeField] private Button loadMapButton;
    [SerializeField] private Button mainMenuButton;
    [Space]
    [Header("Choose Buttons")]
    [SerializeField] private TMP_Dropdown loadArrayDropdown;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button mainMenu2Button;

    private string[] SaveFiles;
    
    private bool isMenu;
    private bool isEditor;
    private bool isChoiceSave;

    private int sceneIndex;
    private void Start()
    {
        SwitchEditorShow();
        SwitchChoiceSaveShow();
        
        //Menu Logic
        gameButton.onClick.AddListener(SwitchMenuShow);
        gameButton.onClick.AddListener(Game);
        gameButton.onClick.AddListener(SwitchChoiceSaveShow);
        
        editorButton.onClick.AddListener(SwitchMenuShow);
        editorButton.onClick.AddListener(Editor);
        editorButton.onClick.AddListener(SwitchEditorShow);
        
        exitButton.onClick.AddListener(ExitGame);
        
        //Editor Logic
        newMapButton.onClick.AddListener(LoadNewGame);
        
        loadMapButton.onClick.AddListener(SwitchEditorShow);
        loadMapButton.onClick.AddListener(SwitchChoiceSaveShow);
        
        mainMenuButton.onClick.AddListener(SwitchEditorShow);
        mainMenuButton.onClick.AddListener(SwitchMenuShow);
        
        //ChoiceSave Logic
        mainMenu2Button.onClick.AddListener(SwitchChoiceSaveShow);
        mainMenu2Button.onClick.AddListener(SwitchMenuShow);
        
        loadButton.onClick.AddListener(LoadGame);
        
        //LoadArray Logic
        SaveFiles = FileHandler.GetAllFiles();
        if (SaveFiles.Length == 0)
        {
            loadArrayDropdown.interactable = false;
        }
        for (int i = 0; i < SaveFiles.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = SaveFiles[i];
            loadArrayDropdown.options.Add(data);
        }
    }
    
    private void LoadGame()
    {
        if (loadArrayDropdown.options.Count == 0)
        {
            Debug.Log("Can't load");
            return;
        }
        
        var savename = loadArrayDropdown.options[loadArrayDropdown.value].text;
        LoadManager.Instance.LoadScene(sceneIndex, savename);
    }

    private void LoadNewGame()
    {
        LoadManager.Instance.LoadScene(sceneIndex, "NewGame");
    }
    
    private void Game()
    {
        sceneIndex = 1;
    }
    
    private void Editor()
    {
        sceneIndex = 2;
    }
    
    private void SwitchMenuShow()
    {
        isMenu = Switcher(isMenu,menu);
    }
    
    private void SwitchEditorShow()
    {
        isEditor = Switcher(isEditor,editor);
    }
    
    private void SwitchChoiceSaveShow()
    {
       isChoiceSave = Switcher(isChoiceSave,choiceSave);
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }
    
    private bool Switcher(bool value,GameObject gameObject)
    {
        if(value) gameObject.SetActive(true);
        else gameObject.SetActive(false);
        value = !value;
        return value;
    }
    
    private void RemoveListeners()
    {
        
    }
}
