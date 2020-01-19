using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace NRKernal.NRExamples
{
    /**
    * @brief  Controls the HelloAR example.
    */
    public class HelloMRController : MonoBehaviour
    {
        /**
        * @brief  A model to place when a raycast from a user touch hits a plane.
        */
        public GameObject AndyPlanePrefab;
        public List<GameObject> Blip;
        public GameObject Player;
        public GameObject ResPlayer;
        int Consumptioncounter, MedCounter, EquipmentCounter;

        GameObject BodyObj;
        Vector3 PosFromPlayer, PosBody;
        public GameObject CenterCamera;
        public List<Image>Inventory;
        public List<string> Chat;
        public List<Sprite> Images;
        public TextMeshProUGUI textMesh, ConsumptionText, MedText, EquipmentText ;
        public Image ChatImage;
        public GameObject PointerImage;
        public GameObject ImagePanel;

        
     
        
        

        private void Start()
        {
            Consumptioncounter = 2;
            MedCounter = 2;
            EquipmentCounter = 2;
            InvokeRepeating("RandomString", 3f, 6f);
            Debug.Log("child of resplayer:" + ResPlayer.transform.GetChild(1).gameObject.name);
            ImagePanel.SetActive(false);


        }


        void RandomString()
        {
            ImagePanel.SetActive(true);
            int i = Random.Range(0,3);
            textMesh.text = Chat[i];
            ChatImage.sprite = Images[i];
            StartCoroutine(Disappear());
        }


        void GetHeadRotation()
        {
            PointerImage.transform.rotation = CenterCamera.transform.rotation;
        }


        void Update()
        {
            ConsumptionText.text = Consumptioncounter.ToString();
            MedText.text = MedText.ToString();
            EquipmentText.text = EquipmentText.ToString();

            GetHeadRotation();


            if(NRInput.GetButtonDown(ControllerButton.APP))
            {
                Transform laserAnchordup = NRInput.AnchorsHelper.GetAnchor(ControllerAnchorEnum.RightLaserAnchor);
                RaycastHit hitResultdup;
                if (Physics.Raycast(new Ray(laserAnchordup.transform.position, laserAnchordup.transform.forward), out hitResultdup, 10))
                {
                    if (hitResultdup.collider.gameObject != null && hitResultdup.collider.gameObject.tag == "Body")
                    {
                        BodyObj = hitResultdup.collider.gameObject;
                        PosBody = BodyObj.transform.position;
                        BodyObj.transform.GetChild(1).gameObject.SetActive(false);
                        Instantiate(Blip[0], new Vector3(PosBody.x, PosBody.y + 0.15f, PosBody.z), Quaternion.identity, BodyObj.transform);
                    }
                }

            }

            if(NRInput.GetButtonDown(ControllerButton.TRIGGER))
            {
                Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(ControllerAnchorEnum.RightLaserAnchor);
                RaycastHit hitResult;
                if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
                {
                    if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.tag == "ResourceBody")
                    {
                        Transform ResourceFlag;
                        BodyObj = hitResult.collider.gameObject;
                        PosBody = BodyObj.transform.position;
                        if (BodyObj.transform.GetChild(1) != null)
                        { 
                            ResourceFlag = BodyObj.transform.GetChild(1);
                            Debug.Log("child of reourcebody : " + ResourceFlag.gameObject.name);
                            if (ResourceFlag.gameObject.tag == "Consumption")
                            {
                                ResourceFlag.gameObject.SetActive(false);
                                Consumptioncounter--;
                            }  
                            if (ResourceFlag.gameObject.tag == "Medicine")
                            {
                                ResourceFlag.gameObject.SetActive(false);
                                Consumptioncounter--;
                            }  
                            if (ResourceFlag.gameObject.tag == "Equipment")
                            {
                                ResourceFlag.gameObject.SetActive(false);
                                Consumptioncounter--;
                            }
                            

                        }
                        
                        
                    }
                }
            }

            




            // Get controller laser origin.

            //RaycastHit hitResult;
            //if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
            //{
            //    if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null)
            //    {


            //        // Instantiate Andy model at the hit point / compensate for the hit point rotation.
            //        Instantiate(AndyPlanePrefab, hitResult.point, Quaternion.identity, hitResult.transform);


            //    }
            //}
            //if (NRInput.GetButtonDown(ControllerButton.TRIGGER))
            //{
            //    Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(ControllerAnchorEnum.RightLaserAnchor);

            //    RaycastHit hitResult;
            //    if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
            //    {
            //        if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null)
            //        {
            //            var behaviour = hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>();
            //            if (behaviour.Trackable.GetTrackableType() != TrackableType.TRACKABLE_PLANE)
            //            {
            //                return;
            //            }
            //            float y = hitResult.point.y;


            //            float x = Random.Range(-1f, 1f);
            //            float z = Random.Range(0.5f, 1f);

            //            PosFromPlayer = Player.transform.position;
            //            PosFromPlayer = PosFromPlayer + (Player.transform.right * x) + (Player.transform.forward * z);
            //            PosFromPlayer.y = y;

            //            PosFromPlayer = new Vector3(hitResult.point.x + x, hitResult.point.y, hitResult.point.z + z);

            //            // Instantiate Andy model at the hit point / compensate for the hit point rotation.
            //            Instantiate(AndyPlanePrefab, PosFromPlayer, Quaternion.identity, behaviour.transform);


            //        }
            //    }
            //}
        }


        IEnumerator Disappear()
        {
            yield return new WaitForSeconds(2f);
            ImagePanel.SetActive(true);


        }



    }
}
