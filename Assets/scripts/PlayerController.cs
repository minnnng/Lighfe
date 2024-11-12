using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // �÷��̾� �̵� �ӵ�
    private Rigidbody2D rb;
    public GameObject notiCanvas; // Noti Canvas�� �����ϱ� ���� ����
    public GameObject notyetCanvas; // Gem�� ���� ������ ������ �� ��Ÿ�� Canvas
    public GameObject endingCanvas; // Gem�� ���� ���� �� ��Ÿ�� Canvas
    public TMPro.TextMeshProUGUI notiText; // Noti Canvas ���� TextMeshProUGUI
    private int gemCount = 0; // ���� ���� Gem�� ����
    private bool allGemsCollected = false; // Gem�� ���� ��Ҵ��� ���θ� ��Ÿ���� ����
    private GameObject currentGem; // ���� �浹�� Gem�� �����ϱ� ���� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Z�� ȸ���� ����
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        notiCanvas.SetActive(false); // ������ �� noti ĵ������ ��Ȱ��ȭ
        notyetCanvas.SetActive(false); // ������ �� notyet ĵ������ ��Ȱ��ȭ
        endingCanvas.SetActive(false); // ������ �� ending ĵ������ ��Ȱ��ȭ
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
                gemCount++; // Gem ī��Ʈ ����
                notiText.text = gem.gemDescription; // Gem�� �������� �ؽ�Ʈ ������Ʈ
                notiCanvas.SetActive(true);
                Time.timeScale = 0; // ������ �Ͻ�����
                currentGem = other.gameObject; // ���� �浹�� Gem ����

                // ��� Gem�� ��Ҵ��� Ȯ��
                CheckAllGemsCollected();
            }
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            // Door�� �浹���� �� ���ǿ� ���� Canvas ����
            if (allGemsCollected)
            {
                // Gem�� ���� ���� ���¿��� Door�� �浹
                notyetCanvas.SetActive(false); // notyet Canvas ��Ȱ��ȭ
                endingCanvas.SetActive(true); // ending Canvas Ȱ��ȭ
            }
            else
            {
                // Gem�� ������ ���� ���¿��� Door�� �浹
                notyetCanvas.SetActive(true); // notyet Canvas Ȱ��ȭ
                endingCanvas.SetActive(false); // ending Canvas ��Ȱ��ȭ
            }
        }
    }

    void CheckAllGemsCollected()
    {
        // Gem�� ��� ��Ҵ��� Ȯ���ϴ� �Լ�
        if (gemCount >= 5)
        {
            allGemsCollected = true;
        }
        else
        {
            allGemsCollected = false;
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

    public void CloseYet()
    {
        notyetCanvas.SetActive(false); // Noti ĵ������ ��Ȱ��ȭ
        Time.timeScale = 1; // ������ �簳
    }
}
