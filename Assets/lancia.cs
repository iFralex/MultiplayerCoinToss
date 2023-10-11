using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancia : Photon.MonoBehaviour, IPunObservable
{
    public bool lancio, ruota, vai;
    public int[] o;

    void Start()
    {
        Application.targetFrameRate = 60;
        if (!PhotonNetwork.isMasterClient)
        {
            Destroy(FindObjectOfType<UnityEngine.UI.Button>().gameObject);
        }
    }

    void FixedUpdate()
    {
        if (lancio)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Rigidbody>().AddTorque(new Vector3(0, o[i], 0));
            }
        }
    }
    
    void Update()
    {
        if (vai && !lancio)
        {
            lancio = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Rigidbody>().AddForce(Vector3.up * 15, ForceMode.VelocityChange);
            }
            StartCoroutine(aspetta());
        }

        if (ruota)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Rigidbody>().angularVelocity == Vector3.zero)
                {
                    if (transform.GetChild(i).eulerAngles.y < 90 | transform.GetChild(i).eulerAngles.y > 270)
                    {
                        transform.GetChild(i).rotation = Quaternion.Lerp(transform.GetChild(i).rotation, Quaternion.Euler(transform.GetChild(i).eulerAngles.x, 0, transform.GetChild(i).eulerAngles.z), Time.deltaTime * 5);
                    }
                    else
                    {
                        transform.GetChild(i).rotation = Quaternion.Lerp(transform.GetChild(i).rotation, Quaternion.Euler(transform.GetChild(i).eulerAngles.x, 180, transform.GetChild(i).eulerAngles.z), Time.deltaTime * 5);
                    }
                }
            }
        }
    }

    public void Lancia()
    {
        vai = true;
        for (int i = 0; i < o.Length; i++)
        {
            o[i] = Random.Range(-10, 10);
        }
    }

    IEnumerator aspetta()
    {
        yield return new WaitForSeconds(5);
        lancio = false;
        ruota = true;
        vai = false;
    }

    IEnumerator Asp()
    {
        yield return new WaitForSeconds(1);
        lancio = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody>().AddForce(Vector3.up * 15, ForceMode.VelocityChange);
        }
        StartCoroutine(aspetta());
        vai = false;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(o);
            stream.SendNext(vai);
        }
        else
        {
            o = (int[])stream.ReceiveNext();
            vai = (bool)stream.ReceiveNext();
        }
    }
}
