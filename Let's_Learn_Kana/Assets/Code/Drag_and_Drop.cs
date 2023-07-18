using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
//class variables
    private Vector3 dragOffset;
    private Camera cam;
    public GameObject kanaPosition01; //default kana location #1
    public GameObject kanaPosition02; //default kana location #2
    public GameObject kanaPosition03; //default kana location #3
    public GameObject kanaPosition04; //default kana location #4
    public GameObject kanaPosition05; //default kana location #5
    public GameObject soundPosition01; //default sound location #1
    public GameObject soundPosition02; //default sound location #2
    public GameObject soundPosition03; //default sound location #3
    public GameObject soundPosition04; //default sound location #4
    public GameObject soundPosition05; //default sound location #5

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
        Vector3 originalKanaPosition01 = new(-6.98f, 2.41f, 0.00f);
        Vector3 originalKanaPosition02 = new(-3.60f, 2.41f, 0.00f);
        Vector3 originalKanaPosition03 = new(0.00f, 2.41f, 0.00f);
        Vector3 originalKanaPosition04 = new(3.60f, 2.41f, 0.00f);
        Vector3 originalKanaPosition05 = new(6.98f, 2.41f, 0.00f);
        Vector3 originalSoundPosition01 = new(-6.98f, -2.41f, 0.00f);
        Vector3 originalSoundPosition02 = new(-3.60f, -2.41f, 0.00f);
        Vector3 originalSoundPosition03 = new(0.00f, -2.41f, 0.00f);
        Vector3 originalSoundPosition04 = new(3.60f, -2.41f, 0.00f);
        Vector3 originalSoundPosition05 = new(6.98f, -2.41f, 0.00f);

        CheckAnswer(soundPosition01, kanaPosition01, originalSoundPosition01, originalKanaPosition01);

    }
    public void CheckAnswer(GameObject firstSprite, GameObject secondSprite, Vector3 originalLocation01, Vector3 originalLocation02)
    {
        if (Vector3.Distance(firstSprite.transform.position, secondSprite.transform.position) < .3)
        {
            if (firstSprite.GetComponent<AudioSource>().clip.name == secondSprite.GetComponent<SpriteRenderer>().sprite.name)
            {
                firstSprite.SetActive(false); //hides soundPoisition01?
                secondSprite.SetActive(false);
            }
            else
            {
                firstSprite.transform.position = originalLocation01;
                secondSprite.transform.position = originalLocation02;
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
