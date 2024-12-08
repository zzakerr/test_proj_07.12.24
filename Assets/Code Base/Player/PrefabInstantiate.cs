using UnityEngine;

public class PrefabInstantiate : SingletonBase<PrefabInstantiate>
{
    [SerializeField] private Transform spawnObjects;
    private GameObject currentObject;
    private Camera mainCamera;
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    public void SetPrefab(GameObject prefab)
    {
        currentObject = Instantiate(prefab,spawnObjects);
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward, out hit))
        {
            currentObject.transform.position = hit.point;
        }

        var save = currentObject.AddComponent<SaveObj>();
        save.Init(prefab);
        save.Save();
    }
}
