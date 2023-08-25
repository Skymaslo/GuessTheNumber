using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputField guessInput;
    private int attemptGuess  = 0;
    private int attemptWish = 0;
    private int record = int.MaxValue - 1;
    public Text PCInputTextUI;
    public Text attemptWishTextUI;
    public Text attemptTextUI;
    public Text recordTextUI;
    public Transform RecordPosition;
    public GameObject RecordTip;
    public GameObject tip;
    public GameObject PCLosePanel;
    public Transform tipPosition;
    private int l = 0;
    private int r = 100;
    private int current;
    public GameObject guessBackGround;
    public GameObject makeBackGround;

    private string mode = "Угадай";
    private int guessNumber;
    private string currentMode;
    // Start is called before the first frame update
    void Start()
    {
        currentMode = PlayerPrefs.GetString("mode", "Угадай");


        if (!PlayerPrefs.HasKey("record"))
        {
            recordTextUI.text = "Рекорд -1";
        }
        else
        {
            record = PlayerPrefs.GetInt("record");
            recordTextUI.text = "Рекорд: " + record.ToString();
        }

        record = PlayerPrefs.GetInt("record", int.MaxValue);
        
        recordTextUI.text = "Рекорд: " + record.ToString();
        switch (currentMode)
        {
            case "Угадай":
                guessBackGround.SetActive(true);
                break;
            case "Загадай":
                makeBackGround.SetActive(true);
                break;


        }

        guessNumber = Random.Range(1, 101);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void SpawnTip(string value) // value = Больше или меньше 
    {
        GameObject newTip = Instantiate(tip, tipPosition);
        Text newTipText = newTip.GetComponentInChildren<Text>();
        newTipText.text = value; 
        Destroy(newTip, 2);

    }
    private void SpawnWin()  
    {
        SpawnTip("Победа");
    }

    private void SpawnNewRecord()
    {
        PlayerPrefs.SetInt("record", record);
        GameObject newRecordTip = Instantiate(RecordTip, RecordPosition);
        Destroy(newRecordTip, 3);
    }

    public void GuessRound()
    {
        int inputNumber = int.Parse(guessInput.text);

        attemptGuess += 1;
        attemptTextUI.text = "Попытки: " + attemptGuess.ToString();
        if (guessNumber > inputNumber)
        {
            print(attemptGuess);
            SpawnTip("Больше");
        }
        else if (guessNumber < inputNumber)
        {
            print(attemptGuess);
            SpawnTip("Меньше");
        }
        else
        {
            if (record > attemptGuess)
            {
                print("Новый рекорд!");
                record = attemptGuess;
                recordTextUI.text = "Рекорд: " + record.ToString();
                SpawnNewRecord();
                
            }

            print("Ура, победа");
            print("Угадай новое число");
            guessNumber = Random.Range(1, 101);
            attemptGuess = 0;
            SpawnWin();
        }
    }

    public void WishRound(int mode)
    {
        
        attemptWish += 1;
        attemptWishTextUI.text = "Попытки: " + attemptWish.ToString();
        print(attemptWish);
        
        switch (mode)
        {
            case 0:
                l = 0;
                r = 100;
                break;
            case 1:
                l = current;

                break;
            case -1:
                r = current;

                break;
            default:

                break;
        }

        current = (l + r) / 2;

        if(r - l <= 1)
        {
            PCLosePanel.SetActive(true);
        }

        PCInputTextUI.text = current.ToString() + "?";
        

    }
}
