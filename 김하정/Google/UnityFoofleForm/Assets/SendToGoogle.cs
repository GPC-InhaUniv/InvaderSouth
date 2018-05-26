using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour {

    public GameObject username;
    public GameObject emaill;
    public GameObject phone;

    private string Name;
    private string Email;
    private string Phone;
    
    [SerializeField]
    private string Base_URL = "https://docs.google.com/forms/d/e/1FAIpQLSc1XxygWh_ccFISxiFksiiyd_b551AjQeY4urdb6WW0VrBuQA/formResponse";


    IEnumerator Post(string name, string email, string phone)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.50573501", name);
        form.AddField("entry.1154582386", email);
        form.AddField("entry.1231963803", phone);
        byte[] rawData = form.data;
        WWW www = new WWW(Base_URL, rawData);
        yield return www;
    }



    public void Send()
    {
        Name = username.GetComponent<InputField>().text;
        Email = emaill.GetComponent<InputField>().text;
        Phone = phone.GetComponent<InputField>().text;

        StartCoroutine(Post(Name, Email, Phone));

    }
      
	 
}
