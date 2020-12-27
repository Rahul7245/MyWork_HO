using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class AmmoInventoryEntry
{
    [AmmoType]
    public int ammoType;
    public int amount = 0;
}

public class Controller : MonoBehaviour
{
    //Urg that's ugly, maybe find a better way
    public static Controller Instance { get; protected set; }

    public Camera MainCamera;
    public Camera WeaponCamera;

    public Transform CameraPosition;
    public Transform WeaponPosition;

    public Weapon[] startingWeapons;

    //this is only use at start, allow to grant ammo in the inspector. m_AmmoInventory is used during gameplay
    public AmmoInventoryEntry[] startingAmmo;

    [Header("Control Settings")]
    public float MouseSensitivity = 100.0f;
    public float PlayerSpeed = 5.0f;
    public float RunningSpeed = 7.0f;
    public float JumpSpeed = 5.0f;

    [Header("Audio")]
    public RandomPlayer FootstepPlayer;
    public AudioClip JumpingAudioCLip;
    public AudioClip LandingAudioClip;

    float m_VerticalSpeed = 0.0f;
    bool m_IsPaused = false;
    int m_CurrentWeapon;

    float m_VerticalAngle, m_HorizontalAngle;
    public float Speed { get; private set; } = 0.0f;

    public bool LockControl { get; set; }
    public bool CanPause { get; set; } = true;

    public bool Grounded => m_Grounded;

    CharacterController m_CharacterController;

    bool m_Grounded;
    float m_GroundedTimer;
    float m_SpeedAtJump = 0.0f;

    List<Weapon> m_Weapons = new List<Weapon>();
    Dictionary<int, int> m_AmmoInventory = new Dictionary<int, int>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/

        m_IsPaused = false;
        m_Grounded = true;

        MainCamera.transform.SetParent(CameraPosition, false);
        MainCamera.transform.localPosition = Vector3.zero;
        MainCamera.transform.localRotation = Quaternion.identity;
        m_CharacterController = GetComponent<CharacterController>();

        for (int i = 0; i < startingWeapons.Length; ++i)
        {
            PickupWeapon(startingWeapons[i]);
        }

        for (int i = 0; i < startingAmmo.Length; ++i)
        {
            ChangeAmmo(startingAmmo[i].ammoType, startingAmmo[i].amount);
        }

        m_CurrentWeapon = -1;
        ChangeWeapon(0);

        for (int i = 0; i < startingAmmo.Length; ++i)
        {
            m_AmmoInventory[startingAmmo[i].ammoType] = startingAmmo[i].amount;
        }

        // m_VerticalAngle = 0.0f;
        // m_HorizontalAngle = transform.localEulerAngles.y;
    }
    bool pressed = false;
    public void setMRotations()
    {
        m_VerticalAngle = CameraPosition.transform.localEulerAngles.x;
        m_HorizontalAngle = CameraPosition.transform.localEulerAngles.y;
    }
    float m_turnX = 0f;
    float m_turnY = 0f;
    public static float mouse;
    public void ChangeMouseSensitivity(float mouseSensitivity)
    {
        MouseSensitivity = mouseSensitivity;
    }
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonUp(0)) {
            FireButton();
        }
#endif
        bool wasGrounded = m_Grounded;
        bool loosedGrounding = false;

        //we define our own grounded and not use the Character controller one as the character controller can flicker
        //between grounded/not grounded on small step and the like. So we actually make the controller "not grounded" only
        //if the character controller reported not being grounded for at least .5 second;
        if (!m_CharacterController.isGrounded)
        {
            if (m_Grounded)
            {
                m_GroundedTimer += Time.deltaTime;
                if (m_GroundedTimer >= 0.5f)
                {
                    loosedGrounding = true;
                    m_Grounded = false;
                }
            }
        }
        else
        {
            m_GroundedTimer = 0.0f;
            m_Grounded = true;
        }

        Speed = 0;
        Vector3 move = Vector3.zero;
        if (!m_IsPaused && !LockControl)
        {
            //For Android use touch
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftAlt))
#else
            if (Input.mousePosition.x < Screen.width / 2 && Input.touches[0].phase == TouchPhase.Moved)
