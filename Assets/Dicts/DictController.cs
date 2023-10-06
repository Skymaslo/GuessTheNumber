using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictController : MonoBehaviour
{
    public Text RusText;
    public Text EngText;
    public Text Translation;
    public InputField DeleteWord;
    public InputField EngWord;
    public InputField RusWord;
    public InputField GetWordField; 
    public TogglesLang togglesLang;
    private Dictionary<string, string> dict;
    // Start is called before the first frame update
    void Start()
    {
        dict = new Dictionary<string, string>();

        dict.Add("Кот", "Cat");
        dict.Add("Планшет", "Tablet");
        dict.Add("Клавиатура", "Keyboard");

        foreach(var el in dict)
        {
            //print($"Key: {el.Key}");
            //print($"Value: {el.Value}");
        }
        countWords();
        RenderDict();
        
    }
    public void countWords()
    {
        int countRus = 0;
        int countEng = 0;
        foreach (var el in dict)
        {
             string wordsKey =  el.Key;
             string wordsValue = el.Value;
            if (wordsKey[0] == 'А')
            {
                countRus += 1;
            }
            if (wordsValue[0] == 'K')
            {
                countEng += 1;
            }
        }
        //print(countRus);
        //print(countEng);
        
    }

    public void RenderDict()
    {
        RusText.text = "";
        EngText.text = "";
        foreach (var el in dict)
        {
            RusText.text += el.Key + "\n";
            EngText.text += el.Value + "\n";
        }
    }

    public void NewWords()
    {
        dict.Add(EngWord.text, RusWord.text);
        RenderDict();
    }
    

    public void RemoveWord()
    {
        string word = DeleteWord.text;
        dict.Remove(word);
        RenderDict();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Translate()
    {
        bool engToRus = togglesLang.toggleEnToRus.isOn;
        string word = GetWordField.text;
        if (engToRus)
        {
            EngToRus(word);
        }
        else
        {
            RusToEng(word);
        }

    }

    

    public void EngToRus(string eng)
    {

        string rus = "";


        foreach (var el in dict)
        {
            
            if(el.Value == eng)
            {
                rus = el.Key;
                print(el.Key);
                
            }
        }

        if (rus != "")
        {
            print(rus);
            Translation.text = rus;
        }
        else
        {
            Translation.text = "Такого слова нет";
        }

    }

    public void RusToEng(string rus)
    {

       
        if (dict.ContainsKey(rus))
        {
            string result = dict[rus];
            print(result);
            Translation.text = result;

        }
        else
        {
            Translation.text = "Такого слова нет";
        }
    }
}
