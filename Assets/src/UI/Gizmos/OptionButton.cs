using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// You know, its not the most elegant or generic of sollutions, but idgaf. It works, its easy.
/// </summary>

[RequireComponent(typeof(Button))]
public class OptionButton : MonoBehaviour
{
    int value;
    System.Action<int> callback;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Press);
    }

    public void Setup(int i, string t, System.Action<int> onPressCall)
    {
        value = i;
        GetComponentInChildren<Text>().text = t;
        callback = onPressCall;
        gameObject.SetActive(true);
    }

    void Press()
    {
        callback(value);
    }
}
