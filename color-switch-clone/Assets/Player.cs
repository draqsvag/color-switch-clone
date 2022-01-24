using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public float jumpForce = 10f;
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerRenderer;
    public Color32 currentColor;

    public UnityEvent OnPlayerDead;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();

        currentColor = ColorManager.Instance.GetRandomColor();
        playerRenderer.color = currentColor;

        playerRigid.velocity = Vector2.up * jumpForce * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            playerRigid.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColorChanger"))
        {
            currentColor = ColorManager.Instance.GetRandomColor();
            playerRenderer.color = currentColor;
            Destroy(collision.gameObject);
        }

        else if ((Color32) collision.GetComponent<SpriteRenderer>().color != (Color) currentColor)
        {
            OnPlayerDead.Invoke();

            Destroy(gameObject);
        }
    }
}
