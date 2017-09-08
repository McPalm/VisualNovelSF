using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class YarnDialogueAdaptor : DialogueUIBehaviour
{
    [SerializeField]
    PrintingText printingText;

    [SerializeField]
    GameObject showWhileWaiting; // Assumedly the next button.
    [SerializeField]
    OptionButton[] optionButtons;

    bool waiting;
    int selected = -1;

    [SerializeField]

    public override IEnumerator RunCommand(Command command)
    {
        Debug.Log("Commands not Supported!");
        yield break;
    }

    public override IEnumerator RunLine(Line line)
    {
        printingText.PrintText(line.text);
        while (printingText.IsPrinting) yield return null;
        yield return WaitForPrompt();
    }

    public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
    {
        for(int i = 0; i < optionsCollection.options.Count; i++)
        {
            optionButtons[i].Setup(i, optionsCollection.options[i], SelectOption);
        }
        selected = -1;
        while (selected == -1) yield return null; // wait for an option to be selected
        optionChooser(selected);
        foreach (OptionButton b in optionButtons)
            b.gameObject.SetActive(false);
    }
    
    public void Next()
    {
        waiting = false;
    }

    public void SelectOption(int i)
    {
        selected = i;
    }

    IEnumerator WaitForPrompt()
    {
        waiting = true;
        if(showWhileWaiting) showWhileWaiting.SetActive(true);
        while (waiting) yield return null;
        if (showWhileWaiting) showWhileWaiting.SetActive(false);
    }
}
