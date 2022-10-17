using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public GameManager GM;

    float acceleration = 0.1f; // ??? getting applied every frame?
    public Vector3 position; // in units
    Vector3 velocity; // in units/second
    int levelUpAmmount;

    [Header("text")]
    public TMP_Text xp;
    public TMP_Text level;
    public TMP_Text shield;
    public TMP_Text health;

    // Start is called before the first frame update
    void Start()
    {
        //set position
        position.x = 0;
        position.y = 1;
        position.z = -10;

        // set velocity
        velocity.x = 0;
        velocity.y = 0;
        velocity.z = 0;

        //set UI
        xp.text = "XP: " + GM.xp.ToString();
        level.text = "Level: " + GM.level.ToString();
        shield.text = "Shield: " + GM.shield.ToString();
        health.text = "Health: " + GM.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        ///reading/processing inupt
        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }

        // apply friction
        velocity *=  1f - (1.5f * Time.deltaTime);

        //apply velocity
        position += velocity * acceleration * Time.deltaTime;

        // only for unity --- .draw would already use ^
        gameObject.transform.position = position;

        UIControls();
    }

    void UIControls()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //save
            GM.SaveGame();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //load
            GM.Load();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //decrement health
            GM.shield -= 5;
            if (GM.shield <= 0)
            {
                GM.health += GM.shield;
                GM.shield = 0;
                if (GM.health <= 0)
                {
                    GM.health = 0;
                    GM.shield = 0;
                }
            }
            shield.text = "Shield: " + GM.shield.ToString();
            health.text = "Health: " + GM.health.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            //incriment xp
            GM.xp += 5;
            xp.text = "XP: " + GM.xp.ToString();
            if (GM.xp > levelUpAmmount)
            {
                GM.level++;
                levelUpAmmount += 15;
                level.text = "Level: " + GM.level.ToString();
            }
        }

    }
}
