using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveUi : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TMP_InputField inputField;

    private bool isInput;
    private void Start()
    {
        SwitchSaveInput();
        
        saveButton.onClick.AddListener(SwitchSaveInput);
        exitButton.onClick.AddListener(ExitEditor);
        inputField.onEndEdit.AddListener(Save);
    }

    private void ExitEditor()
    {
       SceneManager.LoadScene(0);
    }

    private void Save(string arg0)
    {
        SaveManager.Instance.Save(arg0);
        SwitchSaveInput();
    }

    private void SwitchSaveInput()
    {
        if(isInput) inputField.gameObject.SetActive(true);
        else inputField.gameObject.SetActive(false);
        isInput = !isInput;
    }
}
