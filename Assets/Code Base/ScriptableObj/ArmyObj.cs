using UnityEngine;

public enum ArmyType
{
    Car,
    Tank,
    Soldier,
}

[CreateAssetMenu(fileName = "ArmyObj", menuName = "Scriptable/Army Obj")]
public class ArmyObj : ScriptableObject
{
    public string nameObj;
    public ArmyType type;
    public Sprite preview;
    public GameObject prefab;
}
