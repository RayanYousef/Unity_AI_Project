using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AI_Game
{
    public enum CharacterType { ground, aerial }

    public class CS_StatsManager : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] Image healthBar;
        [SerializeField] float currentHP, maxHp;

        [Header("Type")]
        [SerializeField] CharacterType charType;

        public CharacterType CharType { get => charType; }

        // Start is called before the first frame update
        void Start()
        {
            if (!gameObject.CompareTag("Leader") && !gameObject.CompareTag("Base"))
                maxHp *= Random.Range(1, 4);
            
            currentHP = maxHp;
            healthBar.transform.localScale = new Vector3(currentHP/maxHp, 1, 1);  
        }

        // Update is called once     per frame
        void Update()
        {

        }

        public void Damage(float amount)
        {
            currentHP -= amount;
            currentHP = Mathf.Clamp(currentHP, 0, maxHp);
            healthBar.transform.localScale = new Vector3(currentHP / maxHp, 1, 1);
            if (currentHP == 0)
            {
                gameObject.SetActive(false);
                
                if (gameObject.CompareTag("Base"))
                {
                    GameManager.Instance.EndGame();
                    Debug.Log("End Game");
                    return;
                }
                GameManager.Instance.PlayDeathSound();
            }

        }
    }
}
