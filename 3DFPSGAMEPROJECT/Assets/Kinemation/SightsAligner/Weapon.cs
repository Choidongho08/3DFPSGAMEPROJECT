using Kinemation.SightsAligner;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GunAimData gunAimData;

    [SerializeField] private List<Transform> scopes;
    private int _scopeIndex;

    public Transform GetScope()
    {
        return scopes[_scopeIndex]; 
    }
}
