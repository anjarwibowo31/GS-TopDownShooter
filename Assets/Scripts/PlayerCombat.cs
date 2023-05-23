using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static event EventHandler<OnAttackEventArgs> OnAttackButtonClicked;
    public class OnAttackEventArgs : EventArgs
    {
        public Vector3 aimPosition;
    }

    public static float AimAngle { get; private set; }

    //[SerializeField] private PlayerDataSO weaponUsed;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private float weaponSwitchSpeed = 2f;

    public int selectedWeapon;
    private float weaponSwitchCooldown = 0f;

    private void Start()
    {
        ChangeWeapon(selectedWeapon);
    }

    private void Update()
    {
        HandleAiming();
        HandleFacing();
        HandleAttack();
        HandleWeaponChange();
    }

    public static Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void HandleAiming()
    {
        Vector3 aimDirection = (GetMousePosition() - aimTransform.position).normalized;
        AimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }

    private void HandleFacing()
    {
        float aimLocalScale;

        if (AimAngle > 90 || AimAngle < -90)
        {
            aimLocalScale = -1f;
        }
        else
        {
            aimLocalScale = 1f;
        }

        transform.localScale = new Vector3(aimLocalScale, 1, 1);
        aimTransform.localScale = Vector3.one * aimLocalScale;
        aimTransform.localEulerAngles = new Vector3(0, 0, AimAngle * aimLocalScale);
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttackButtonClicked?.Invoke(this, new OnAttackEventArgs { aimPosition = GetMousePosition() });
        }
    }

    private void HandleWeaponChange()
    {
        if (weaponSwitchCooldown <= 0f)
        {
            int previousWeapon = selectedWeapon;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= weapons.Length - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
                weaponSwitchCooldown = weaponSwitchSpeed;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = weapons.Length - 1;
                else
                    selectedWeapon--;
                weaponSwitchCooldown = weaponSwitchSpeed;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedWeapon = 2;
            }


            if (previousWeapon != selectedWeapon) ChangeWeapon(selectedWeapon);
        }
        
        weaponSwitchCooldown -= Time.deltaTime;
    }

    private void ChangeWeapon(int weaponIndex)
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[weaponIndex].SetActive(true);
    }
}
