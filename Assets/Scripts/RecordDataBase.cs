    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordDataBase : MonoBehaviour
{

    public Dictionary<string, int> records = new Dictionary<string, int>();


    // Start is called before the first frame update
    void Start()
    {
        
        SaveRecord();
        LoadRecord();
    }
    public void SaveRecord()
    {
        string strToSave = "";
        foreach (KeyValuePair<string, int> record in records)
        {
            string recordString = $"{record.Key}:{record.Value};";
            strToSave += recordString;
        }
        PlayerPrefs.SetString("RecordDB", strToSave);
    }

    public void LoadRecord()
    {
        string recordsString = PlayerPrefs.GetString("RecordDB");
        print(recordsString);
        records = new Dictionary<string, int>();

        int startIndex = 0;
        for(int i = 0; i < recordsString.Length; i++)
        {
            if (recordsString[i] == ';')
            {
                string playerData = recordsString.Substring(startIndex, i - startIndex);

                int sepIndex = playerData.IndexOf(':');
                string currentNick = playerData.Substring(0, sepIndex);
                int currentRecord = int.Parse(playerData.Substring(sepIndex + 1, playerData.Length - sepIndex - 1));
                startIndex = i + 1;
                print($"Игрок {currentNick}, Рекорд: {currentRecord}");
                records.Add(currentNick, currentRecord);
            }
        }
    }

    public void AddNewPlayer(string playerName)
    {
        if (!IsPlayerInDB(playerName))
        {
            records.Add(playerName, -1);
            PlayerPrefs.SetString("CurrentPlayer", playerName);
            PlayerPrefs.SetInt("record", -1);
            SaveRecord();

        }
    }

    private bool IsPlayerInDB(string playerName)
    {
        return records.ContainsKey(playerName);
    }


    public void SetNewRecords(string playerName, int record)
    {
        //задать и сохранить рекорд
    }

    public void SetCurrentPlayer(string playerName)
    {
        if (IsPlayerInDB(playerName))
        {
            PlayerPrefs.SetString("CurrentPlayer", playerName);
                PlayerPrefs.SetInt("record", records[playerName]);
        }
        else
        {
            AddNewPlayer(playerName);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
