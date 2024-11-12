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
        // �ִϸ��̼��� �������� üũ
        if (!animationEnded && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animationEnded = true;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            Debug.Log("������ �����մϴ�.");
        }
    }
}
