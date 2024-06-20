using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // 플레이어 이동 속도
    private Rigidbody2D rb;
    public GameObject notiCanvas; // Noti Canvas를 연결하기 위한 변수
    public TMPro.TextMeshProUGUI notiText; // Noti Canvas 내의 TextMeshProUGUI
    private GameObject currentGem; // 현재 충돌한 Gem을 저장하기 위한 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Z축 회전을 고정
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        notiCanvas.SetActive(false); // 시작할 때 noti 캔버스를 비활성화
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            // Gem과 충돌하면 noti 캔버스를 보이게 하고 텍스트를 업데이트
            Gem gem = other.gameObject.GetComponent<Gem>();
            if (gem != null)
            {
                notiText.text = gem.gemDescription; // Gem의 설명으로 텍스트 업데이트
                notiCanvas.SetActive(true);
                currentGem = other.gameObject; // 현재 충돌한 Gem 저장
                Time.timeScale = 0; // 게임을 일시정지
            }
        }
    }

    public void CloseNoti()
    {
        notiCanvas.SetActive(false); // Noti 캔버스를 비활성화
        Time.timeScale = 1; // 게임을 재개
        if (currentGem != null)
        {
            Destroy(currentGem); // 현재 충돌한 Gem 제거
            currentGem = null; // currentGem 변수 초기화
        }
    }
}
