using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float sensY;
    public float sensX;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
     void LateUpdate() {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

//     private GameObject player, referencia;
//     private Vector3 distancia;
// 	// Use this for initialization
// 	void Start () {
//         distancia = transform.position - player.transform.position;
// 	}
	
// 	// Update is called once per frame
// 	void LateUpdate () {
//         distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*2,Vector3.up)*distancia;

//         transform.position = player.transform.position + distancia;
//         transform.LookAt(player.transform.position);

//         Vector3 copRot = new Vector3(0,transform.eulerAngles.y,0);
//         referencia.transform.eulerAngles = copRot;
// 	}
// }
