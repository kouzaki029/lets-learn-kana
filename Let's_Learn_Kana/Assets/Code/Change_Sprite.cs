using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Sprite : MonoBehaviour
{
// class variables
    public SpriteRenderer oldSprite;
    public Sprite newSprite;

// class methods
    void ChangeSprite()
    {
        oldSprite.sprite = newSprite;
    }
    void Start() // Start is called before the first frame update
    {}   
    void Update() // Update is called once per frame
    {
        ChangeSprite();
    }
}
