using System.IO;
using Services.SaveLoad.Contracts;
using UnityEngine;

namespace Services.SaveLoad
{
    public class JsonSaver : ISaver
    {
        public void Save<T>(string filename, T data) where T : class
        {
            var path = GetFilePath(filename);
            File.WriteAllText(path, JsonUtility.ToJson(data));
        }
        
        public T Load<T>(string filename) where T : class
        {
            var path = GetFilePath(filename);

            return FileExists(path) ? JsonUtility.FromJson<T>(File.ReadAllText(path)) : default;
        }
        
        private bool FileExists(string path)
        {
            return File.Exists(path);
        }

        private string GetFilePath(string filename)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            var path = Path.Combine(Application.dataPath, filename);
#elif UNITY_IOS || UNITY_ANDROID
            var path = Path.Combine(Application.persistentDataPath, filename);
#endif
            return path;
        }
    }
}