using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        public GameObject Player;
        Vector3 PosFromPlayer;
        string[] inventory;
        

        private void Start()
        {
            inventory = new string[3];
        }



        void Update()
        {
            // If the player doesn't click the trigger button, we are done with this update.
            if (!NRInput.GetButtonDown(ControllerButton.TRIGGER))
            {
                return;
            }

            // Get controller laser origin.
            Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(ControllerAnchorEnum.RightLaserAnchor);

            //RaycastHit hitResult;
            //if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
            //{
            //    if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null)
            //    {
                    

            //        // Instantiate Andy model at the hit point / compensate for the hit point rotation.
            //        Instantiate(AndyPlanePrefab, hitResult.point, Quaternion.identity, hitResult.transform);


            //    }
            //}


            RaycastHit hitResult;
            if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
            {
                if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null)
                {
                    var behaviour = hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>();
                    if (behaviour.Trackable.GetTrackableType() != TrackableType.TRACKABLE_PLANE)
                    {
                        return;
                    }
                    float y = hitResult.point.y;


                    float x = Random.Range(-1f, 1f);
                    float z = Random.Range(0.5f, 1f);

                    PosFromPlayer = Player.transform.position;
                    PosFromPlayer = PosFromPlayer + (Player.transform.right * x) + (Player.transform.forward * z);
                    PosFromPlayer.y = y;

                    PosFromPlayer = new Vector3(hitResult.point.x + x, hitResult.point.y, hitResult.point.z + z);
                    
                    // Instantiate Andy model at the hit point / compensate for the hit point rotation.
                    Instantiate(AndyPlanePrefab, PosFromPlayer, Quaternion.identity, behaviour.transform);
               
                    
                }
            }
        }

      
    }
}
