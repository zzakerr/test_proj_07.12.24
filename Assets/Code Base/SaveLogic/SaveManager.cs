using UnityEngine;
using System;
using System.Collections.Generic;

public class SaveManager : SingletonBase<SaveManager>
{
    [Serializable]
    private class ObjectState
    {
        public GameObject prefab;
        public Vector3 position;
        public Quaternion rotation;
    }
    
    private List<ObjectState>  SaveObjData = new();
    private ObjectState[] loadObjData;
    private string fileName;
    
    private void Awake()
    {
        Init();
    }
    
    public void AddSaveObj(SaveObj saveObj)
    { 
        var state = new ObjectState();
        state.prefab = saveObj.Prefab;
        state.position = saveObj.Position;
        state.rotation = saveObj.Rotation;
        SaveObjData.Add(state);
    }
    
    public void Save(string saveName)
    {
        Saver<ObjectState[]>.Save(saveName, SaveObjData.ToArray());
    }
    
    public void Load(string saveName)
    {
        if (Saver<ObjectState[]>.TryLoad(saveName, ref loadObjData))
        {
            for (int i = 0; i < loadObjData.Length; i++)
            {
               Instantiate(loadObjData[i].prefab, loadObjData[i].position, loadObjData[i].rotation);
            }
        }
    }
    
    public void RemoveSave(string saveName)
    {
        FileHandler.Reset(fileName);
    }
}
