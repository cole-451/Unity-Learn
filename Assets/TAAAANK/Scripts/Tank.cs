using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 90.0f; // rotation in degrees per second

    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;
    InputAction moveAction;
    InputAction attackAction;

    void Start()
    {
        //
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        attackAction.started +=  ctx => OnAttack();

    }

    void Update()
    {
        // direction (forward/backward movement)
        float direction = 0.0f;
        // if (Keyboard.current.wKey.isPressed) direction = +1.0f;
        // if (Keyboard.current.sKey.isPressed) direction = -1.0f;

        direction = moveAction.ReadValue<Vector2>().y;

        // translate (move) the tank in the forward direction
        // moves the tank in the relative direction (direction tank is facing)
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);

        // rotation (left/right)
        float rotation = moveAction.ReadValue<Vector2>().x;
       // if (Keyboard.current.aKey.isPressed) rotation = -1.0f;
        //if (Keyboard.current.dKey.isPressed) rotation = +1.0f;

        // rotate the tank, around the up axis (y-axis)
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        // check if "Fire" key is pressed, if so instantiate the ammo (rocket)
        // ammo is instantiate at the muzzle position and rotation
        //if (attackAction.WasPressedThisFrame())
        //{
        //    Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
        //}
    }

    void OnAttack()
    {
        Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
    }
}
