using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager GM;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // ----------------------------------- levels ---------------------------- \\
    public void SceneOne()
    {
        SceneManager.LoadScene("SampleScene");
        GM.scene = "SampleScene";
    }

    public void SceneTwo()
    {
        SceneManager.LoadScene("Level2");
        GM.scene = "Level2";
    }

    public void SceneThree()
    {
        SceneManager.LoadScene("Level3");
        GM.scene = "Level3";
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(GM.scene);
    }
}
