using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveUi : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private TMP_InputField inputField;

    private bool isInput;
    private void Start()
    {
        SwitchSaveInput();
        
        saveButton.onClick.AddListener(SwitchSaveInput);
        inputField.onEndEdit.AddListener(Save);
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
