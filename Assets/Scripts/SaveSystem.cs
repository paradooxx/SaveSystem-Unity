using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string path = Application.persistentDataPath + "/GameData.json";

    public static void SaveData(GameDataManager gameDataManager)
    {
        GameSaveData gameSaveData = new GameSaveData(gameDataManager);
        string json = JsonUtility.ToJson(gameSaveData, true);

        string encryptedJson = EncryptionUtility.Encrypt(json);

        File.WriteAllText(path, encryptedJson);
    }

    public static GameSaveData LoadData()
    {
        if(File.Exists(path))
        {
            try
            {
                string encryptedJson = File.ReadAllText(path);
                string decryptedJson = EncryptionUtility.Decrypt(encryptedJson);
                GameSaveData gameSaveData = JsonUtility.FromJson<GameSaveData>(decryptedJson);
                return gameSaveData;
            }
            catch(Exception ex)
            {
                Debug.LogWarning("Save file is corrupted or decryption failed. Deleting save file.");
                Debug.LogError(ex.Message);
                File.Delete(path);
            }
        }
        else
        {
            Debug.LogError("Save File Not Found");
        }
        return null;
    }

    public static void DeleteSaveData()
    {
        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
                Debug.Log("Save file deleted successfully.");
                Debug.Log(path);
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed to delete save file: " + ex.Message);
            }
        }
        else
        {
           Debug.LogWarning("Save file not found, nothing to delete.");
        }
    }
}
