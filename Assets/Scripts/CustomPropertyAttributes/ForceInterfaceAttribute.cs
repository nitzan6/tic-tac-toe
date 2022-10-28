using System;
using UnityEngine;

public class ForceInterfaceAttribute : PropertyAttribute
{
    public readonly Type InterfaceType;

    public ForceInterfaceAttribute(Type interfaceType)
    {
        InterfaceType = interfaceType;
    }
}
