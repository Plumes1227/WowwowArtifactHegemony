using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class TeamMPController : MonoBehaviour
    {
        [SerializeField] private int _defaultMp = 3;
        private TeamMPStatus[] _teamMpStatusArray;
        private Dictionary<TeamMPStatus, int> _teamMpDictionary = new();
        private int _topMP;

        private void Start()
        {
            _teamMpStatusArray = GetComponentsInChildren<TeamMPStatus>();
            _topMP = _defaultMp;
            foreach (var teamMpStatus in _teamMpStatusArray)
            {
                teamMpStatus.OnMPAdded += AddTeamMp;
                teamMpStatus.OnMPDeducted += DeductedTeamMP;
                _teamMpDictionary.Add(teamMpStatus, _defaultMp);
                teamMpStatus.UpdateMpBar(_defaultMp, _topMP);
            }
        }

        private void AddTeamMp(TeamMPStatus team)
        {
            _teamMpDictionary[team]++;
            if (_teamMpDictionary[team] > _topMP) _topMP = _teamMpDictionary[team];

            UpdateAllTeamMpStatus();
        }


        private void DeductedTeamMP(TeamMPStatus team)
        {
            _teamMpDictionary[team]--;
            _topMP = 0;
            foreach (var keyValuePair in _teamMpDictionary)
            {
                _topMP = keyValuePair.Value >= _topMP ? keyValuePair.Value : _topMP;
            }

            UpdateAllTeamMpStatus();
        }

        private void UpdateAllTeamMpStatus()
        {
            foreach (var keyValuePair in _teamMpDictionary)
            {
                keyValuePair.Key.UpdateMpBar(keyValuePair.Value, _topMP);
            }
        }
    }
}