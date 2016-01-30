using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    float movementRate = 0.1f;
    [SerializeField]
    float turnRate = 100f;
    [SerializeField]
    private Player player;
    private Rigidbody rBody;
    private string prefix = "";

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        if (player.Side() == Allignment.Blue)
            prefix = "Player2";
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float xPos = Input.GetAxis(prefix + "Horizontal");
        float zPos = Input.GetAxis(prefix + "Vertical");

        Vector3 inputVec =  Vector3.Normalize(new Vector3(xPos, 0, zPos));

        if (inputVec.magnitude > 0.05f)
        {
            Quaternion lookDir = Quaternion.LookRotation(inputVec);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, Time.deltaTime * turnRate);
        }

        //transform.Translate(new Vector3(inputVec.x * 15f * Time.deltaTime, 0, inputVec.z * 15f * Time.deltaTime));

        if (inputVec.x != 0)
        {
            rBody.AddForce(inputVec.x * movementRate * Time.deltaTime, 0, 0);
        }
        if (inputVec.z != 0)
        {
           rBody.AddForce(0, 0, inputVec.z * movementRate * Time.deltaTime);
        }
        if (Input.GetButton(prefix + "Fire1"))
            player.FireAbility1();
        if (Input.GetButton(prefix + "Fire2"))
            player.FireAbility2();

    }
}
