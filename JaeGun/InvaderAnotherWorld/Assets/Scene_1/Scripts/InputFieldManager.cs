using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{

    [SerializeField]
    private InputField PassWordInputField;
    [SerializeField]
    private InputField SecondPassWordInputField;

    [SerializeField]
    private InputField EmailInputField;

    [SerializeField]
    private Text ErrorText;

    private string text;
    private void Start()
    {
        ErrorText.text = "";
        text = "";
    }
    public void OnChangePassWordValue()
    {
        text = PassWordInputField.text;
 
        if (!Regex.IsMatch(text, @"(?=.*\d).{6,12}"))
        {
            ErrorText.text = "비밀번호는 6~12자리 미만으로 해주세요";
        }
        else
        {
            ErrorText.text = "";
        }

    }
    public void OnCheckSecondPassword()
    {
        text = SecondPassWordInputField.text;
        if(!PassWordInputField.text.Equals(SecondPassWordInputField.text))
        {
            ErrorText.text = "비밀번호가 일치하지 않습니다!";
        }   
        else
        {
            ErrorText.text = "";
        }
    }
    public void OnChangeEmailValue()
    {
        text = EmailInputField.text;
        if (!Regex.IsMatch(text, @"@*\.com"))
        {
            ErrorText.text = "@ 또는 .com이 빠져있습니다!";
        }
          else
            ErrorText.text = "";
    }
}
