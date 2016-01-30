using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    float movementRate = 0.1f;
    private Player player;
    private Rigidbody rBody;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");

        if (xPos != 0)
        {
            rBody.AddForce(xPos * movementRate * Time.deltaTime, 0, 0);
        }
        if (zPos != 0)
        {
            rBody.AddForce(0, 0, zPos * movementRate * Time.deltaTime);
        }
        if (Input.GetButton("Fire1"))
            player.FireAbility1();
        if (Input.GetButton("Fire2"))
            player.FireAbility2();

    }
}
