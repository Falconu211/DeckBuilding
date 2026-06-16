using System.Collections.Generic;
using UnityEngine;

public class ManageCard : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] CharactorData charactorData;

    List<CharactorParametor> myCards = new List<CharactorParametor>();

    int randomNumberOfCardUpperLimit = 255;
    int randomNumberOfCardLowerLimit = 10;
    int randomCharactorLowerLimit = 0;

    void Start()
    {
        int randomNumberOfCard = Random.Range(randomNumberOfCardLowerLimit,randomNumberOfCardUpperLimit);

        for (int i = 0; i < randomNumberOfCard; i++)
        {
            int randomCharactor = Random.Range(randomCharactorLowerLimit, charactorData.charactorData.Count - 1);
            myCards.Add(charactorData.charactorData[randomCharactor]);
            GameObject cards = Instantiate(cardPrefab);

            Cards cardsScript = cards.GetComponent<Cards>();

            if (cardsScript != null)
            {
                cardsScript.SetCardText(myCards[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
