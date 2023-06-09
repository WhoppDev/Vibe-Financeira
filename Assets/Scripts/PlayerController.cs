using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    public float moveSpeed = 5f; // Velocidade de movimento do player

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public FixedJoystick moveJoystick;

    private GameManager gameManager; // Referência ao GameManager
    public SpriteRenderer playerSpriteRenderer;
    public static PlayerController LocalPlayerInstance;

    public static PlayerController LastAlivePlayer { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            moveJoystick = GameObject.Find("Movimento").GetComponent<FixedJoystick>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

        playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>(); // Obtém a referência do GameManager na cena
        moveJoystick = GameObject.Find("Movimento").GetComponent<FixedJoystick>();

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {


        moveInput.x = moveJoystick.Horizontal;
        moveInput.y = moveJoystick.Vertical;

        rb.velocity = moveInput * moveSpeed;



        anim.SetFloat("Horizontal", moveInput.x);
        anim.SetFloat("Vertical", moveInput.y);
        anim.SetFloat("Speed", moveInput.magnitude);

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar se o objeto de colisão é um jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ajustar a posição do jogador para evitar a colisão
            Vector2 avoidCollisionOffset = (transform.position - collision.transform.position).normalized * 1f;
            rb.MovePosition(rb.position + avoidCollisionOffset);
        }
    }







}
