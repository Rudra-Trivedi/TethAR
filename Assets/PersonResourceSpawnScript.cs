using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonResourceSpawnScript : MonoBehaviour
{
    public List<GameObject> ResourceList;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0; //Random.Range(0, 3);
        Instantiate(ResourceList[i], new Vector3(this.transform.position.x, this.transform.position.y + 0.15f, this.transform.position.z), Quaternion.identity, this.gameObject.transform);
    }

    
}
