using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FlagNamesForStupidEvents : MonoBehaviour
{
[SerializeField] public FlagNameAndInt changeFlag;
}
[Serializable]
public struct FlagNameAndInt
{
    public FlagNames flagNames;
    public int flagNum;
}