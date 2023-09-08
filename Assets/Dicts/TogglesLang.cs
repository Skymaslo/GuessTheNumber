using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TogglesLang : MonoBehaviour
{
    public Toggle toggleEnToRus;
    public Toggle toggleRusToEng;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EngToRusOn()
    {
        if(toggleRusToEng.isOn != true || toggleEnToRus.isOn != false)
        {
            toggleEnToRus.isOn = true;
            toggleRusToEng.isOn = false;
        }
        
        
    }
    public void RusToEng()
    {
        if (toggleRusToEng.isOn != false  || toggleEnToRus.isOn != true)
        {
            toggleEnToRus.isOn = false;
            toggleRusToEng.isOn = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
