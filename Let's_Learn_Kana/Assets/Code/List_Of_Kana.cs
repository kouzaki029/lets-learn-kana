using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_Of_Kana : MonoBehaviour
{
//class variables
    public GameObject       kanaPosition01;     //default kana location #1
    public GameObject       kanaPosition02;     //default kana location #2
    public GameObject       kanaPosition03;      //default kana location #3
    public GameObject       kanaPosition04;     //default kana location #4
    public GameObject       kanaPosition05;     //default kana location #5
    public GameObject       soundPosition01;    //default sound location #1
    public GameObject       soundPosition02;    //default sound location #2
    public GameObject       soundPosition03;    //default sound location #3
    public GameObject       soundPosition04;    //default sound location #4
    public GameObject       soundPosition05;    //default sound location #5
    public List<Sprite>     kanaList;           //contains all of the kana sprites that are added in Unity, not Visual Studio
    public List<AudioClip>  soundList;          //conrains all of the kana sounds that are added in Unity, not Visual Studio

//class methods
    public List<int>    FiveUniqueRandomNumbers(int maximum) //chooses 5 unique random numbers between 0 and maximum (where maximum is also a possibe random number) 
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
                //fiveRandomNumber's capacity increases by 1
            }
            //
            //else
            //{
               //if the random number is already inside the list, regenerate a new random number
            //}
        }

        //Debug.Log("fiveRandomNumbers.Capacity " + fiveRandomNumbers.Capacity);
        //foreach (int i in fiveRandomNumbers)
        //{
        //    Debug.Log("Random number is " + i);
        //}
        //Debug.Log("\n");*/

        return fiveRandomNumbers;
    }
    public GameObject[] randomizeSpritePosition(GameObject spritePosition01, GameObject spritePosition02, GameObject spritePosition03, GameObject spritePosition04, GameObject spritePosition05)
    {
        //an array meant to contain all of the game object positions
        GameObject[]    spritePositions         = new GameObject[5];

        //selecting 5 unique random numbers between 0 and 4
        List<int>       fiveRandomNumbers       = FiveUniqueRandomNumbers(5); 
        int             firstRandomIndex        = fiveRandomNumbers[0]; //copying the first random number as the first random index
        int             secondRandomIndex       = fiveRandomNumbers[1]; //copying the second random number as the second random index
        int             thirdRandomIndex        = fiveRandomNumbers[2]; //copying the third random number as the third random index
        int             fourthRandomIndex       = fiveRandomNumbers[3]; //copying the fourth random number as the fourth random index
        int             fifthRandomIndex        = fiveRandomNumbers[4]; //copying the fifth random number as the fifth random index

        //assign the kana sounds randomly to the sprite positions
        spritePositions[firstRandomIndex]       = spritePosition01; //the first random index holds spritePosition01
        spritePositions[secondRandomIndex]      = spritePosition02; //the second random index holds spritePosition02
        spritePositions[thirdRandomIndex]       = spritePosition03; //the third random index holds spritePosition03
        spritePositions[fourthRandomIndex]      = spritePosition04; //the fourth random index holds spritePosition04
        spritePositions[fifthRandomIndex]       = spritePosition05; //the fifth random index holds spritePosition05

        return spritePositions;
    }
    public void         ChangeSprite(List<Sprite> theList, int listIndex, GameObject spritePosition)
    {
        SpriteRenderer  oldSprite               = spritePosition.GetComponent<SpriteRenderer>();
        Sprite          newSprite               = theList[listIndex]; //chooses a random sprite from the array

        //changing the old sprite to be the new sprite
        oldSprite.sprite = newSprite;
    }
    public void         ChangeSound(List<AudioClip> theList, int listIndex, GameObject spritePosition)
    {
        SpriteRenderer  oldSprite               = spritePosition.GetComponent<SpriteRenderer>();
        AudioClip       newSound                = theList[listIndex]; //chooses a random kana from the array

        //changing the old sound to be the new sounds
        oldSprite.GetComponent<AudioSource>().clip = newSound;
    }
    public void         Spawn() //uploads 5 random kana and their sounds to be shown in the game 
    {
        //chooses 5 random numbers between 0 and X (including the last index of kanaList)...(i.e., choosing 5 random kana and their sounds from the list)
        List<int>       fiveRandomNumbers       = FiveUniqueRandomNumbers(kanaList.Capacity);
        int             firstRandomIndex        = fiveRandomNumbers[0];
        int             secondRandomIndex       = fiveRandomNumbers[1];
        int             thirdRandomIndex        = fiveRandomNumbers[2];
        int             fourthRandomIndex       = fiveRandomNumbers[3];
        int             fifthRandomIndex        = fiveRandomNumbers[4];

        //spritePosition has all of the kana sprite locations, and randomly choose where the new kana sprite is going to be positioned
        GameObject[]    randomSpritePosition    = randomizeSpritePosition(kanaPosition01, kanaPosition02, kanaPosition03, kanaPosition04, kanaPosition05);

        //uploading the new kana sprites to Unity
        ChangeSprite(kanaList, firstRandomIndex,  randomSpritePosition[0]);
        ChangeSprite(kanaList, secondRandomIndex, randomSpritePosition[1]);
        ChangeSprite(kanaList, thirdRandomIndex,  randomSpritePosition[2]);
        ChangeSprite(kanaList, fourthRandomIndex, randomSpritePosition[3]);
        ChangeSprite(kanaList, fifthRandomIndex,  randomSpritePosition[4]);

        //spritePosition has all of the sound sprite locations
        randomSpritePosition = randomizeSpritePosition(soundPosition01, soundPosition02, soundPosition03, soundPosition04, soundPosition05);

        //uploading the new kana sounds to Unity
        ChangeSound(soundList, firstRandomIndex,  randomSpritePosition[0]);
        ChangeSound(soundList, secondRandomIndex, randomSpritePosition[1]);
        ChangeSound(soundList, thirdRandomIndex,  randomSpritePosition[2]);
        ChangeSound(soundList, fourthRandomIndex, randomSpritePosition[3]);
        ChangeSound(soundList, fifthRandomIndex,  randomSpritePosition[4]);
    }
    void                Refresh()
    {
        //make sure all of the sprites are not hiding and are visible
        kanaPosition01.SetActive(true);
        kanaPosition02.SetActive(true);
        kanaPosition03.SetActive(true);
        kanaPosition04.SetActive(true);
        kanaPosition05.SetActive(true);
        soundPosition01.SetActive(true);
        soundPosition02.SetActive(true);
        soundPosition03.SetActive(true);
        soundPosition04.SetActive(true);
        soundPosition05.SetActive(true);

        //makes sure all of the sprites are in their proper places when they respawn
        kanaPosition01.transform.position   =   new(-6.98f, 2.41f,  0.00f);
        kanaPosition02.transform.position   =   new(-3.60f, 2.41f,  0.00f);
        kanaPosition03.transform.position   =   new(0.00f,  2.41f,  0.00f);
        kanaPosition04.transform.position   =   new(3.60f,  2.41f,  0.00f);
        kanaPosition05.transform.position   =   new(6.98f,  2.41f,  0.00f);
        soundPosition01.transform.position  =   new(-6.98f, -2.41f, 0.00f);
        soundPosition02.transform.position  =   new(-3.60f, -2.41f, 0.00f);
        soundPosition03.transform.position  =   new(0.00f,  -2.41f, 0.00f);
        soundPosition04.transform.position  =   new(3.60f,  -2.41f, 0.00f);
        soundPosition05.transform.position  =   new(6.98f,  -2.41f, 0.00f);
    }
    void                Start() //called before the first frame update
    {
        Spawn();

    }
    void                Update() //called once per frame
    {
        //removing the used sprite+sound from the pool of sounds+sprites
        Sprite usedKana1 = kanaPosition01.GetComponent<SpriteRenderer>().sprite;
        kanaList.Remove(usedKana1);
        Sprite usedKana2 = kanaPosition02.GetComponent<SpriteRenderer>().sprite;
        kanaList.Remove(usedKana2);
        Sprite usedKana3 = kanaPosition03.GetComponent<SpriteRenderer>().sprite;
        kanaList.Remove(usedKana3);
        Sprite usedKana4 = kanaPosition04.GetComponent<SpriteRenderer>().sprite;
        kanaList.Remove(usedKana4);
        Sprite usedKana5 = kanaPosition05.GetComponent<SpriteRenderer>().sprite;
        kanaList.Remove(usedKana5);
        AudioClip usedSound1 = soundPosition01.GetComponent<AudioSource>().clip;
        soundList.Remove(usedSound1);
        AudioClip usedSound2 = soundPosition02.GetComponent<AudioSource>().clip;
        soundList.Remove(usedSound2);
        AudioClip usedSound3 = soundPosition03.GetComponent<AudioSource>().clip;
        soundList.Remove(usedSound3);
        AudioClip usedSound4 = soundPosition04.GetComponent<AudioSource>().clip;
        soundList.Remove(usedSound4);
        AudioClip usedSound5 = soundPosition05.GetComponent<AudioSource>().clip;
        soundList.Remove(usedSound5);

        if (!(kanaPosition01.activeSelf) && !(kanaPosition02.activeSelf) && !(kanaPosition03.activeSelf) && !(kanaPosition04.activeSelf) && !(kanaPosition05.activeSelf) && !(soundPosition01.activeSelf) && !(soundPosition02.activeSelf) && !(soundPosition03.activeSelf) && !(soundPosition04.activeSelf) && !(soundPosition05.activeSelf))
        {
            //Debug.Log("Time to respawn!");

            Refresh(); //makes sure all of the sprites are visible and they're back in their original places

            Spawn();
        }
    }
}
