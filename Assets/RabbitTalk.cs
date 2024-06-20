using UnityEngine;
using UnityEngine.UI;

public class RabbitTalk : MonoBehaviour
{
    public GameObject talkPromptText;  // "Press E to talk" 3D 텍스트 오브젝트
    public Text dialogueText;  // 대사를 표시할 UI 텍스트
    private bool isPlayerInRange = false;
    private bool hasCarrot = false;  // 당근을 획득했는지 여부
    private string[] dialogues = { "와 진짜 갖다줬네?", "고마워ㅎㅎ" };
    private int dialogueIndex = 0;

    void Start()
    {
        if (talkPromptText != null)
        {
            talkPromptText.SetActive(false);  // 처음에는 텍스트를 보이지 않게 설정
        }

        if (dialogueText != null)
        {
            dialogueText.text = "";  // 처음에는 대사를 비워둠
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (talkPromptText != null)
            {
                talkPromptText.SetActive(true);  // 플레이어가 범위에 들어오면 텍스트를 보이게 설정
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (talkPromptText != null)
            {
                talkPromptText.SetActive(false);  // 플레이어가 범위를 벗어나면 텍스트를 보이지 않게 설정
            }

            if (dialogueText != null)
            {
                dialogueText.text = "";  // 플레이어가 범위를 벗어나면 대사를 비움
            }
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasCarrot)
            {
                // 아직 당근을 획득하지 않은 경우
                dialogueText.text = "어이 친구! 배고프니까 당근 좀 가져다줘!";
            }
            else
            {
                // 당근을 획득한 경우
                Talk();
            }
        }
    }

    void Talk()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            // 토끼와 모든 대화가 끝난 경우 게임 클리어 조건을 확인하고 처리합니다.
            GameManager.Instance.CompleteGame();
        }
    }

    public void SetHasCarrot(bool value)
    {
        hasCarrot = value;
    }
}
