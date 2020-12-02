using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ValueType
{
    DAMAGE,
    HEAL,
    NONE
}

[System.Serializable]
public struct ValueMessage
{
    // Variable Declaration
    public ValueType Type;
    public int Value;
    
    // Constructor (Not Necessary But Helpful)
    public ValueMessage(ValueType _type, int _value)
    {
        Type = _type;
        Value = _value;
    }
}

public struct ObjectMessage
{
    // Variable Declaration
    public GameObject gameObject;

    public ObjectMessage(GameObject gameobject)
    {
        gameObject = gameobject;
    }
}

public struct UpgradeMessage
{
    // Variable Declaration
    public Upgrade upgradeType;
    public int value;

    // Constructor (Not Necessary But Helpful)
    public UpgradeMessage(Upgrade _type, int _value)
    {
        upgradeType = _type;
        value = _value;
    }
}