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
        int pauseTime = 0;

        [SerializeField] GameObject GameScreenIcon;
        [SerializeField] GameObject GameOverMenu;

        public int TruckFuel { get => truckFuel; set => truckFuel = value; }

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
        public void ReloadGame()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Time.timeScale = 1f;
        }
    }
}