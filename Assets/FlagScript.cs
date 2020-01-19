using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagScript : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> FlagAdvisor;
    public Camera Player;
    public GameObject QuestionPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < 2f)
        {

            QuestionPanel.SetActive(false);
            
            //int i = Random.Range(0, 3);
            

           // Instantiate(FlagAdvisor[i], new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z), Quaternion.identity, this.gameObject.transform);
        }
    }
}
