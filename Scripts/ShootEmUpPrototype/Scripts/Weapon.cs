using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
}

[System.Serializable]

public class WeaponStats
{
    public float damage, speed, range, rate, cooldown, amount, duration;
}