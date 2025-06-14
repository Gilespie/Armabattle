using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _timerText;

    [SerializeField] private Player _player;
    [SerializeField] private Timer _timer;
    [SerializeField] private AmmoStorage _ammo;
    private Weapon _weapon;

    private void OnEnable()
    {
        Timer.OnEveryTick += ShowTimer;
        _player.OnHealthChanged += ShowHealth;
        _player.OnWeaponChanged += HandleWeaponChanged;
    }

    private void Start()
    {
        ShowTimer();
        ShowHealth();
        HandleWeaponChanged(_weapon);
    }

    private void OnDisable()
    {
        Timer.OnEveryTick -= ShowTimer;
        _player.OnHealthChanged -= ShowHealth;
        _player.OnWeaponChanged -= HandleWeaponChanged;

        if (_weapon != null)
        {
            _weapon.OnAmmoChanged -= ShowAmmo;
        }
    }

    public void ShowHealth()
    {
        _healthText.SetText($"{_player.CurrentHealth}/{_player.MaxHealth}");
    }

    public void ShowAmmo()
    {
        _ammoText.SetText($"{_weapon.CurrentCapacity}/{_ammo.GetAmmoCount(_weapon.GetAmmoType())}");
    }

    private void HandleWeaponChanged(Weapon weapon)
    {
        if (_weapon != null)
        {
            _weapon.OnAmmoChanged -= ShowAmmo;
        }

        _weapon = weapon;

        if (_weapon != null)
        {
            _weapon.OnAmmoChanged += ShowAmmo;
            ShowAmmo();
        }
    }

    public void ShowTimer()
    {
        int roundedTime = Mathf.FloorToInt(_timer.CurrentTime);
        int minutes = roundedTime / 60;
        int seconds = roundedTime % 60;
        _timerText.SetText($"{minutes}:{seconds}");
    }
}