using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private Player _player;
    [SerializeField] private Timer _timer;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Ammo _ammo;

    public void ShowUI()
    {

    }
}