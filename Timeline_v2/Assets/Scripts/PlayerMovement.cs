using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Playables;
public class PlayerMovement : MonoBehaviour
{

    //NEW
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private PasswordScreen passScreen;
    [SerializeField] private ScreenHandler screenHandler;
    [SerializeField] private QuitScreen quitScreen;
    public PauseMenu PauseMenu => pauseMenu;
    public float moveSpeed = 5f;
    public bool inCutscene = true;
    
    // this variable might end up never being used, but it might be helpful
    public string direction = "Down";
    //NEW
    public DialogueUI DialogueUI => dialogueUI;
    //NEW
    public IInteractable Interactable { get; set; }

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    
    //void Start(){
        // OK im pretty sure this will help stop the control 2's postion error.
        // Won't work when trying to get the timeline manager so thats cool
        // NOPE, god i hate this
        //GetComponentInChildren<PlayableDirector>().playableAsset=null;
    //}
    // Update is called once per frame
    void Update()
    {
        
        
        //Debug.Log(inCutscene);
        if (inCutscene)
        {
            movement.x=0;
            movement.y=0;
            
            return;
        }
        if (pauseMenu.IsOpen)
        {
            movement.x=0;
            movement.y=0;
            
            return;
        }
        if (dialogueUI.IsOpen || (quitScreen!=null && quitScreen.IsOpen) || passScreen.IsOpen || screenHandler.IsOpen) 
        {
            movement.x=0;
            movement.y=0;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            return;
        }
        if (!dialogueUI.IsOpen){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(Interactable != null)
                {
                    Interactable.Interact(PlayerMovement:this);
                }
            }
            if(Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.E))
            {
                if (pauseMenu.IsOpen) pauseMenu.closePauseMenu();
                else pauseMenu.openPauseMenu();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
                quitScreen.OpenScreen();
        }
        
        // Input
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

    
    }

    void FixedUpdate() 
    {
        if(inCutscene) {
            Vector2 temp1;
            temp1=rb.position;
            temp1.x= Mathf.RoundToInt( temp1.x / 0.0625f) * 0.0625f;
            temp1.y= Mathf.RoundToInt( temp1.y / 0.0625f) * 0.0625f;
            rb.MovePosition(temp1);
        }
        if (inCutscene || passScreen.IsOpen) return;
        // Movement
        Vector2 temp;
        temp=rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        temp.x= Mathf.RoundToInt( temp.x / 0.0625f) * 0.0625f;
        temp.y= Mathf.RoundToInt( temp.y / 0.0625f) * 0.0625f;
        rb.MovePosition( temp);
        // REMEMBER, MAKE SURE THIS CAN'T BE CHECKED DURING A CUTSCENE 
        
    }
}
