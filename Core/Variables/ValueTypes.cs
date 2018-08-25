using ScriptableObjectFramework;
using ScriptableObjectFramework.Variables;
using System;
using UnityEngine;

/// <summary>
/// The Value type for use with BoolVariables.
/// </summary>
[Serializable]
public class BoolValue : BaseValue<bool, BoolVariable> { }
/// <summary>
/// The Value type for use with FloatVariables.
/// </summary>
[Serializable]
public class FloatValue : BaseValue<float, FloatVariable> { }
/// <summary>
/// The Value type for use with GameObjectVariables.
/// </summary>
[Serializable]
public class GameObjectValue : BaseValue<GameObject, GameObjectVariable> { }
/// <summary>
/// The Value type for use with IntVariables.
/// </summary>
[Serializable]
public class IntValue : BaseValue<int, IntVariable> { }
/// <summary>
/// The Value type for use with StringVariables.
/// </summary>
[Serializable]
public class StringValue : BaseValue<string, StringVariable> { }
/// <summary>
/// The Value type for use with Vector3Variables.
/// </summary>
[Serializable]
public class Vector3Value : BaseValue<Vector3, Vector3Variable> { }