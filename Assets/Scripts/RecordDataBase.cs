    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordDataBase : MonoBehaviour
{

    public Dictionary<string, int> records = new Dictionary<string, int>();


    // Start is called before the first frame update
    void Start()
    {
        records.Add("Palyer1", 1);
        records.Add("Palyer2", 2);
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

        }
    }

    private bool IsPlayerInDB(string playerName)
    {
        
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
