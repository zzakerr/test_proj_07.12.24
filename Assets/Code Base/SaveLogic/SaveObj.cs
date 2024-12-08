using UnityEngine;

public class SaveObj : MonoBehaviour
{
    public GameObject Prefab { get; private set; }
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }
    
    public void Init(GameObject prefab)
    {
        Prefab = prefab;
        Position = transform.position;
        Rotation = transform.rotation;
    }

    public void Save()
    {
        SaveManager.Instance.AddSaveObj(this);
    }
}
