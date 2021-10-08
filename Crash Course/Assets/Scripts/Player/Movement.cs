using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    KeyCode[] upKeys;
    [SerializeField]
    KeyCode[] downKeys;
    [SerializeField]
    KeyCode[] leftKeys;
    [SerializeField]
    KeyCode[] rightKeys;

    [SerializeField]
    float speed = 20.0f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float initialSpeed = 1f;

        //Keyboard Controls
        float x = 0, y = 0;
        foreach(KeyCode kc in upKeys)
        {
            if (Input.GetKey(kc)) y += initialSpeed;
        }
        foreach (KeyCode kc in downKeys)
        {
            if (Input.GetKey(kc)) y -= initialSpeed;
        }
        foreach (KeyCode kc in rightKeys)
        {
            if (Input.GetKey(kc)) x += initialSpeed;
        }
        foreach (KeyCode kc in leftKeys)
        {
            if (Input.GetKey(kc)) x -= initialSpeed;
        }

        //Prevent use of both keyboard controls for extra speed
        x = Mathf.Clamp(x, -initialSpeed, initialSpeed); y = Mathf.Clamp(y, -initialSpeed, initialSpeed);

        //Actually move
        Vector2 movement = new Vector3(x, y) * speed;
        rb.velocity = movement;

        //Rotate character
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
