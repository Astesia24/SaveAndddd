using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int level;
    public float health;
    public int gold;
    public Vector3 position; // Unity 的 Vector3 是支持序列化的
    public string playerName;

}
