using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ----------------------------------- levels ---------------------------- \\
    public void SceneOne()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SceneTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void SceneThree()
    {
        SceneManager.LoadScene("Level3");
    }
}
