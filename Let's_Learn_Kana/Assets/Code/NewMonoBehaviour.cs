using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviour : MonoBehaviour
{
    public Sprite[] kanaArray;

    // Use this for initialization
    void Start()
    {
        List<int> fiveRandomNumbers = new List<int>();
        while (fiveRandomNumbers.Capacity < 5)
        {
            int min = 0;
            int max = kanaArray.Length - 1;

            int randomKana = Random.Range(min, max); //chooses a random number from 0 to X
            if (!(fiveRandomNumbers.Contains(randomKana))) //the random number is not already inside the list
            {
                fiveRandomNumbers.Add(randomKana); //add the random number to the list
            }
            //else
            // if the random number is already inside the list, regenerate a new random number
        }

        Debug.Log(fiveRandomNumbers[0]);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
