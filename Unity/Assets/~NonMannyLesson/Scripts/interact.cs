using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour {

	//3D Raycasting
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray interactRay;
            //creating a line starting from centre of screen and shooting forward
            interactRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            RaycastHit hitInfo;
            if (Physics.Raycast(interactRay, out hitInfo, 10))
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Hit Enemy");
                }
            }
        }
    }
}
