using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public GameObject m_SpawnObjekt;
    public GameObject m_Anzeige;
    public GameObject m_ARCamera;

    private void Start()
    {
        m_Anzeige.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            addSpawnObjekt();
        }
        //Check if the used touches the screen
        Touch touchs;

        if (Input.touchCount < 1 || (touchs = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }       

        if (Input.touchCount >= 1 && touchs.phase == TouchPhase.Began)
        {
            addSpawnObjekt();
        }
   
    }

    void addSpawnObjekt()
    {
        Vector3 cameraPositon = m_ARCamera.transform.position;
        Vector3 CameraForward = m_ARCamera.transform.forward;
        GameObject.Instantiate(m_SpawnObjekt, cameraPositon + CameraForward * 0.5f, Random.rotation);
        //m_Anzeige.GetComponent<Text>().text = "Spanw Cube " + idx + " of Position Move" + CameraForward;
    }

    void Shoot(Vector2 _scrennPoint)
    {
        var ray = Camera.main.ScreenPointToRay(_scrennPoint);
        var hitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitInfo))
        {
            hitInfo.rigidbody.AddForceAtPosition(ray.direction, hitInfo.point);
        }
    }
}
