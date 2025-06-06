using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Saver
{
    private const string FileName = "PlayerSave";
    private const string SaveFileExtension = ".json";

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

    public bool TryLoad(out PlayerData playerData)
    {
        if (IsDataAlreadyExist() == false)
        {  
            playerData = null;
            return false;
        }

        playerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
        return true;
    }

    public void Save(PlayerData player)
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(player, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));
    }

    private bool IsDataAlreadyExist() => File.Exists(FileName);
}
