using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework
{
    [CustomEditor(typeof(BaseEventBacking), true, isFallback = true)]
    public class BaseEventInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fire"))
            {
                ((BaseEventBacking)target).SelfFire();
            }
        }
    }
}
