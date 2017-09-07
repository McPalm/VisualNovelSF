using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintingText : MonoBehaviour
{
    public Color unPrinted;

    public float lettersPerSecond = 12f;

    public Text textBox;

    // Use this for initialization
    void Start ()
    {
        PrintText("Hello world!" +
            "\nThis is a test text. It should be reasonably wordy just so we can se it print out slowly and neatly.");
    }

    public void PrintText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(PrintTextCooroutine(text));
    }

    IEnumerator PrintTextCooroutine(string text)
    {
        textBox.text = ""; // clear
        yield return null; // wait for next frame, this it to wait for loading lag before starting the print

        float projectedTime = text.Length / lettersPerSecond;
        for(float f = 0f; f < projectedTime; f += Time.deltaTime)
        {
           int  i = (int)(f * lettersPerSecond);

            textBox.text =
                text.Substring(0, i) +
                "<b>" + text.Substring(i, 1) + "</b>" +
                "<color=" + RichColor(unPrinted) + ">" +
                text.Substring(i+1) +
                "</color>";
            yield return null;
        }
        textBox.text = text;
    }
    

    string RichColor(Color c)
    {
        //  return new string("#" + (c.r.ToString("X2"))
        return "#" + HexValue256(c.r) + HexValue256(c.g) + HexValue256(c.b) + HexValue256(c.a);
    }

    string HexValue256(float f)
    {
        if (f == 1f) return "FF";
        return ((int)(f * 256f)).ToString("X2");
    }
}
