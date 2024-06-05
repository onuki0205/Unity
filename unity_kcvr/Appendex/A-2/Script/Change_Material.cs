using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Material : MonoBehaviour
{
    public GameObject ChangeMaterialObj;

    public Material MaterialA;
    public Material MaterialB;

    private void OnTriggerEnter(Collider other)
    {
        Material[] mats = ChangeMaterialObj.GetComponent<Renderer>().materials;
        for (int i = 0; i < mats.Length; ++i)
        {
            if (mats[i].name.Replace(" (Instance)", "") == MaterialA.name) mats[i] = MaterialB;
        }
        ChangeMaterialObj.GetComponent<Renderer>().materials = mats;
    }
}
