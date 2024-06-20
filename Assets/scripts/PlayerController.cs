using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // �÷��̾� �̵� �ӵ�

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Z�� ȸ���� ����
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // �÷��̾� �̵� ����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �����¿� �̵� ���� ���
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;

        // Rigidbody2D�� ���� �̵�
        rb.velocity = movement;
    }
}
