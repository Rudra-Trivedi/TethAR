using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithHead : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    Quaternion rot;


    void Start()
    {
        rot = this.transform.rotation;   
    }

    // Update is called once per frame
    void Update()
    {
        rot.z = Player.transform.rotation.z;
        transform.rotation = rot;
    }
}
