using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupText; // UI 텍스트 참조
    private bool isPlayerInRange = false;
    public RawImage carrotimage;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered item range.");
            isPlayerInRange = true;

            GameManager.Instance.PickupCarrot();

            if (pickupText != null)
            {
                pickupText.gameObject.SetActive(true); // 텍스트 활성화
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited item range.");
            isPlayerInRange = false;

            if (pickupText != null)
            {
                pickupText.gameObject.SetActive(false); // 텍스트 비활성화
            }
        }
    }

    void Start()
    {
        Debug.Log("Script success");
        carrotimage.enabled = false;

        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false); // 텍스트 비활성화
        }
    }

    void Update()
    {
        // E 키를 누르면 아이템을 획득
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed while player is in range.");
            Pickup();
        }
    }

    void Pickup()
    {
        // 아이템 획득 로직을 여기에 구현
        Debug.Log("아이템을 획득했습니다!");

        carrotimage.enabled = true;

        gameObject.SetActive(false); //아이템 비활성화

        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false); // 텍스트 비활성화
        }
        
    }
}
