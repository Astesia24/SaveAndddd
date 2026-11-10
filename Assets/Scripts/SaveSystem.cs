using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public static class SaveSystem
{
    private static string GetSaveFolderPath()
    {
        string folderPath;
#if UNITY_EDITOR
        folderPath = Path.Combine(Application.dataPath, "..","SaveData");
#else
        folderPath = Application.persistentDataPath;

#endif

        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);

        }
        return folderPath;

    }
    public static void SaveByJson(string fileName,object data)
    {
        
        var json = JsonUtility.ToJson(data);
        //开发阶段使用Application.dataPath而打包为成品之前应当使用Application.persistentdataPath
        var folderPath = GetSaveFolderPath();
        var path = Path.Combine(folderPath, fileName);
        File.WriteAllText(path,json);

    }
    //泛型函数，一个很不错的思维，避免了每次调用时强制转换类型的隐患，也更方便。这也揭示了<>的本质，比如GetComponent的<>就是这样的用法，相当于填充占位符（<>传的是类型参数）
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(GetSaveFolderPath(), saveFileName);
        if(!File.Exists(path))
        {
            Debug.LogWarning($"找不到存档文件: {path}");
            return default(T);
        }
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<T>(json);
        return data;
    }

    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(GetSaveFolderPath(), saveFileName);
        if (!File.Exists(path))
        {
            Debug.LogWarning($"找不到存档文件: {path}");
        }
        File.Delete(path);
    }


}
