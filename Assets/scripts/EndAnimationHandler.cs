using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnimationHandler : MonoBehaviour
{
    public Animator animator;
    private bool animationEnded = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 애니메이션이 끝났는지 체크
        if (!animationEnded && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animationEnded = true;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            Debug.Log("게임을 종료합니다.");
        }
    }
}
