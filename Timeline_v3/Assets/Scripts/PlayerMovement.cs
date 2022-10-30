using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    // Instead of multiple UI's, playmovement only looks at one object for the status of all UI's
    [SerializeField] public UICaller mainUI;
    public float moveSpeed = 5f;
    // this variable might end up never being used, but it might be helpful
    public string direction = "Down";
    public IInteractable Interactable { get; set; }
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public bool isK177;

    //Added for cutscene use
    private void Awake()
    {
        GlobalReferences.Player = this;
    }

    void Update()
    {
        if (mainUI.areUIOpen || mainUI.IsInspectonScreensOpen) {    
            movement.x = 0; movement.y = 0; 
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            return;  
            }

        if (mainUI.isCutsceneActive) {
            movement.x = 0;
            movement.y = 0;
            return;
        }
         // Inputs
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if(Interactable != null)  Interactable.Interact(PlayerMovement:this); 

        if(Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.E))
        {
            if (!mainUI.CurrentUIOpened.Equals(UIName.Pause)) mainUI.CallOpenMenu(UIName.Pause);
            else mainUI.CallCloseMenu(UIName.Pause);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) mainUI.CallOpenMenu(UIName.Quit);
         
        movement.x = (int)(Input.GetAxisRaw("Horizontal")/0.0625)*0.0625f;
        movement.y = (int)(Input.GetAxisRaw("Vertical")/0.0625)*0.0625f;

        // if player is moving
        if (!(movement.x == 0 && movement.y == 0))
        {
            //animator will remeber that last direction the player was moving before stopping
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
            //if player has more horizontal movement
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y) )
            {
                if (movement.x > 0) direction = "Right";
                else direction = "Left";
            }
            // if player has more vertical movement
            else
            {
                if (movement.y > 0) direction = "Up";
                else direction = "Down";
            }
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);  
        animator.SetBool("isK177", isK177);
    }

    void FixedUpdate() 
    {
        // This is the actual movement of the character
        if(mainUI.isCutsceneActive) {
            Vector2 temp1;
            temp1=rb.position;
            temp1.x= Mathf.RoundToInt( temp1.x / 0.0625f) * 0.0625f;
            temp1.y= Mathf.RoundToInt( temp1.y / 0.0625f) * 0.0625f;
            rb.MovePosition(temp1);
        }
        //if (inCutscene || passScreen.IsOpen) return;
        // Movement
        Vector2 temp;
        temp=rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        temp.x= Mathf.RoundToInt( temp.x / 0.0625f) * 0.0625f;
        temp.y= Mathf.RoundToInt( temp.y / 0.0625f) * 0.0625f;
        rb.MovePosition( temp);
        // REMEMBER, MAKE SURE THIS CAN'T BE CHECKED DURING A CUTSCENE    
    }

    public void TestLog()
    {
        Debug.Log(transform.localScale.ToString());
    }
}
