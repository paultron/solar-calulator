using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Calc1 : MonoBehaviour {

    public Text electricBill;
    public Text numYears;
    public Text result;
    public Slider yearSlider;
    public int totalSpent;
    public int billInt;
    public int yearsInt;

    IEnumerator Calculate()
    {
        yield return new WaitForEndOfFrame();
        int.TryParse(electricBill.text, out billInt);
        yearsInt = (int)yearSlider.value;
        numYears.text = ("" + yearsInt);
        totalSpent = billInt * 12 * yearsInt;
        print("$" + totalSpent + " spent over " + yearsInt + " year(s).");
        result.text = ("$" + totalSpent + " spent over " + yearsInt + " year(s).");
    }

    void OnEnable ()
    {
        StartCoroutine(Calculate());
    }
}
