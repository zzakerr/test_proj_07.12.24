using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectUI : MonoBehaviour ,IPointerClickHandler
{
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField]private Image icon;

    private ArmyObj armyObj;

    public void Setup(ArmyObj armyObj)
    {
        this.armyObj = armyObj;
        SetText(armyObj.nameObj);
        SetIcon(armyObj.preview);
    }
    private void SetText(string text)
    {
        this.text.text = text;
    }

    private void SetIcon(Sprite icon)
    {
        this.icon.sprite = icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PrefabInstantiate.Instance.SetPrefab(armyObj.prefab);
    }
}
