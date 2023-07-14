using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_Of_Kana : MonoBehaviour
{
//class variables
    public GameObject kanaPosition01;
    public GameObject kanaPosition02;
    public GameObject kanaPosition03;
    public GameObject kanaPosition04;
    public GameObject kanaPosition05;
    public GameObject soundPosition01;
    public GameObject soundPosition02;
    public GameObject soundPosition03;
    public GameObject soundPosition04;
    public GameObject soundPosition05;
    public List<Sprite> kanaList; //contains all of the kana sprites that are added in Unity, not Visual Studio
    public List<AudioClip> soundList; //conrains all of the kana sounds that are added in Unity, not Visual Studio

    //class methods
    public List<int> FiveUniqueRandomNumbers(int maximum)
    {
        List<int> fiveRandomNumbers = new List<int>();

        while (fiveRandomNumbers.Capacity < 5)
        {
            int min = 0;
            int max = maximum;

            int randomNumber = Random.Range(min, max); //chooses a random number from 0 to X

            if (!(fiveRandomNumbers.Contains(randomNumber))) //sees if the random number is NOT already inside the list
            {
                fiveRandomNumbers.Add(randomNumber); //add the random number to the list
                // fiveRandomNumber's capacity increases by 1
            }
            //else
            // if the random number is already inside the list, regenerate a new random number
        }
        return fiveRandomNumbers;
    }
    public void ChangeSprite(List<Sprite> theList, int listIndex, GameObject spritePosition)
    {
        SpriteRenderer oldSprite = spritePosition.GetComponent<SpriteRenderer>();
        Sprite newSprite = theList[listIndex]; //chooses a random sprite from the array
        oldSprite.sprite = newSprite;
    }
    public void ChangeSound(List<AudioClip> theList, int listIndex, GameObject spritePosition)
    {
        SpriteRenderer oldSprite = spritePosition.GetComponent<SpriteRenderer>();
        AudioClip newSound = theList[listIndex]; //chooses a random kana from the array
        oldSprite.GetComponent<AudioSource>().clip = newSound;
    }
    public void CreateKanaSprite() //uploads 5 random kana and their sounds to be shown in the game 
    {
        List<int> fiveRandomNumbers = FiveUniqueRandomNumbers(kanaList.Capacity); //chooses 5 random numbers between 0 and X

        int firstRandomNumber = fiveRandomNumbers[0];
        int secondRandomNumber = fiveRandomNumbers[1];
        int thirdRandomNumber = fiveRandomNumbers[2];
        int fourthRandomNumber = fiveRandomNumbers[3];
        int fifthRandomNumber = fiveRandomNumbers[4];

        //uploading the new kana sprites to Unity
        ChangeSprite(kanaList, firstRandomNumber, kanaPosition01);
        ChangeSprite(kanaList, secondRandomNumber, kanaPosition02);
        ChangeSprite(kanaList, thirdRandomNumber, kanaPosition03);
        ChangeSprite(kanaList, fourthRandomNumber, kanaPosition04);
        ChangeSprite(kanaList, fifthRandomNumber, kanaPosition05);

        //uploading the new kana sounds to Unity
        ChangeSound(soundList, firstRandomNumber, soundPosition01);
        ChangeSound(soundList, secondRandomNumber, soundPosition02);
        ChangeSound(soundList, thirdRandomNumber, soundPosition03);
        ChangeSound(soundList, fourthRandomNumber, soundPosition04);
        ChangeSound(soundList, fifthRandomNumber, soundPosition05);
    }
    void Start() //called before the first frame update
    {
        CreateKanaSprite();
    }
    void Update() //called once per frame
    {
    }
}
