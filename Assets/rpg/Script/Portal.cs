using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    protected override void OnCollide(Collider2D collision)
    {
        //GameManager.instance.ShowText();
        if(collision.name == "Player")
        {
            GameManager.instance.SaveState();
            SceneManager.LoadScene("rpg");
        }
    }
}
