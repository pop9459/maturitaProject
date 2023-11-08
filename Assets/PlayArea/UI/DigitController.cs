using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitController : MonoBehaviour
{
    public int numberToDisplay;
    GameObject[] digits = new GameObject[7];
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < digits.Length; i++)
        {
            digits[i] = transform.GetChild(i).gameObject;
        }   
    }

    public void UpdateDigit(int number)
    {
        numberToDisplay = number;
        switch(numberToDisplay)
        {
            case 0:
            {
                digits[0].SetActive(true);
                digits[1].SetActive(true);
                digits[2].SetActive(true);
                digits[3].SetActive(true);
                digits[4].SetActive(true);
                digits[5].SetActive(true);
                digits[6].SetActive(false);
                break;
            }
            case 1:
            {
                digits[0].SetActive(false);
                digits[1].SetActive(true);
                digits[2].SetActive(true);
                digits[3].SetActive(false);
                digits[4].SetActive(false);
                digits[5].SetActive(false);
                digits[6].SetActive(false);
                break;
            }
            case 2:
            {
                digits[0].SetActive(true);
                digits[1].SetActive(true);
                digits[2].SetActive(false);
                digits[3].SetActive(true);
                digits[4].SetActive(true);
                digits[5].SetActive(false);
                digits[6].SetActive(true);
                break;
            }
            case 3:
            {
                digits[0].SetActive(true);
                digits[1].SetActive(true);
                digits[2].SetActive(true);
                digits[3].SetActive(true);
                digits[4].SetActive(false);
                digits[5].SetActive(false);
                digits[6].SetActive(true);
                break;
            }
            case 4:
            {
                digits[0].SetActive(false);
                digits[1].SetActive(true);
                digits[2].SetActive(true);
                digits[3].SetActive(false);
                digits[4].SetActive(false);
                digits[5].SetActive(true);
                digits[6].SetActive(true);
                break;
            }
            case 5:
            {
                digits[0].SetActive(true);
                digits[1].SetActive(false);
                digits[2].SetActive(true);
                digits[3].SetActive(true);
                digits[4].SetActive(false);
                digits[5].SetActive(true);
                digits[6].SetActive(true);
                break;
            }
            case 6:
            {
                digits[0].SetActive(true);
                digits[1].SetActive(false);
                digits[2].SetActive(true);
                digits[3].SetActive(true);
                digits[4].SetActive(true);
                digits[5].SetActive(true);
                digits[6].SetActive(true);
                break;
            }
            case 7:
                {
                    digits[0].SetActive(true);
                    digits[1].SetActive(true);
                    digits[2].SetActive(true);
                    digits[3].SetActive(false);
                    digits[4].SetActive(false);
                    digits[5].SetActive(true);
                    digits[6].SetActive(false);
                    break;
                }
            case 8:
                {
                    digits[0].SetActive(true);
                    digits[1].SetActive(true);
                    digits[2].SetActive(true);
                    digits[3].SetActive(true);
                    digits[4].SetActive(true);
                    digits[5].SetActive(true);
                    digits[6].SetActive(true);
                    break;
                }
            case 9:
                {
                    digits[0].SetActive(true);
                    digits[1].SetActive(true);
                    digits[2].SetActive(true);
                    digits[3].SetActive(true);
                    digits[4].SetActive(false);
                    digits[5].SetActive(true);
                    digits[6].SetActive(true);
                    break;
                }
            default:
                Debug.Log("cannot display: " + numberToDisplay);
                break;
        }
    }
}
