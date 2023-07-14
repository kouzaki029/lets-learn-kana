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
    private Camera cam;
//class methods
    void Awake()
    {
        cam = Camera.main;
    }
    public List<int> FiveUniqueRandomNumbers()
    {
        List<int> fiveRandomNumbers = new List<int>();

        while (fiveRandomNumbers.Capacity < 5)
        {
            int min = 0;
            int max = kanaList.Capacity;

            int randomKana = Random.Range(min, max); //chooses a random number from 0 to X

            if (!(fiveRandomNumbers.Contains(randomKana))) //sees if the random number is NOT already inside the list
            {
                fiveRandomNumbers.Add(randomKana); //add the random number to the list
                // fiveRandomNumber's capacity increases by 1
            }
            //else
            // if the random number is already inside the list, regenerate a new random number
        }
        return fiveRandomNumbers;
    }
    public GameObject ChangeKanaSprite(List<Sprite> theList, int listIndex, GameObject spritePosition)
    {
        Sprite theSprite = theList[listIndex]; //chooses a random sprite from the array
        Vector3 defaulSpritePosition = spritePosition.transform.position; //copies sprite's position's and makes it the default position for the first sprite
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);  //default Quanternion

        GameObject newSprite = Instantiate(spritePosition, defaulSpritePosition, quaternion);
        newSprite.GetComponent<SpriteRenderer>().sprite = theSprite; //copies the image from chosen random sprite into the new sprite

        Destroy(spritePosition); //deletes the old game object

        return newSprite; //to keeps the spritePosition's position for future replacements
    }
    public void ChangeSound(List<AudioClip> theList, int listIndex, GameObject spritePosition)
    {
        AudioClip firstSoundSprite = theList[listIndex]; //chooses a random kana from the array
        Vector3 defaultSpritePosition = spritePosition.transform.position;
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);  //default Quanternion

        GameObject newSound = Instantiate(spritePosition, defaultSpritePosition, quaternion);
        newSound.GetComponent<AudioSource>().clip = firstSoundSprite; //copues the audio clip from the chosen random sound into the new sound sprite 

        Destroy(spritePosition); //deletes the old game object
    }
    public void CreateKanaSprite() //uploads 5 random kana to be shown in the game 
    {
        List<int> fiveRandomNumbers = FiveUniqueRandomNumbers();

        int firstRandomNumber = fiveRandomNumbers[0]; //chooses a random number between 0 and X
        int secondRandomNumber = fiveRandomNumbers[1]; //chooses a random number between 0 and X
        int thirdRandomNumber = fiveRandomNumbers[2]; //chooses a random number between 0 and X
        int fourthRandomNumber = fiveRandomNumbers[3]; //chooses a random number between 0 and X
        int fifthRandomNumber = fiveRandomNumbers[4]; //chooses a random number between 0 and X

        //uploading the new kana sprites to Unity
        kanaPosition01 = ChangeKanaSprite(kanaList, firstRandomNumber, kanaPosition01);
        kanaPosition02 = ChangeKanaSprite(kanaList, secondRandomNumber, kanaPosition02);
        kanaPosition03 = ChangeKanaSprite(kanaList, thirdRandomNumber, kanaPosition03);
        kanaPosition04 = ChangeKanaSprite(kanaList, fourthRandomNumber, kanaPosition04);
        kanaPosition05 = ChangeKanaSprite(kanaList, fifthRandomNumber, kanaPosition05);

        //uploading the new kana sounds to Unity
        ChangeSound(soundList, firstRandomNumber, soundPosition01);
        ChangeSound(soundList, secondRandomNumber, soundPosition02);
        ChangeSound(soundList, thirdRandomNumber, soundPosition03);
        ChangeSound(soundList, fourthRandomNumber, soundPosition04);
        ChangeSound(soundList, fifthRandomNumber, soundPosition05);
    }
    void Start() // Update is called once per frame 
    {
        CreateKanaSprite();
    }
}
