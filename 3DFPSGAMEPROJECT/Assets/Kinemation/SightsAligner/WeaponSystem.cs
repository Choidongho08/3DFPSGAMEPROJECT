using Kinemation.SightsAligner;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponPrefaps;
    [SerializeField] private CoreAnimComponent animComponent;
    [SerializeField] private Animator animator;

    private int _index;
    private bool _isReloading = true;

    private void Start()
    {

    }
    private void Update()
    {
        
    }

    private Weapon GetGun()
    {
        return weaponPrefaps[_index];
    }
    private void CycleWeapon()
    {
        foreach (var gun in weaponPrefaps)
        {
            ChangeWeapon();
            animComponent.aimData = gun.gunAimData;
            animComponent.CalculateAimData();   
        }
    }
    private void ChangeWeapon()
    {
        UnequipWeapon();

        _index++;
        _index = _index > weaponPrefaps.Count - 1 ? 0 : _index;

        EquipWeapon();
    }
    private void ToggleAim()
    {
        animComponent.aiming = !animComponent.aiming;
    }
    private void OnScopeChange()
    {
        animComponent.aimData.aimPoint = GetGun().GetScope();
    }
    private void UnequipWeapon()
    {
        GetGun().gameObject.SetActive(false);
        animComponent.aiming = false;
    }
    private void EquipWeapon()
    {
        var gun = GetGun();
        gun.gameObject.SetActive(true);

        animComponent.Init(gun.gunAimData, GetGun().GetScope());
    }
}
