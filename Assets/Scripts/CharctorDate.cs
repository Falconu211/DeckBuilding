using System.Collections.Generic;
using UnityEngine;

public class CharactorData : MonoBehaviour
{
    public List<CharactorParametor> charactorData = new List<CharactorParametor>();

    private void Start()
    {
        CharactorParametor charactor1 = new CharactorParametor();
        CharactorParametor charactor2 = new CharactorParametor();
        CharactorParametor charactor3 = new CharactorParametor();
        CharactorParametor charactor4 = new CharactorParametor();
        CharactorParametor charactor5 = new CharactorParametor();
        CharactorParametor charactor6 = new CharactorParametor();
        CharactorParametor charactor7 = new CharactorParametor();
        CharactorParametor charactor8 = new CharactorParametor();
        CharactorParametor charactor9 = new CharactorParametor();
        CharactorParametor charactor10 = new CharactorParametor();
        charactorData.Add(charactor1);
        charactorData.Add(charactor2);
        charactorData.Add(charactor3);
        charactorData.Add(charactor4);
        charactorData.Add(charactor5);
        charactorData.Add(charactor6);
        charactorData.Add(charactor7);
        charactorData.Add(charactor8);
        charactorData.Add(charactor9);
        charactorData.Add(charactor10);
    }
}

public class CharactorParametor
{
    public int charactorHp;
    public int charactorCost;
}