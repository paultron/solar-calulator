using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Calc1 : MonoBehaviour {

    int billInt;
    int kwhInt;
    double kwhDoub;
    double kwhDoubDaily;
    double kwhDoubPeak;
    double NumPanels;
    double PanelCost;
    public bool isPaperBill;
    int totalSpent;
    public Text InputText;
    public Text kwhNeed;
    public Text result;
    public Text estimatedCost;

    IEnumerator Calculate()
    {
        //calculate total spent, decide if paper or kwh
        if (isPaperBill)
        {
            //get input value monthly bill
            int.TryParse(InputText.text, out billInt);
            //print result of 15 and 30 year sums
            result.text = ("$" + billInt * 12 * 15 + " spent over 15 year(s). $" + billInt * 12 * 30 + " spent over 30 year(s).");
            //estimate monthly kwh usage
            kwhDoub = (billInt/.12125);
            //estimate daily kwh usage
            kwhDoubDaily = kwhDoub/30;
            //estimate required kwh during peak sun hours
            kwhDoubPeak = kwhDoubDaily / 5.5;
            kwhNeed.text = (((int)kwhDoubPeak).ToString() + "kWh needed during peak sun hours.");
            //number of panels at 260W
            NumPanels = kwhDoubPeak / .260;
            //panel cost * 1.25
            PanelCost = (NumPanels * 250) * 1.25;
            estimatedCost.text = ("$" + ((int)PanelCost).ToString() + " estimated cost.");
            yield return new WaitForEndOfFrame();
        }
        if (!isPaperBill)
        {
            //get input value monthly kWh 
            double tempDoub;
            int.TryParse(InputText.text, out kwhInt);
            //estimate daily kwh usage
            kwhDoubDaily = kwhInt / 30;
            //estimate required kwh during peak sun hours
            kwhDoubPeak = kwhDoubDaily / 5.5;
            kwhNeed.text = (((int)kwhDoubPeak).ToString() + "kWh needed during peak sun hours.");
            //number of panels at 260W
            NumPanels = kwhDoubPeak / .260;
            //panel cost * 1.25
            PanelCost = (NumPanels * 250) * 1.25;
            estimatedCost.text = ("$" + ((int)PanelCost).ToString() + " estimated cost.");
            if(kwhInt > 600)
            {
                tempDoub = (kwhInt - 600)*.1399;
                kwhInt = (int)tempDoub+70;
            }
            else
            {
                tempDoub = kwhInt * .11;
                kwhInt = (int)tempDoub;
            }
            //print result of 15 and 30 year sums
            result.text = ("$" + kwhInt * 12 * 15 + " spent over 15 year(s). $" + kwhInt * 12 * 30 + " spent over 30 year(s).");
            yield return new WaitForEndOfFrame();
        }




    }

    public void OnEnable ()
    {
        StartCoroutine(Calculate());
    }
    public void SetPaperTrue()
    {
        isPaperBill = true;
    }
    public void SetPaperFalse()
    {
        isPaperBill = false;
    }
}
