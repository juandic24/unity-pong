using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class GameModeDropdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown.ClearOptions();

        var gameModes = Enum.GetValues(typeof(GameMode))
                               .Cast<GameMode>()
                               .ToList();

        dropdown.AddOptions(gameModes.Select(d => d.ToString()).ToList());

        // Setear valor inicial SIN disparar el evento
        dropdown.SetValueWithoutNotify(
            gameModes.IndexOf(GameController.Instance.GameMode)
        );
        dropdown.RefreshShownValue();

    }
}
