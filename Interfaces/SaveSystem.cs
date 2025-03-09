using UnityEngine;
using System;
using CustomTools;
using SaveSystem;

namespace MyGame
{
    public class SaveSystem : MonoBehaviour, MyGame.Interfaces.ISavable
    {
        [SerializeField] private string id = null;
        private int myValue;

        void OnEnable()
        {
            if (string.IsNullOrEmpty(id))
            {
                GenerateNewID();
            }
            LoadData();
        }

        public void SaveData()
        {
            SaveSettings.Save(id, new Tuple<string, object>("MyKey", myValue));
        }

        public void LoadData()
        {
            var data = SaveSettings.Load(id);
            if (data != null)
            {
                myValue = (int)data.Item2;
            }
        }

        public Tuple<string, object> Save()
        {
            return new Tuple<string, object>("MyKey", myValue);
        }

        public void Load(Tuple<string, object> data)
        {
            myValue = (int)data.Item2;
        }

        [Button]
        public void GenerateNewID()
        {
            Guid guid = Guid.NewGuid();
            id = guid.ToString();
        }
    }
}