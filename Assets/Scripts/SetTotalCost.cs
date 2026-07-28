using TMPro;
using UnityEngine;

public class SetTotalCost: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalCardCostText;
    [SerializeField] TextMeshProUGUI overTotalCostText;

    private int totalCost;

    private int overTotalCost = 10;

    public void AddCost(int cost)
    {
        totalCost += cost;
        totalCardCostText.text = "Total Cost: " + totalCost;

        overTotalCostText.text = "";

        if (totalCost > overTotalCost)
        {
            totalCardCostText.color = Color.red;
        }
    }

    public void SubtractCost(int cost)
    {
        totalCost -= cost;
        totalCardCostText.text = "Total Cost: " + totalCost;

        overTotalCostText.text = "";

        if (totalCost <= overTotalCost)
        {
            totalCardCostText.color = Color.white;
        }
    }

    public void ApplyCostButton()
    {
        if (totalCost > overTotalCost)
        {
            overTotalCostText.text = "コストが上限値を越えています";
        }
    }
}
