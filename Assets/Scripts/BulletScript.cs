using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosion;
    private ParticleSystem particleSys;


    // Start is called before the first frame update
    void Start()
    {
        particleSys = explosion.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet Collision");
        particleSys.Play();
        Destroy(gameObject, particleSys.main.duration);
    }

}
