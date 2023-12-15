using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TeamMPStatus : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button plusButton;
        [SerializeField] private Button minusButton;

        private int mp;
        private int TopMP;

        private void Start()
        {
            plusButton.onClick.AddListener(AddScore);
            minusButton.onClick.AddListener(DeductedScore);
        }
        
        private void AddScore()
        {
            mp++;
            UpdateTopScore();
            image.fillAmount = mp / TopMP;
        }

        private void UpdateTopScore()
        {
            if (mp > TopMP) TopMP = mp;
        }

        private void DeductedScore()
        {
            mp--;
            UpdateTopScore();
            image.fillAmount = mp / TopMP;
        }
    }
}