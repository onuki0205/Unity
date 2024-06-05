using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PlayerObj;

    public void PlayerTeleport()
    {
        Vector3 tmp = transform.position;
        PlayerObj.transform.position = new Vector3(tmp.x, 2.2f, tmp.z);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
