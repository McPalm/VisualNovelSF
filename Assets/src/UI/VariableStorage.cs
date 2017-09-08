using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class VariableStorage : VariableStorageBehaviour
{
    Dictionary<string, float> dictionary = new Dictionary<string, float>();

    /// Not implemented here
    public override void SetNumber(string variableName, float number)
    {
        if (dictionary.ContainsKey(variableName))
            dictionary.Remove(variableName);
        dictionary.Add(variableName, number);
    }

    /// Not implemented here
    public override float GetNumber(string variableName)
    {
        float f = 0f;
        dictionary.TryGetValue(variableName, out f);
        return 0f;
    }

    /// Not implemented here
    public override void Clear()
    {
        // nope
    }

    public override void ResetToDefaults()
    {
        // empty
    }

}
