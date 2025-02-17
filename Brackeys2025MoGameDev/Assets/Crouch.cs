using UnityEngine;

public class Crouch : MonoBehaviour
{
    public CharacterController controller;
    public float crouchSpeed, normalHeight, crouchHeight;
    public Vector3 offset;
    public Transform player;
    bool crouching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouching = false;
        }
        if (crouching == true)
        {
            controller.height = controller.height - crouchSpeed * Time.deltaTime;
            if (controller.height <= crouchHeight)
            {
                controller.height = crouchHeight;
            }
            }
        if (crouching == false)
        {
             controller.height = controller.height + crouchSpeed * Time.deltaTime;
             if (controller.height < normalHeight)
             {
               //  player.gameObject.SetActive(false);
                 player.position = player.position + offset * Time.deltaTime;
                // player.gameObject.SetActive(true);
             }
             if (controller.height >= normalHeight)
             {
                 controller.height = normalHeight;
             }


            }
        }
    }

