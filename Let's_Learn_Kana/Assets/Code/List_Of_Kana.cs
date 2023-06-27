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
    public Sprite[] listOfKana;
    public List<int> fiveRandomNumbers = new List<int>();
    public SpriteRenderer oldSprite;

    //class methods
    public List<int> FiveRandomNumbers()
    {        
        while (fiveRandomNumbers.Capacity < 5)
        {
            int randomKana = Random.Range(0, listOfKana.Length); //chooses a random number from 0 to X
            if (!(fiveRandomNumbers.Contains(randomKana))) //the random number is not already inside the list
            {
                fiveRandomNumbers.Add(randomKana); //add the random number to the list
            }
            //else
            // if the random number is already inside the list, regenerate a new random number
        }

        return fiveRandomNumbers;
    }
    public void CreateKanaSprite() //create 5 random kana to be shown in the game
    {
        Sprite kanaSprite = listOfKana[fiveRandomNumbers[1]]; //chooses a random kana from the array
        //GameObject newKana = Instantiate(kanaPosition01);
        //newKana.GetComponent<SpriteRenderer>().sprite = kanaSprite;
        oldSprite.sprite = kanaSprite;
    }
}
