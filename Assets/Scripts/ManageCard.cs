using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManageCard : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] CharactorData charaData;
    [SerializeField] SetTotalCost setTotalCost;
    [SerializeField] TMP_Dropdown dropdown;

    List<GameObject> myCards = new List<GameObject>();

    List<GameObject> orderOfObtainingCards = new List<GameObject>();

    int randomCharactorHpUpperLimit = 1000;
    int randomCharactorHpLowerLimit = 1;
    int randomCharactorCostUpperLimit = 10;
    int randomCharactorCostLowerLimit = 1;

    int randomNumberOfCardUpperLimit = 256;
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

    float resetPositionOfTheCard = 0f;

    float aPagesDistance = 15f;
    float aDistanceOfOneCardLength = 2.5f;

    void Start()
    {
        for (int i = 0; i <= charaData.charactorData.Count - 1; i++)
        {
            int randomCharactorHp = Random.Range(randomCharactorHpLowerLimit, randomCharactorHpUpperLimit);
            int randomCharactorCost = Random.Range(randomCharactorCostLowerLimit, randomCharactorCostUpperLimit);

            charaData.charactorData[i].charactorHp = randomCharactorHp;
            charaData.charactorData[i].charactorCost = randomCharactorCost;
        }

        int randomNumberOfCard = Random.Range(randomNumberOfCardLowerLimit, randomNumberOfCardUpperLimit);

        for (int i = 0; i < randomNumberOfCard; i++)
        {
            int randomCharactor = Random.Range(randomCharactorLowerLimit, charaData.charactorData.Count - 1);

            myCards.Add(Instantiate(cardPrefab));
            orderOfObtainingCards.Add(myCards[i]);

            Cards cardsScript = myCards[i].GetComponent<Cards>();

            if (cardsScript != null)
            {
                cardsScript.SetCardParametor(charaData.charactorData[randomCharactor], i + 1);

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
        for (int i = 0; i < myCards.Count; i++)
        {
            Cards cardsScript = myCards[i].GetComponent<Cards>();
            if (!cardsScript.isCardInSetPosition)
            {
                myCards[i].transform.position = new Vector2(startingXCoordinateOfTheCard + addCardsXCoordinatePosition, startingYCoordinateOfTheCard);
            }

            cardsScript.startingCardPosition = new Vector2(startingXCoordinateOfTheCard + addCardsXCoordinatePosition, startingYCoordinateOfTheCard);

            addCardsXCoordinatePosition += aDistanceOfOneCardLength;
        }

        addCardsXCoordinatePosition = resetPositionOfTheCard;
    }

    public void GoToTheRightButton()
    {
        if (positionOfTheLastCard.x > endingXCoordinateOfTheCard)
        {
            addRightButton += aPagesDistance;
            addLeftButton -= aPagesDistance;
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
            addLeftButton += aPagesDistance;
            addRightButton -= aPagesDistance;
            addCardsXCoordinatePosition += addLeftButton;

            positionOfTheLastCard.x += addPositionOfTheCard;
            positionOfTheFirstCard.x += addPositionOfTheCard;

            Debug.Log(positionOfTheFirstCard);
            Debug.Log(positionOfTheLastCard);

            LineUpCards();
        }
    }

    private void SetCostSort()
    {
        myCards.Sort((a, b) =>
        {
            Cards cardA = a.GetComponent<Cards>();
            Cards cardB = b.GetComponent<Cards>();
            return cardA.myCost.CompareTo(cardB.myCost);
        });

        LineUpCards();
    }

    private void SetHpSort()
    {
        myCards.Sort((a, b) =>
        {
            Cards cardA = a.GetComponent<Cards>();
            Cards cardB = b.GetComponent<Cards>();
            return cardA.myHp.CompareTo(cardB.myHp);
        });
        LineUpCards();
    }

    private void SetNumberSort()
    {
        myCards.Sort((a, b) =>
        {
            Cards cardA = a.GetComponent<Cards>();
            Cards cardB = b.GetComponent<Cards>();
            return cardA.myNumber.CompareTo(cardB.myNumber);
        });
        LineUpCards();
    }

    public void SetSort()
    {
        addLeftButton = resetPositionOfTheCard;
        addRightButton = resetPositionOfTheCard;

        if (dropdown.value == 0)
        {
            SetNumberSort();
        }
        else if (dropdown.value == 1)
        {
            SetCostSort();
        }
        else if (dropdown.value == 2)
        {
            SetHpSort();
        }
        positionOfTheFirstCard = myCards[0].transform.position;
        positionOfTheLastCard = myCards[myCards.Count - 1].transform.position;
    }
}
