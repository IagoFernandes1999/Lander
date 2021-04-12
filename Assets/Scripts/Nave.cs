using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nave : MonoBehaviour
{
    [SerializeField]
    float Combustivel = 500f;

    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 15f;

    [SerializeField]
    TextMeshProUGUI Combustiveltxt;

    void Update()
    {
        if(Combustivel > 0)
        {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Time.deltaTime);
            Combustivel -= 10 * Time.deltaTime;

        } else if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
            Combustivel -= 5 * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
            Combustivel -= 5 * Time.deltaTime;
        }

        }
        Combustiveltxt.text = "Combustível = " + System.Convert.ToInt32(Combustivel).ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Aterrei...");
            Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("...mas explodi!");
            }
        } else
        {
            Debug.Log("Explodi!");
        }
      
    }
}
