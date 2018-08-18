using ScriptableObjectFramework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOGuiText : MonoBehaviour
{
    public TextMeshProUGUI Target;
    public BaseVariable Value;
    public StringValue Format;

    void Start()
    {
        if (Target == null)
        {
            Target = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        Target.text = Format == null ? Value.GetValue().ToString() : string.Format(Format, Value.GetValue());
    }
}
