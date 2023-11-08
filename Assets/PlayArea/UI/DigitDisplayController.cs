using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DigitDisplayController : MonoBehaviour {
    public List<DigitController> digitControllers = new List<DigitController>(); //order from left to right
    public void setValue(int val)
    {
        for (int i = digitControllers.Count() - 1; i >= 0; i--)
        {
            int digit = val % 10;
            digitControllers[i].UpdateDigit(digit);
            val /= 10;
        }
    }
}
