using UnityEngine;
using System.Collections;



public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;
    public float playerMinOffset;
    public float playerMaxOffset;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY,transform.position.z);

        if (bounds)
        {
            if(posX > minCameraPos.x && posX < maxCameraPos.x){
                minCameraPos.x = posX;
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
        //Si se pasa el player de la camara para atras, pierde la velocidad
        if(player.transform.position.x <= minCameraPos.x-playerMinOffset)
        {
            player.GetComponent<Player>().setRigidBodyVelocityInX(0);
            player.transform.position = new Vector2(minCameraPos.x- playerMinOffset, player.transform.position.y);
        }
        //Si se pasa el player de la camara para adelante, pierde la velocidad
        if (player.transform.position.x >= maxCameraPos.x + playerMaxOffset)
        {
            player.GetComponent<Player>().setRigidBodyVelocityInX(0);
            player.transform.position = new Vector2(maxCameraPos.x + playerMaxOffset, player.transform.position.y);
        }
    }

    public void SetMinCamPosition()
    {
        minCameraPos = gameObject.transform.position;
    }

    public void SetMaxCamPosition()
    {
        maxCameraPos = gameObject.transform.position;
    }

}
