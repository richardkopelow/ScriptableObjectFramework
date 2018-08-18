using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOFiller : MonoBehaviour
{
    public Image Target;
    public FloatValue Value;
    public FloatValue Max;
    public FloatValue Min;

    void Start()
    {
        if (Target == null)
        {
            Target = GetComponent<Image>();
        }
    }
    
    void Update()
    {
        Target.fillAmount = (Value - Min) / (Max - Min);
    }
}
