using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float health = 100f;
    public int gold = 0;
    public Vector3 currentPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavePlayer(string saveFileName)
    {
        PlayerData data = new PlayerData();
        data.health = this.health;
        data.gold = this.gold;
        data.position = this.transform.position;
        data.level = 1; // 举例
        SaveSystem.SaveByJson(saveFileName, data);
    }
    public void LoadPlayer(string saveFileName)
    {
        PlayerData data = SaveSystem.LoadFromJson<PlayerData>(saveFileName);
        if (data != null)
        {
            this.health = data.health;
            this.gold = data.gold;
            this.transform.position = data.position;
        }
        else
        {
            Debug.Log("没有找到存档，可能是第一次玩游戏！");
        }
    }
}
