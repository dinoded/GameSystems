using CustomTools;
using System;
using UnityEngine;

namespace SaveSystem
{
    /// <summary>
    /// Abstract base class for components that can save and load data.
    /// </summary>
    public abstract class Saver : MonoBehaviour // TODO: add better comments
    {
        [ReadOnly] public string id;

        public virtual void OnValidate()
        {
            if (string.IsNullOrEmpty(id))
            {
                GenerateNewID();
                Debug.Log($"GUID generated: {id}");
            }
        }

        public virtual string GetID() => id;

        [Button]
        protected void GenerateNewID()
        {
            id = Guid.NewGuid().ToString();
        }

        public abstract void Load(Tuple<string, object> data);
        public abstract Tuple<string, object> Save();
    }
}