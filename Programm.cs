using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

public class Programm : MonoBehaviour
{
    double db;
    InputField input;
    Button rechnen;
    Button newwindow;
    Button back;
    Text ergebnisT;
    Text umrechner;
    Camera cam2;
    Camera maincam;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newwin = GameObject.Find("NewWindow");
        newwindow = newwin.GetComponent<Button>();
        var umrech = GameObject.Find("Umrechner");
        umrechner = umrech.GetComponent<Text>();
        var outpu = GameObject.Find("Ergebnis");
        ergebnisT = outpu.GetComponent<Text>();
        var inpu = GameObject.Find("Input");
        input = inpu.GetComponent<InputField>();
        var go = GameObject.Find("Button");
        rechnen = go.GetComponent<Button>();
        var cam = GameObject.Find("RespawnCamera");
        cam2 = cam.GetComponent<Camera>();
        var cam1 = GameObject.Find("Main Camera");
        maincam = cam1.GetComponent<Camera>();
        var ba = GameObject.Find("back");
        back = ba.GetComponent<Button>();

        if (!rechnen.interactable)
        {
            button1_Click();
            rechnen.interactable = true;
        }
        if (!newwindow.interactable)
        {
            cam2.enabled = true;
            newwindow.interactable = true;
        }
        if (!back.interactable)
        {
            cam2.enabled = false;
            back.interactable = true;
        }
    }

    private void button1_Click()
    {
        double ergebnis;
        string dämpfung = input.text;

        try
        {
            db = Int32.Parse(dämpfung);
            db = -db;
        }
        catch
        {
            
        }

        if (rechnen)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            List<string> sl = new List<string>();



            ergebnis = Math.Pow(10, (db / 10));
            string ergebnisTextmW;

            ergebnisTextmW = ergebnis.ToString("e4", CultureInfo.InvariantCulture);
            string ergebnisTextµW = (ergebnis * 1000).ToString("e4", CultureInfo.InvariantCulture);
            string ergebnisTextnW = (ergebnis * 1000000).ToString("e4", CultureInfo.InvariantCulture);
            string ergebnisTextpW = (ergebnis * 1000000000).ToString("e4", CultureInfo.InvariantCulture);
            sb1.Append(ergebnisTextmW + "mW\r\n");
            sb1.Append(ergebnisTextµW + "µW\r\n");
            sb1.Append(ergebnisTextnW + "nW\r\n");
            sb1.Append(ergebnisTextpW + "pW\r\n");


            umrechner.text = sb1.ToString();


            sb.Append("Signalstärke ist " + db.ToString() + "dBm\r\n");
            sb.Append("\r\n");
            sb.Append("Da der Leistungspegel 10 lag (P/P Ref) ist \r\n");
            sb.Append("und P Ref 1mW ist, ergibt sich daraus die Formel:\r\n");
            sb.Append("\r\n");
            sb.Append("10^" + db + "*1/10 = " + ergebnisTextmW + "\r\n");

            ergebnisT.text = sb.ToString();

        }
    }
}




