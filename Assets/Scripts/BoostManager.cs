using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    [SerializeField] private GameObject giftPack;
    [SerializeField] private List<GameObject> boosts;
    private GameObject gift;
    private GameObject boost;
    private int previousBoostIndex;
    public void SpawnBoost(Vector3 pos)
    {

        gift = Instantiate(giftPack, pos, Quaternion.identity);
        int _x = Random.Range(0, boosts.Count);

        if (previousBoostIndex == _x)
        {
            if (_x >= boosts.Count - 1) { _x = 0; }
            else { _x++; }
        }

        previousBoostIndex = _x;
        boost = Instantiate(boosts[_x], Vector3.zero, Quaternion.identity);
        boost.transform.parent = GetChildWithName(GetChildWithName(gift, "GiftPackage"), "Boost").transform;
        boost.transform.localPosition = Vector3.zero;
        boost.transform.rotation = Quaternion.Euler(Vector3.zero);
        Invoke("SetParentNull", .75f);
    }
    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
    private void SetParentNull()
    {
        boost.transform.parent = null;
    }
}
