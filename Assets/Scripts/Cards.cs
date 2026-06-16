using TMPro;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI hpText;

    public void SetCardText(CharactorParametor parametor)
    {
        costText.text = "Cost:" + parametor.charactorCost;
        hpText.text = "Hp:" + parametor.charactorHp;
    }
}
