using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCtrl : MonoBehaviour
{
    public Camera mainCam;
    public Animator anim;
    public ParticleSystem damEff;
    PlayerDamage damager;

    float speed;
    public float normalSpeed = 10f;

    public Vector2 rotateLimit;
    public Vector4 positionLimit;


    float pitch;
    float roll;



	private void Start()
	{
        damEff.gameObject.SetActive(false);
        damager = GetComponent<PlayerDamage>();
        anim.SetBool("Idling", true);
        anim.SetInteger("MoveDir", 5);
        speed = normalSpeed;
		//StartCoroutine(BoostCharge());
	}

	void Update()
    {
        DetectMovement();
        Engine();
        //DetectDash();
    }

	private void LateUpdate()
	{
		ClampMovement();
	}

    void Engine()
	{
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void DetectMovement()
	{
        pitch = Input.GetAxis("Horizontal");
        roll = Input.GetAxis("Vertical");
        if(pitch != 0)	
		{
            anim.SetBool("Idling", false);
            transform.Translate(Vector3.right * pitch * speed * Time.deltaTime, Space.World);
            
            if(pitch > 0)
                anim.SetInteger("MoveDir", 1);
            else
                anim.SetInteger("MoveDir", 0);
		}
        else if(roll != 0)
		{
            anim.SetBool("Idling", false);
            transform.Translate(Vector3.up * roll * speed * Time.deltaTime, Space.World);
            
            if(roll > 0)
                anim.SetInteger("MoveDir", 2);
            else
                anim.SetInteger("MoveDir", 3);
		}
		else
		{
            anim.SetInteger("MoveDir", 5);
            anim.SetBool("Idling", true);
		}
	}

    void ClampMovement()
	{
        Vector3 pos = transform.position;
        //Vector3 rot = transform.rotation.eulerAngles;
        pos.x = Mathf.Clamp(pos.x, positionLimit.x, positionLimit.z);
        pos.y = Mathf.Clamp(pos.y, positionLimit.y, positionLimit.w);
        //if(rot.x < 180)
        //    rot.x = Mathf.Clamp(rot.x, 0, rotateLimit.x);
        //else
        //    rot.x = Mathf.Clamp(rot.x, 360 + rotateLimit.y, 360);
        //if(rot.z < 180)
        //    rot.z = Mathf.Clamp(rot.z, 0, rotateLimit.x);
        //else
        //    rot.z = Mathf.Clamp(rot.z, 360 + rotateLimit.y, 360);
        transform.position = pos;
        //transform.rotation = Quaternion.Euler( rot);
	}

    public void Dead()
	{
        Time.timeScale = 0;
        //웨이브 다시 시작
	}

    public void DamAnim()
	{
        anim.SetTrigger("Damage");
        damEff.gameObject.SetActive(true);
        damEff.Play(true);
        StartCoroutine(DelayStop());
	}

    IEnumerator DelayStop()
	{
        yield return new WaitForSeconds(1f);
        damEff.Stop();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.layer == 8)
		{
            damager.Damage();
		}
	}

    public void ResetPos()
	{
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
	}

}
