using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class symbol
{
    public string name;
    public int multiplier_3;
    public int multiplier_2;
}

public class GameManager : MonoBehaviour
{
    public symbol[] symbols;
    public Animator handle;
    [SerializeField]
    private Row[] rows;

    public float wait = 1f;
    public int min = 100;
    public int max = 150;

    public int balance = 100;

    public int bet;
    public bool isBetPlaced = false;
    public int winningAmount = 0;

    public Text showBalance;
    public GameObject BetMenu;

    // Called when the slot handle is clicked
    private void OnMouseDown()
    {
        if (isBetPlaced)
        {
            isBetPlaced = false;
            handle.SetTrigger("pull");

            float delay = 0.005f;
            for (int r = 0; r < rows.Length; r++)
            {
                rows[r].delayWait = delay;
                rows[r].name = " ";
                rows[r].min = min;
                rows[r].max = max;
                rows[r].wait = wait;
                delay += 0.005f;
                rows[r].PullTrue();
            }
            winningAmount = 0;
        }
    }

    // Sets the target frame rate
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Initializes balance display
    private void Start()
    {
        UpdateBalanceOnScreen();
    }

    // Checks the result after all rows stop spinning
    public void CheckResults()
    {
        if (rows[2].name != " ")
        {
            // Check for 3 matching symbols
            if (rows[0].name == rows[1].name && rows[2].name == rows[1].name)
            {
                foreach (symbol s in symbols)
                {
                    if (s.name == rows[0].name)
                    {
                        winningAmount = bet * s.multiplier_3;
                    }
                }
            }
            // Check for 2 matching symbols
            else if (rows[0].name == rows[1].name || rows[2].name == rows[1].name)
            {
                foreach (symbol s in symbols)
                {
                    if (s.name == rows[1].name)
                    {
                        winningAmount = bet * s.multiplier_2;
                    }
                }
            }

            balance += winningAmount;
            UpdateBalanceOnScreen();
            BetMenu.SetActive(true);
        }
    }

    // Updates the balance text on screen
    void UpdateBalanceOnScreen()
    {
        showBalance.text = balance.ToString();
    }

    // Places a bet and updates balance
    public void PlaceBet(int b)
    {
        if (balance >= b)
        {
            bet = b;
            balance -= bet;
            UpdateBalanceOnScreen();
            isBetPlaced = true;
        }
    }
}