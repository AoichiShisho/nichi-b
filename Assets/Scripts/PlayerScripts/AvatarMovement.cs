using Photon.Pun;
using UnityEngine;

public class AvatarMovement : MonoBehaviourPunCallbacks
{
    public float speed = 2.5f;
    public float jumpForce = 300.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine) {
            playerMovement();
            playerJump();
        }
    }

    private void playerMovement() {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.back * speed * Time.deltaTime; 
            // sprite.flipX = true;
            // anim.SetBool("isWalking", true);
            // anim.SetBool("isFront", true);
        }
        // right
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            // sprite.flipX = false;
            // anim.SetBool("isWalking", true);
            // anim.SetBool("isFront", true);
        }
        // forward
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
            // anim.SetBool("isWalking", true);
            // anim.SetBool("isFront", false);
        }
        // back
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
            // anim.SetBool("isWalking", true);
            // anim.SetBool("isFront", true);
        }

        // if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) 
        // && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) {
        //     anim.SetBool("isWalking", false);
        //}
    }

    private void playerJump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
}
