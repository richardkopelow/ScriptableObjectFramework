using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableObjectFramework.Sets
{
    public class GameObjectSetRegisterer : SetRegisterer<GameObject, GameObjectRuntimeSet>
    {
        protected override void OnEnable()
        {
            foreach (var set in Sets)
            {
                set.Add(gameObject);
            }
        }

        protected override void OnDisable()
        {
            foreach (var set in Sets)
            {
                set.Remove(gameObject);
            }
        }
    }
}
