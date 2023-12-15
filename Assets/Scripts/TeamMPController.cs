using UnityEngine;

namespace DefaultNamespace
{
    public class TeamMPController : MonoBehaviour
    {
        private TeamMPStatus[] _teamMpStatusArray;
        private int _topMP;

        private void Start()
        {
            _teamMpStatusArray = GetComponentsInChildren<TeamMPStatus>();
            foreach (var teamMpStatus in _teamMpStatusArray)
            {
                teamMpStatus.OnMPUpdate += UpdateTopMP;
                teamMpStatus.UpdateMpBar(_topMP);
            }
        }

        private void UpdateTopMP(int teamMp)
        {
            if (teamMp > _topMP) _topMP = teamMp;

            foreach (var teamMpStatus in _teamMpStatusArray)
            {
                teamMpStatus.UpdateMpBar(_topMP);
            }
        }
    }
}