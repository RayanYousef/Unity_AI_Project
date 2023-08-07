
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace AI_Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] GameObject panel,panelBlackWin,panelWhiteWin;
        [SerializeField] GameObject BlackBase, WhiteBase;
        [SerializeField] AudioClip[] deathSounds; 

        // Start is called before the first frame update

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            panelBlackWin.SetActive(false);
            panelWhiteWin.SetActive(false);
        }


        void Start()
        {
            Time.timeScale = 0;
        }

        public void OnClickStartGame()
        {
            Time.timeScale = 1;
            panel.SetActive(false);
        }

        public void OnClickRestartScene()
        {
            SceneManager.LoadScene(0);
        }

        public void EndGame()
        {
            Debug.Log("End Game Activated");
            if(BlackBase.activeSelf)
            {
                panelBlackWin.SetActive(true);
            }
            else panelWhiteWin.SetActive(true);
            Time.timeScale = 0;

        }

        public void PlayDeathSound()
        {
            int random = Random.Range(0, 2);
            GetComponent<AudioSource>().PlayOneShot(deathSounds[random]);
        }

        public void IncreaseTimeScale()
        {
            Time.timeScale = 2;
        }

        public void ResetTimeScale()
        {
            Time.timeScale = 1;
        }
    }
}
