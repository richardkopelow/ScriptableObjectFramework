using ScriptableObjectFramework;
using ScriptableObjectFramework.Variables;
using System;
using UnityEngine;

[Serializable]
public class BoolValue : BaseValue<bool, BoolVariable> { }
[Serializable]
public class FloatValue : BaseValue<float, FloatVariable> { }
[Serializable]
public class GameObjectValue : BaseValue<GameObject, GameObjectVariable> { }
[Serializable]
public class IntValue : BaseValue<int, IntVariable> { }
[Serializable]
public class StringValue : BaseValue<string, StringVariable> { }
[Serializable]
public class Vector3Value : BaseValue<Vector3, Vector3Variable> { }