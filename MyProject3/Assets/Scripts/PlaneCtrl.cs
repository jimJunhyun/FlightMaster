using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCtrl : MonoBehaviour
{
    public Camera mainCam;
    public KeyCode DashKey;

    float speed;
    public float normalSpeed = 10f;
    public float dashSpeed = 30f;
    public float rotSpeed = 150f;

    public float DashTime = 3f;

    bool isDashing = false;
    public bool IsDashing { get => isDashing;}

    float boostMax = 100f;
    float boostCurrent = 100f;

    float pitch;
    float roll;

	private void Start()
	{
        speed = normalSpeed;
		//StartCoroutine(BoostCharge());
	}

	void Update()
    {
        DetectMovement();
        //DetectDash();
    }

    void DetectMovement()
	{
        pitch = Input.GetAxis("Horizontal");
        roll = Input.GetAxis("Vertical");
        if(pitch != 0)
		{
            transform.Translate(Vector3.right * pitch * speed * Time.deltaTime);
		}
        else if(roll != 0)
		{
            transform.Translate(Vector3.up * roll * speed * Time.deltaTime);
		}
	}

 //   void DetectDash()
	//{
	//	if (Input.GetKey(DashKey) && boostCurrent > 0)
	//	{
 //           Dash();
 //       }
 //       else if (Input.GetKeyUp(DashKey) || boostCurrent <= 0)
	//	{
 //           EndDash();
	//	}
	//}

 //   void Dash()
	//{
	//	if (!isDashing )
	//	{
 //           isDashing = true;
            
 //       }
 //       if(boostCurrent > 0)
	//	{
 //           speed = dashSpeed;
 //           boostCurrent -= 0.1f;
 //       }
	//}

 //   void EndDash()
	//{
 //       if(isDashing)
	//	{
 //           isDashing = false;
 //           speed = normalSpeed;
	//	}
	//}

 //   IEnumerator BoostCharge()
	//{
 //       while (true)
	//	{
 //           yield return null;
 //           while (boostCurrent < boostMax && !Input.GetKey(DashKey))
	//		{
 //               yield return new WaitForSeconds(0.1f);
 //               boostCurrent += 1f;
 //           }
            
 //       }
        
	//}
}
