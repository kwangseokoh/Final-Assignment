using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  

    void Awake()
    {
        // 인스턴스가 존재하지 않으면 자기 자신으로 설정하고, 그렇지 않으면 중복된 인스턴스를 파괴합니다.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬이 변경되어도 유지되도록 설정
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    // 아이템을 획득한 후 호출되는 메서드
    public void PickupCarrot()
    {
        // 토끼 대화 스크립트를 찾아서 플레이어가 당근을 획득했음을 알립니다.
        RabbitTalk rabbitDialogue = FindObjectOfType<RabbitTalk>();
        if (rabbitDialogue != null)
        {
            rabbitDialogue.SetHasCarrot(true);
        }
    }

    // 게임 클리어 시 호출되는 메서드
    public void CompleteGame()
    {
        // 게임 클리어 처리
        Debug.Log("Congratulations! You completed the game!");

        // EndingScene으로 전환합니다.
        SceneManager.LoadScene("EndingScene");
    }
}
