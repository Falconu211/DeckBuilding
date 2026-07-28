using UnityEngine;

public class SetTotalCost: MonoBehaviour
{
    private int totalCost;

    public void AddCost(int cost)
    {
        totalCost += cost;
        Debug.Log("Total Cost: " + totalCost);
    }

    public void SubtractCost(int cost)
    {
        totalCost -= cost;
        Debug.Log("Total Cost: " + totalCost);
    }
}
