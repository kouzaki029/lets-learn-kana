using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchPad : MonoBehaviour
{
    public List<int> FiveUniqueRandomNumbers(int maximum) //chooses 5 unique random numbers between 0 and maximum (where maximum is also a possibe random number) 
    {
        List<int> fiveRandomNumbers = new List<int>();

        while (fiveRandomNumbers.Capacity < 5)
        {
            int min = 0;
            int max = maximum;

            int randomNumber = UnityEngine.Random.Range(min, max); //chooses a random number from 0 to X

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
    public void myFunction()
    {
        List<int> fiveRandomNumbers = FiveUniqueRandomNumbers(5);

        int firstRandomIndex = fiveRandomNumbers[0];
        int secondRandomIndex = fiveRandomNumbers[1];
        int thirdRandomIndex = fiveRandomNumbers[2];
        int fourthRandomIndex = fiveRandomNumbers[3];
        int fifthRandomIndex = fiveRandomNumbers[4];

        Debug.Log("firstRandomIndex = " + firstRandomIndex);
        Debug.Log(String.Format("secondRandomIndex = {0}", secondRandomIndex));
        Debug.Log(String.Format("thirdRandomIndex = {0}", thirdRandomIndex));
        Debug.Log(String.Format("fourthRandomIndex = {0}", fourthRandomIndex));
        Debug.Log(String.Format("fifthRandomInde = {0}", fifthRandomIndex));
    }
    void Start() //called before the first frame update
    {
        myFunction();
    }
    void Update() //called once per frame
    {
        //myFunction();
    }
}
