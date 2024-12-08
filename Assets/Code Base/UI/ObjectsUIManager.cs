using UnityEngine;
using UnityEngine.UI;

public class ObjectsUIManager : MonoBehaviour
{
    [Header("Army Objects")]
    [SerializeField] private ArmyObj[] armyObjs;
    
    [Space]
    [Header("UI Elements")]
    [SerializeField] private Button objectsButton;
    [SerializeField] private Button tanksButton;
    [SerializeField] private Button soldierButton;
    [SerializeField] private Button carsButton;
    [SerializeField] private GameObject objectsPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private ObjectUI objectUIPrefab;
    
    private bool isOptions;
    private void Start()
    {
        SwitchOptions();
        
        objectsButton.onClick.AddListener(SwitchOptions);
        tanksButton.onClick.AddListener(ShowTanks);
        soldierButton.onClick.AddListener(ShowSoldier);
        carsButton.onClick.AddListener(ShowCars);
    }

    
    private void ShowCars()
    {
        ClearAllObjects();
        CreateList(ArmyType.Car);
    }

    private void ShowSoldier()
    {
        ClearAllObjects();
        CreateList(ArmyType.Soldier);
    }


    private void ShowTanks()
    {
        ClearAllObjects();
        CreateList(ArmyType.Tank);
    }

    private void SwitchOptions()
    {
        if(isOptions) optionsPanel.SetActive(true);
        else optionsPanel.SetActive(false);
        ClearAllObjects();
        isOptions = !isOptions;
    }
    
    private void CreateList(ArmyType armyType)
    {
        for (int i = 0; i < armyObjs.Length; i++)
        {
            if (armyObjs[i].type == armyType)
            {
                var obj = Instantiate(objectUIPrefab, objectsPanel.transform);
                obj.Setup(armyObjs[i]);
            }
        }
    }
    
    private void ClearAllObjects()
    {
        var y = objectsPanel.transform.childCount;

        for (int i = y; i > 0; i--)
        {
            Destroy(objectsPanel.transform.GetChild(i-1).gameObject);
        }
    }
}
