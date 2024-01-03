using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
//class variables
    private Vector3     dragOffset;
    private Camera      cam;
    public  GameObject  kanaPosition01; //default kana location #1
    public  GameObject  kanaPosition02; //default kana location #2
    public  GameObject  kanaPosition03; //default kana location #3
    public  GameObject  kanaPosition04; //default kana location #4
    public  GameObject  kanaPosition05; //default kana location #5
    public  GameObject  soundPosition01; //default sound location #1
    public  GameObject  soundPosition02; //default sound location #2
    public  GameObject  soundPosition03; //default sound location #3
    public  GameObject  soundPosition04; //default sound location #4
    public  GameObject  soundPosition05; //default sound location #5

//class methods
    void Awake()
    {
        cam = Camera.main;
    }
    void OnMouseDown()
    {
        dragOffset = (transform.position) - (GetMousePos());
    }
    void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
    }
    void OnMouseUp()
    {
        //remembering where the sprites originally used to be
        Vector3 originalKanaPosition01  = new(-6.98f, 2.41f, 0.00f);
        Vector3 originalKanaPosition02  = new(-3.60f, 2.41f, 0.00f);
        Vector3 originalKanaPosition03  = new(0.00f, 2.41f, 0.00f);
        Vector3 originalKanaPosition04  = new(3.60f, 2.41f, 0.00f);
        Vector3 originalKanaPosition05  = new(6.98f, 2.41f, 0.00f);
        Vector3 originalSoundPosition01 = new(-6.98f, -2.41f, 0.00f);
        Vector3 originalSoundPosition02 = new(-3.60f, -2.41f, 0.00f);
        Vector3 originalSoundPosition03 = new(0.00f, -2.41f, 0.00f);
        Vector3 originalSoundPosition04 = new(3.60f, -2.41f, 0.00f);
        Vector3 originalSoundPosition05 = new(6.98f, -2.41f, 0.00f);

        CheckAnswer(soundPosition01, kanaPosition01, originalSoundPosition01, originalKanaPosition01);
        CheckAnswer(soundPosition01, kanaPosition02, originalSoundPosition01, originalKanaPosition02);
        CheckAnswer(soundPosition01, kanaPosition03, originalSoundPosition01, originalKanaPosition03);
        CheckAnswer(soundPosition01, kanaPosition04, originalSoundPosition01, originalKanaPosition04);
        CheckAnswer(soundPosition01, kanaPosition05, originalSoundPosition01, originalKanaPosition05);

        CheckAnswer(soundPosition02, kanaPosition01, originalSoundPosition02, originalKanaPosition01);
        CheckAnswer(soundPosition02, kanaPosition02, originalSoundPosition02, originalKanaPosition02);
        CheckAnswer(soundPosition02, kanaPosition03, originalSoundPosition02, originalKanaPosition03);
        CheckAnswer(soundPosition02, kanaPosition04, originalSoundPosition02, originalKanaPosition04);
        CheckAnswer(soundPosition02, kanaPosition05, originalSoundPosition02, originalKanaPosition05);

        CheckAnswer(soundPosition03, kanaPosition01, originalSoundPosition03, originalKanaPosition01);
        CheckAnswer(soundPosition03, kanaPosition02, originalSoundPosition03, originalKanaPosition02);
        CheckAnswer(soundPosition03, kanaPosition03, originalSoundPosition03, originalKanaPosition03);
        CheckAnswer(soundPosition03, kanaPosition04, originalSoundPosition03, originalKanaPosition04);
        CheckAnswer(soundPosition03, kanaPosition05, originalSoundPosition03, originalKanaPosition05);

        CheckAnswer(soundPosition04, kanaPosition01, originalSoundPosition04, originalKanaPosition01);
        CheckAnswer(soundPosition04, kanaPosition02, originalSoundPosition04, originalKanaPosition02);
        CheckAnswer(soundPosition04, kanaPosition03, originalSoundPosition04, originalKanaPosition03);
        CheckAnswer(soundPosition04, kanaPosition04, originalSoundPosition04, originalKanaPosition04);
        CheckAnswer(soundPosition04, kanaPosition05, originalSoundPosition04, originalKanaPosition05);

        CheckAnswer(soundPosition05, kanaPosition01, originalSoundPosition05, originalKanaPosition01);
        CheckAnswer(soundPosition05, kanaPosition02, originalSoundPosition05, originalKanaPosition02);
        CheckAnswer(soundPosition05, kanaPosition03, originalSoundPosition05, originalKanaPosition03);
        CheckAnswer(soundPosition05, kanaPosition04, originalSoundPosition05, originalKanaPosition04);
        CheckAnswer(soundPosition05, kanaPosition05, originalSoundPosition05, originalKanaPosition05);
    }
    public void CheckAnswer(GameObject firstSprite, GameObject secondSprite, Vector3 originalLocation01, Vector3 originalLocation02)
    {
        if (Vector3.Distance(firstSprite.transform.position, secondSprite.transform.position) < .6)
        {
            if (firstSprite.GetComponent<AudioSource>().clip.name == secondSprite.GetComponent<SpriteRenderer>().sprite.name)
            {
                firstSprite.SetActive(false);   //hides the sound sprite
                secondSprite.SetActive(false);  //hides the kana sprite
                
            }
            else
            {
                firstSprite.transform.position = originalLocation01;    //returns the sound sprite to where it was
                secondSprite.transform.position = originalLocation02;   //returns the kana sprite to where it was
            }
        }
    }
    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
