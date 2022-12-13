using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int next = 1;

    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeCharacter()
    {
        spriteRenderer.sprite = sprites[next];
        next++;
        if (next == sprites.Length) next = 0;
    }
}
