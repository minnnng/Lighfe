using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // 플레이어 이동 속도

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Z축 회전을 고정
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // 플레이어 이동 로직
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 상하좌우 이동 벡터 계산
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;

        // Rigidbody2D를 통해 이동
        rb.velocity = movement;
    }
}