#endif
            {
                float turnPlayer = Input.GetAxis("Mouse X");
                if (turnPlayer > 6) turnPlayer = m_turnX;
                if (turnPlayer < -6) turnPlayer = m_turnX;
                m_turnX = turnPlayer;
                turnPlayer = turnPlayer * MouseSensitivity * (MainCamera.fieldOfView / 100);
                m_HorizontalAngle = m_HorizontalAngle + turnPlayer;
                if (m_HorizontalAngle > 360) m_HorizontalAngle -= 360.0f;
                if (m_HorizontalAngle < 0) m_HorizontalAngle += 360.0f;
                Vector3 currentAngles = CameraPosition.transform.localEulerAngles;
                // Camera look up/down
                var turnCam = -Input.GetAxis("Mouse Y");
                if (turnCam > 6) turnCam = m_turnY;
                if (turnCam < -6) turnCam = m_turnY;
                m_turnY = turnCam;
                turnCam = turnCam * MouseSensitivity * (MainCamera.fieldOfView / 100);
                m_VerticalAngle = Mathf.Clamp(turnCam + m_VerticalAngle, -89.0f, 89.0f);
                // currentAngles = CameraPosition.transform.localEulerAngles;
                currentAngles.x = m_VerticalAngle;
                currentAngles.y = m_HorizontalAngle;
                CameraPosition.transform.localEulerAngles = currentAngles;
            }
            Speed = move.magnitude / (PlayerSpeed * Time.deltaTime);
        }
    }
    public void FireButton()
    {
        m_Weapons[m_CurrentWeapon].OnFireButtonClick();
    }
    public void ScopeButton()
    {
        m_Weapons[m_CurrentWeapon].OnScopeButtonClick();
    }
    public void InactiveScope()
    {

        m_Weapons[m_CurrentWeapon].InactiveScopeOverlay();
    }
    public void DisplayCursor(bool display)
    {
        /* m_IsPaused = display;
         Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
         Cursor.visible = display;*/
    }

    void PickupWeapon(Weapon prefab)
    {
        //TODO : maybe find a better way than comparing name...
        if (m_Weapons.Exists(weapon => weapon.name == prefab.name))
        {//if we already have that weapon, grant a clip size of the ammo type instead
            ChangeAmmo(prefab.ammoType, prefab.clipSize);
        }
        else
        {
            var w = Instantiate(prefab, WeaponPosition, false);
            w.name = prefab.name;
            w.transform.localPosition = Vector3.zero;
            w.transform.localRotation = Quaternion.identity;
            w.gameObject.SetActive(false);

            w.PickedUp(this);

            m_Weapons.Add(w);
        }
    }

    void ChangeWeapon(int number)
    {
        if (m_CurrentWeapon != -1)
        {
            m_Weapons[m_CurrentWeapon].PutAway();
            m_Weapons[m_CurrentWeapon].gameObject.SetActive(false);
        }

        m_CurrentWeapon = number;

        if (m_CurrentWeapon < 0)
            m_CurrentWeapon = m_Weapons.Count - 1;
        else if (m_CurrentWeapon >= m_Weapons.Count)
            m_CurrentWeapon = 0;

        m_Weapons[m_CurrentWeapon].gameObject.SetActive(true);
        m_Weapons[m_CurrentWeapon].Selected();
    }

    public int GetAmmo(int ammoType)
    {
        int value = 0;
        m_AmmoInventory.TryGetValue(ammoType, out value);

        return value;
    }

    public void ChangeAmmo(int ammoType, int amount)
    {
        if (!m_AmmoInventory.ContainsKey(ammoType))
            m_AmmoInventory[ammoType] = 0;

        var previous = m_AmmoInventory[ammoType];
        m_AmmoInventory[ammoType] = Mathf.Clamp(m_AmmoInventory[ammoType] + amount, 0, 999);

        if (m_Weapons[m_CurrentWeapon].ammoType == ammoType)
        {
            if (previous == 0 && amount > 0)
            {//we just grabbed ammo for a weapon that add non left, so it's disabled right now. Reselect it.
                m_Weapons[m_CurrentWeapon].Selected();
            }

            WeaponInfoUI.Instance.UpdateAmmoAmount(GetAmmo(ammoType));
        }
    }

    public void PlayFootstep()
    {
        FootstepPlayer.PlayRandom();
    }
}
