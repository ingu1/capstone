using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputscr : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField myInputField;
    private void Start()
    {
        myInputField.onEndEdit.AddListener(ValueChanged);
    }
    void ValueChanged(string text)
    {
        Debug.Log(text + "를 입력함");
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
