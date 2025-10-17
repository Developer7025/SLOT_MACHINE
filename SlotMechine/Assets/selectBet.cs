using UnityEngine;

public class selectBet : MonoBehaviour
{
    public GameManager Manager;
    public void Bet10() 
    {
        Manager.PlaceBet(10);
        MenuClose();
    }
    public void Bet20() 
    {
        Manager.PlaceBet(20);
        MenuClose();
    }
    public void Bet50() 
    {
        Manager.PlaceBet(50);
        MenuClose();
    }
    public void Bet100() 
    {
        Manager.PlaceBet(100);
        MenuClose();
    }

    private void MenuClose() 
    {
        if(Manager.isBetPlaced)
            gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
