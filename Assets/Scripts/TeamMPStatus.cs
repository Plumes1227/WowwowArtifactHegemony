using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TeamMPStatus : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button plusButton;
        [SerializeField] private Button minusButton;
        [SerializeField] private TextMeshProUGUI mpValueTMP;
        [SerializeField] private Button cardPlusButton;
        [SerializeField] private Button cardMinusButton;
        [SerializeField] private TextMeshProUGUI cardCountTMP;
        public Action<TeamMPStatus> OnMPAdded;
        public Action<TeamMPStatus> OnMPDeducted;
        private int _cardCount;

        private void Start()
        {
            plusButton.onClick.AddListener(AddScore);
            minusButton.onClick.AddListener(DeductedScore);
            cardPlusButton.onClick.AddListener(AddCardCount);
            cardMinusButton.onClick.AddListener(DeductedCardCount);
        }

        private void AddCardCount()
        {
            _cardCount++;
            UpdateCardCount(_cardCount);
        }

        private void DeductedCardCount()
        {
            _cardCount--;
            UpdateCardCount(_cardCount);
        }


        [Button]
        private void AddScore()
        {
            OnMPAdded.Invoke(this);
        }

        [Button]
        private void DeductedScore()
        {
            OnMPDeducted.Invoke(this);
        }

        public void UpdateMpBar(int mp, float topMp)
        {
            mpValueTMP.text = mp.ToString();
            image.fillAmount = mp / topMp;
        }

        private void UpdateCardCount(int cardCount)
        {
            cardCountTMP.text = cardCount.ToString();
        }
    }
}