using System.Collections;
using UnityEngine;

public class Row : MonoBehaviour
{
    public GameManager GameManager;
    public Transform[] symbols;
    public float delayWait;
    public float wait = 1f;
    private float moveDistance = 1f;

    public float numberOfRotations = -1f;
    private bool pulled = false;

    public string name = " ";

    public float min = 200f;
    public float max = 400f;

    // Starts the reel spin
    public void PullTrue()
    {
        pulled = true;
        StartCoroutine(rotate());
    }

    // Returns whether the reel is currently spinning
    public bool CheckPull()
    {
        return pulled;
    }

    // Generates a random number of rotations (multiple of 3)
    public int randomNumber()
    {
        int num;
        num = (int)System.Math.Floor(UnityEngine.Random.Range(min, max));
        switch (num % 3)
        {
            case 0:
                return num;
            case 1:
                num += 2;
                break;
            case 2:
                num += 1;
                break;
        }
        return num;
    }

    public int i = 0;

    // Handles the spinning logic of the reel
    IEnumerator rotate()
    {
        numberOfRotations = randomNumber();
        float waitInterval = wait / numberOfRotations;

        while (i < numberOfRotations)
        {
            // Move all symbols downward
            for (int j = 0; j < 4; j++)
            {
                symbols[j].transform.position = new Vector3(
                    symbols[j].transform.position.x,
                    symbols[j].transform.position.y - moveDistance,
                    symbols[j].transform.position.z
                );

                // Reset position when a symbol goes out of view
                if (symbols[j].position.y <= -6.63f)
                {
                    symbols[j].position = new Vector3(
                        symbols[j].transform.position.x,
                        5.37f,
                        symbols[j].transform.position.z
                    );
                }
            }

            // Gradually slow down near the end of the spin
            if (i % 2 == 0 && i > numberOfRotations - 20)
                waitInterval += delayWait;

            i++;
            yield return new WaitForSeconds(waitInterval);
        }

        // Stop spinning and determine the final symbol
        if (i >= numberOfRotations)
        {
            for (int j = 0; j < 4; j++)
            {
                if (symbols[j].transform.position.y <= -0.63f && symbols[j].transform.position.y >= -1.63f)
                {
                    name = symbols[j].transform.name;
                    GameManager.CheckResults();
                }
            }

            pulled = false;
            i = 0;
            numberOfRotations = -1;
        }
    }
}
