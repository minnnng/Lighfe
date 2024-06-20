using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // �÷��̾� �̵� �ӵ�
    private Rigidbody2D rb;
    public GameObject notiCanvas; // Noti Canvas�� �����ϱ� ���� ����
    public TMPro.TextMeshProUGUI notiText; // Noti Canvas ���� TextMeshProUGUI
    private GameObject currentGem; // ���� �浹�� Gem�� �����ϱ� ���� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Z�� ȸ���� ����
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        notiCanvas.SetActive(false); // ������ �� noti ĵ������ ��Ȱ��ȭ
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            // Gem�� �浹�ϸ� noti ĵ������ ���̰� �ϰ� �ؽ�Ʈ�� ������Ʈ
            Gem gem = other.gameObject.GetComponent<Gem>();
            if (gem != null)
            {
                notiText.text = gem.gemDescription; // Gem�� �������� �ؽ�Ʈ ������Ʈ
                notiCanvas.SetActive(true);
                currentGem = other.gameObject; // ���� �浹�� Gem ����
                Time.timeScale = 0; // ������ �Ͻ�����
            }
        }
    }

    public void CloseNoti()
    {
        notiCanvas.SetActive(false); // Noti ĵ������ ��Ȱ��ȭ
        Time.timeScale = 1; // ������ �簳
        if (currentGem != null)
        {
            Destroy(currentGem); // ���� �浹�� Gem ����
            currentGem = null; // currentGem ���� �ʱ�ȭ
        }
    }
}
