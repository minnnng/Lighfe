using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // 플레이어 이동 속도
    private Rigidbody2D rb;
    public GameObject notiCanvas; // Noti Canvas를 연결하기 위한 변수
    public GameObject notyetCanvas; // Gem을 전부 모으지 못했을 때 나타날 Canvas
    public GameObject endingCanvas; // Gem을 전부 모은 후 나타날 Canvas
    public TMPro.TextMeshProUGUI notiText; // Noti Canvas 내의 TextMeshProUGUI
    private int gemCount = 0; // 현재 모은 Gem의 개수
    private bool allGemsCollected = false; // Gem을 전부 모았는지 여부를 나타내는 변수
    private GameObject currentGem; // 현재 충돌한 Gem을 저장하기 위한 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Z축 회전을 고정
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        notiCanvas.SetActive(false); // 시작할 때 noti 캔버스를 비활성화
        notyetCanvas.SetActive(false); // 시작할 때 notyet 캔버스를 비활성화
        endingCanvas.SetActive(false); // 시작할 때 ending 캔버스를 비활성화
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
                gemCount++; // Gem 카운트 증가
                notiText.text = gem.gemDescription; // Gem의 설명으로 텍스트 업데이트
                notiCanvas.SetActive(true);
                Time.timeScale = 0; // 게임을 일시정지
                currentGem = other.gameObject; // 현재 충돌한 Gem 저장

                // 모든 Gem을 모았는지 확인
                CheckAllGemsCollected();
            }
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            // Door와 충돌했을 때 조건에 따라 Canvas 띄우기
            if (allGemsCollected)
            {
                // Gem을 전부 모은 상태에서 Door와 충돌
                notyetCanvas.SetActive(false); // notyet Canvas 비활성화
                endingCanvas.SetActive(true); // ending Canvas 활성화
            }
            else
            {
                // Gem을 모으지 못한 상태에서 Door와 충돌
                notyetCanvas.SetActive(true); // notyet Canvas 활성화
                endingCanvas.SetActive(false); // ending Canvas 비활성화
            }
        }
    }

    void CheckAllGemsCollected()
    {
        // Gem을 모두 모았는지 확인하는 함수
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
        notiCanvas.SetActive(false); // Noti 캔버스를 비활성화
        Time.timeScale = 1; // 게임을 재개
        if (currentGem != null)
        {
            Destroy(currentGem); // 현재 충돌한 Gem 제거
            currentGem = null; // currentGem 변수 초기화
        }
    }

    public void CloseYet()
    {
        notyetCanvas.SetActive(false); // Noti 캔버스를 비활성화
        Time.timeScale = 1; // 게임을 재개
    }
}
