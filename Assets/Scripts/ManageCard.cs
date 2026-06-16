using System.Collections.Generic;
using UnityEngine;

public class ManageCard : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] CharactorData charactorData;

    List<GameObject> myCards = new List<GameObject>();

    string[] sortTypesList = new string[] { "OderOfObtain", "OderOfCost", "OderOfHp" };

    private string sortTypes = "OderOfObtain";

    int randomNumberOfCardUpperLimit = 255;
    int randomNumberOfCardLowerLimit = 10;
    int randomCharactorLowerLimit = 0;

    float cardsDefaultXCoordinatePosition = -7;
    float cardsDefaultYCoordinatePosition = -1.7f;

    float addCardsXCoordinatePosition;

    void Start()
    {
        int randomNumberOfCard = Random.Range(randomNumberOfCardLowerLimit,randomNumberOfCardUpperLimit);

        for (int i = 0; i < randomNumberOfCard; i++)
        {
            int randomCharactor = Random.Range(randomCharactorLowerLimit, charactorData.charactorData.Count - 1);

            myCards.Add(Instantiate(cardPrefab));

            Cards cardsScript = myCards[i].GetComponent<Cards>();

            if (cardsScript != null)
            {
                cardsScript.SetCardText(charactorData.charactorData[randomCharactor]);
            }
        }

        LineUpCards();
    }

    void LineUpCards()
    {
        for (int i = 0;i <= myCards.Count;i++)
        {
            if (sortTypes == sortTypesList[0])
            {
                myCards[i].transform.position = new Vector2(cardsDefaultXCoordinatePosition + addCardsXCoordinatePosition, cardsDefaultYCoordinatePosition);

                addCardsXCoordinatePosition += 2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
