using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace FireTruck_Sim
{
    public class UIManager : Singleton<UIManager>
    {
        int truckFuel;
        public Text TruckFuel_txt;

        int animalsSaved;
        public Text animalsSaved_txt;
        int pauseTime = 0;

        int enemyCarRemaining = 5;
        public Text enemyCarRemaining_txt;

        int fireRemain = 5;
        public Text FireRemain_txt;

        [SerializeField] GameObject GameScreenIcon;
        [SerializeField] GameObject GameOverMenu;
        [SerializeField] GameObject GameWonMenu;

        public int TruckFuel { get => truckFuel; set => truckFuel = value; }
        public int EnemyCarRemaining { get => enemyCarRemaining; set => enemyCarRemaining = value; }
        public int AnimalsSaved { get => animalsSaved; set => animalsSaved = value; }
        public int FireRemain { get => fireRemain; set => fireRemain = value; }

        IEnumerator FuelUpdateRoutine;

        void StartFuelUpdateRoutine()
        {
            if (FuelUpdateRoutine!=null)
            {
                StopCoroutine(FuelUpdateRoutine);
            }
            FuelUpdateRoutine = FuelUpdaterRoutine();
            StartCoroutine(FuelUpdateRoutine);
        }
        IEnumerator FuelUpdaterRoutine()
        {
            truckFuel = 100;
            enemyCarRemaining = 5;
            animalsSaved = 0;
            while (true)
            {
                if (truckFuel < 1)
                {
                    Time.timeScale = pauseTime;
                    GameOverIcon();
                    break;
                }
                UpdateText();
                yield return new WaitForSeconds(0.6f);
            }
        }
        private void Start()
        {
            StartFuelUpdateRoutine();
        }
        private void UpdateText()
        {
            if (TruckFuel_txt)
            {
                TruckFuel_txt.text = truckFuel.ToString();
            }
            if (animalsSaved_txt)
            {
                animalsSaved_txt.text = animalsSaved.ToString();
            }
            if (enemyCarRemaining_txt)
            {
                enemyCarRemaining_txt.text = enemyCarRemaining.ToString();
            }
            if (FireRemain_txt)
            {
                FireRemain_txt.text = fireRemain.ToString();
            }
            truckFuel--;
        }
        void GameOverIcon()
        {
            if (GameScreenIcon)
            {
                GameScreenIcon.SetActive(false);
            }
            if (GameOverMenu)
            {
                GameOverMenu.SetActive(true);
            }
        }
        public void GameWon()
        {
            if (GameScreenIcon)
            {
                GameScreenIcon.SetActive(false);
            }
            if (GameOverMenu)
            {
                GameOverMenu.SetActive(true);
            }
            Time.timeScale = pauseTime;
        }
        public void ReloadGame()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Time.timeScale = 1f;
        }
    }
}