using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class ManageCard : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] CharactorData charaData;
    [SerializeField] SetTotalCost setTotalCost;

    List<GameObject> myCards = new List<GameObject>();

    string[] sortTypesList = new string[] { "OderOfObtain", "OderOfCost", "OderOfHp" };

    private string sortTypes = "OderOfObtain";

    int randomCharactorHpUpperLimit = 1000;
    int randomCharactorHpLowerLimit = 1;
    int randomCharactorCostUpperLimit = 10;
    int randomCharactorCostLowerLimit = 1;

    int randomNumberOfCardUpperLimit = 255;
    int randomNumberOfCardLowerLimit = 10;
    int randomCharactorLowerLimit = 0;

    float startingXCoordinateOfTheCard = -7;
    float startingYCoordinateOfTheCard = -1.7f;

    float endingXCoordinateOfTheCard = 8;

    public float addCardsXCoordinatePosition;

    float addRightButton;
    float addLeftButton;

    Vector2 positionOfTheFirstCard;
    Vector2 positionOfTheLastCard;
    float addPositionOfTheCard = 15f;

    void Start()
    {
        for (int i = 0; i <= charaData.charactorData.Count - 1; i++)
        {
            int randomCharactorHp = Random.Range(randomCharactorHpLowerLimit, randomCharactorHpUpperLimit);
            int randomCharactorCost = Random.Range(randomCharactorCostLowerLimit, randomCharactorCostUpperLimit);

            charaData.charactorData[i].charactorHp = randomCharactorHp;
            charaData.charactorData[i].charactorCost = randomCharactorCost;
        }

        int randomNumberOfCard = Random.Range(randomNumberOfCardLowerLimit,randomNumberOfCardUpperLimit);

        for (int i = 0; i < randomNumberOfCard; i++)
        {
            int randomCharactor = Random.Range(randomCharactorLowerLimit, charaData.charactorData.Count - 1);

            myCards.Add(Instantiate(cardPrefab));

            Cards cardsScript = myCards[i].GetComponent<Cards>();

            if (cardsScript != null)
            {
                cardsScript.SetCardParametor(charaData.charactorData[randomCharactor],i + 1);

                cardsScript.InitSetTotalCost(setTotalCost);
            }
        }

        LineUpCards();

        positionOfTheFirstCard = myCards[0].transform.position;
        positionOfTheLastCard = myCards[myCards.Count - 1].transform.position;

        Debug.Log(positionOfTheFirstCard);
        Debug.Log(positionOfTheLastCard);
    }

    void LineUpCards()
    {
        for (int i = 0;i < myCards.Count;i++)
        {
            Cards cardsScript = myCards[i].GetComponent<Cards>();
            if (sortTypes == sortTypesList[0])
            {
                if (!cardsScript.isCardInSetPosition)
                {
                    myCards[i].transform.position = new Vector2(startingXCoordinateOfTheCard + addCardsXCoordinatePosition, startingYCoordinateOfTheCard);
                }

                cardsScript.startingCardPosition = new Vector2(startingXCoordinateOfTheCard + addCardsXCoordinatePosition, startingYCoordinateOfTheCard);

                addCardsXCoordinatePosition += 2.5f;
            }
        }

        addCardsXCoordinatePosition = 0;
    }

    public void GoToTheRightButton()
    {
        if (positionOfTheLastCard.x > endingXCoordinateOfTheCard)
        {
            addRightButton += 15f;
            addLeftButton -= 15f;
            addCardsXCoordinatePosition -= addRightButton;

            positionOfTheLastCard.x -= addPositionOfTheCard;
            positionOfTheFirstCard.x -= addPositionOfTheCard;

            Debug.Log(positionOfTheFirstCard);
            Debug.Log(positionOfTheLastCard);

            LineUpCards();
        }
    }

    public void GoToTheLeftButton()
    {
        if (positionOfTheFirstCard.x < startingXCoordinateOfTheCard)
        {
            addLeftButton += 15f;
            addRightButton -= 15f;
            addCardsXCoordinatePosition += addLeftButton;

            positionOfTheLastCard.x += addPositionOfTheCard;
            positionOfTheFirstCard.x += addPositionOfTheCard;

            Debug.Log(positionOfTheFirstCard);
            Debug.Log(positionOfTheLastCard);

            LineUpCards();
        }
    }
}
