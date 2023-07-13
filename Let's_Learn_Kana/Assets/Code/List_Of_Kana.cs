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
    public List<Sprite> kanaList; //contains all of the kana sprites that are added in Unity, not Visual Studio

    //class methods
    public void CreateKanaSprite() //uploads 5 random kana to be shown in the game
    {
        List<int> fiveRandomNumbers = new List<int>(); //generate 5 unique numbers

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
        int firstRandomNumber = fiveRandomNumbers[0]; //chooses a random number between 0 and X

        //uploading the kana to Unity
        Sprite kanaSprite = kanaList[firstRandomNumber]; //chooses a random kana from the array
        Vector3 kanaPosition = kanaPosition01.transform.position; //copies kanaPosition01's position and makes it the default position for the first kana
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);  //default Quanternion
        GameObject newKana = Instantiate(kanaPosition01, kanaPosition, quaternion);
        newKana.GetComponent<SpriteRenderer>().sprite = kanaSprite;
        Destroy(kanaPosition01);
    }
    void Start() // Update is called once per frame
    {
        CreateKanaSprite();
    }
}
