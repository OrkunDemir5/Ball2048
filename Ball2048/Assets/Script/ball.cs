using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{


    public int value;
    public GameObject nextBall;
    public Rigidbody rb;
    public int ID;
    public GameObject ps;
    AudioSource aSource;

    GameObject scoreController;

    private void Awake()
    {
        ID = GetInstanceID();
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();

        scoreController = GameObject.Find("GameManager");
        
        
    }

    public void CreatingForce()
    {
        rb.AddForce((Vector3.up - Vector3.right) * 150);
    }
    public void SendBall()
    {
        rb.AddForce(-transform.right * 700);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Sphere"))
        {
            

            if (collision.gameObject.TryGetComponent(out ball top))
            {
                if (top.value == value)
                {
                    if (ID < top.ID) return;

                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    aSource.Play();
                    scoreController.GetComponent<ballController>().scoreArttirma();

                    GameObject yokOlma = Instantiate(ps, transform.position, transform.rotation);


                    if (nextBall != null)
                    {
                        GameObject temp = Instantiate(nextBall, transform.position, Quaternion.identity);
                        if(temp.TryGetComponent(out ball newBall))
                        {
                            newBall.CreatingForce();
                            
                        }
                    }
                }
            }
        }
    }




}
