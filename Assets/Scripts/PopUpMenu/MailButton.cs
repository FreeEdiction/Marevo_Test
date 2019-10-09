using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailButton : MonoBehaviour
{
    public void Send()
    {
        SendEmail();
    }
    
    void SendEmail ()
    {
        string email = "vb@marevo.vision";
        string subject = MyEscapeURL("Marevo test");
        string body = MyEscapeURL("Test my app");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    string MyEscapeURL (string url)
    {
        return WWW.EscapeURL(url).Replace("+","%20");
    }
}
