using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SphereController : MonoBehaviour {

    public GameObject m_ARCamera;
    
    public Texture[] BubbleTextures = new Texture[2];
    public GameObject m_Anzeige;

    private float Speed;
    private float lifeTime;
    private bool isAlive;
    private Vector3 MoveForward;
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        //m_ARCamera = GameObject.Find("Camera");
        m_ARCamera = GameObject.Find("First Person Camera");


        rb = GetComponent<Rigidbody>();

        Speed = Random.Range(0.4f, 1.5f);
        MoveForward = m_ARCamera.transform.forward;
        //Speed = 1.0f;
        //MoveForward = new Vector3(0.0f,1.0f,0.0f);

        lifeTime = Time.time + Random.Range(7.0f, 13.0f);
        isAlive = true;

        float scaleSize = Random.Range(0.4f, 1.0f);
        GetComponent<Transform>().localScale = new Vector3(scaleSize, scaleSize, scaleSize);

        int idx = Random.Range(0, 2);
        GetComponent<Renderer>().material.mainTexture = BubbleTextures[idx];
    }

    // Update is called once per frame
    void Update() {
        Vector3 tmp = transform.position + MoveForward * Speed * Time.deltaTime;
        rb.MovePosition(tmp);
        if (lifeTime <= Time.time && isAlive)
        {
            burst();
        }
    }

    private void burst()
    {
        Destroy(GetComponent<MeshRenderer>());
        //Destroy gameObject in the next 2sec
        Destroy(gameObject, 2.0f);
        isAlive = false;
    }


}
