using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    private Movement player;
    public GameObject UIManager;

    public float health = 100;
    public float xp = 0;
    public float score = 0;
    public float level = 0;
    //public Vector3 playerPos;
    public float shield = 100;
    //public string scene;

    private void Awake()
    {
       if (instance == null)
       {
            DontDestroyOnLoad(gameObject);
            instance = this;
       }
       else if (instance != this)
       {
            Destroy(gameObject);
       }
    }

    void Start()
    {
        player = GetComponent<Movement>();
    }

    void Update()
    {
        
    }

    public void SaveGame()
    {
        //Debug.Log("Saving Game at : " + Application.persistentDataPath + "/playerInfo.dat");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); //creates file path

        PlayerData data = new PlayerData(); // sets values for save file
        data.health = health;
        data.xp = xp;
        data.score = score;
        data.level = level;
        //data.playerPos = player.position;
        data.shield = shield;
        //data.scene = scene;

        bf.Serialize(file, data); // writes to file
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Debug.Log("Loading");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            xp = data.xp;
            score = data.score;
            level = data.level;
            //player.position = data.playerPos;
            shield = data.shield;
            //scene = data.scene;
        }
    }

    [Serializable]
    class PlayerData
    {
        public float health;
        public float xp;
        public float score;
        public float level;
       // public Vector3 playerPos;
        public float shield;
       // public string scene;
    }
}
