using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Player.Properties;
using System;


namespace Player
{
    public class PlayerController : MonoBehaviour
    {
		public const string PlayerTag = "Player";

        public static PlayerController Instance { get; private set; }

        [SerializeField]
        private string[] _magneticTags;

        [SerializeField]
        private string[] _environmentTags;

        private PlayerPropertiesBase[] properties;
        private Affectable[] affectables;
        private Rigidbody rb;

        private bool isMagnetic = false;
        private bool isExplode = false;
        private bool isJump = false;
        private bool isShift = false;

        private bool isJumpLock = false;
        private float lockDelay = 3.0f;
        private float nextLockDelay;

		private MagneticPlayerProperties magnetic;
		private ExplodePlayerProperties explode;
		private MovePlayerProperties move;
		private EnergyPlayerProperties energy;
		private JumpPlayerProperties jump;

        public static List<PlayerActions> Actions { get; set; }

		public static Action OnPlayerDied;
        public static Action<int, int> OnEnergyChanged;

		public string[] MagneticTags { get { return _magneticTags; } }

        private void OnEnable()
        {
            Instance = this;
            properties = GetComponents<PlayerPropertiesBase>();
            affectables = GetComponents<Affectable>();
            Actions = new List<PlayerActions>();
            rb = GetComponent<Rigidbody>();

			magnetic = PlayerPropertiesBase.GetByType<MagneticPlayerProperties>(properties);
			explode = PlayerPropertiesBase.GetByType<ExplodePlayerProperties> (properties);
			move = PlayerPropertiesBase.GetByType<MovePlayerProperties> (properties);
			energy = PlayerPropertiesBase.GetByType<EnergyPlayerProperties> (properties);
			jump = PlayerPropertiesBase.GetByType<JumpPlayerProperties>(properties);
        }

		private void OnDisable()
        {
            affectables = null;
            properties = null;
			Actions = null;
            rb = null;

			magnetic = null;
			explode = null;
			move = null;
			energy = null;
			jump = null;
		}

        // process magnetic
        private void OnTriggerStay(Collider col)
        {
            if (isMagnetic)
            {
                if (_magneticTags.Contains(col.tag))
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(magnetic.Properties.force, transform.position, magnetic.Properties.radius);
                    }
                }
            }

            if (isExplode)
            {
                if (_magneticTags.Contains(col.tag))
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(explode.Properties.force, transform.position, explode.Properties.radius);
                    }
                }
            }

            if (isJumpLock)
            {
                if (_environmentTags.Contains(col.tag))
                {
                    if (Time.time > nextLockDelay)
                    {
                        isJumpLock = false;
                        Debug.Log("Lock Free");
                    }
                }
            }

        }

        //process input
        private void FixedUpdate()
        {
            if (isExplode)
                isExplode = !isExplode;

            ProcessInput();
            ProcessEnergyReduction();
            ProcessEnergyRestore();
        }

        private void Update()
        {
            if (isJump)
            {
                rb.AddForce(new Vector3(0, jump.Properties.force * rb.mass, 0));
                isJump = false;
            }

            if (isShift)
            {
                ShiftPlayerProperties shift = PlayerPropertiesBase.GetByType<ShiftPlayerProperties>(properties);

                if (rb.velocity.x > 0)
                    transform.position = transform.position + new Vector3(shift.Properties.shiftDistance, 0, 0);
                else
                    transform.position = transform.position + new Vector3(- shift.Properties.shiftDistance, 0, 0);

                isShift = false;
            }
        }

        private void ProcessInput()
        {
            if (Actions.Contains(PlayerActions.MoveLeft))
            {
                if (rb.velocity.x > -move.Properties.linearVelocityLimit * rb.mass)
                    rb.AddForce(new Vector3(-move.Properties.linearVelocity * rb.mass, 0, 0));

                if (rb.angularVelocity.z < move.Properties.angularVelocityLimit * rb.mass)
                    rb.AddTorque(new Vector3(0, 0, move.Properties.angularVelocity * rb.mass));
            }

            if (Actions.Contains(PlayerActions.MoveRight))
            {
                if (rb.velocity.x < move.Properties.linearVelocityLimit * rb.mass)
                    rb.AddForce(new Vector3(move.Properties.linearVelocity * rb.mass, 0, 0));

                if (rb.angularVelocity.z > -move.Properties.angularVelocityLimit * rb.mass)
                    rb.AddTorque(new Vector3(0, 0, -move.Properties.angularVelocity * rb.mass));
            }

            if (Actions.Contains(PlayerActions.Magnetic))
            {
                isMagnetic = true;
            }

            if (Actions.Contains(PlayerActions.Explode))
            {
                isExplode = true;
                Actions.Remove(PlayerActions.Explode);
            }

            if (Actions.Contains(PlayerActions.Jump))
            {
                if (!isJumpLock)
                {
                    isJump = true;
                    isJumpLock = true;
                    nextLockDelay = Time.time + lockDelay;
                }

                Actions.Remove(PlayerActions.Jump);
            }

            if (Actions.Contains(PlayerActions.Shift))
            {
                isShift = true;
                Actions.Remove(PlayerActions.Shift);
            }

            if (!Actions.Contains(PlayerActions.Magnetic))
            {
                isMagnetic = false;
            }
        }

        private void ProcessEnergyReduction()
        {
            ShiftPlayerProperties shift = PlayerPropertiesBase.GetByType<ShiftPlayerProperties>(properties);
            

            if (isMagnetic)
            {
                if (energy.Properties.currentValue - magnetic.Properties.energyCost <= 0)
                {
                    isMagnetic = false;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(-1, -1);
                }
                else
                {
                    energy.Properties.currentValue -= magnetic.Properties.energyCost;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(energy.Properties.currentValue, energy.Properties.maxValue);
                }
            }
               
            if (isJump)
            {
                if (energy.Properties.currentValue - jump.Properties.energyCost <= 0)
                {
                    isJump = false;
                    isJumpLock = false;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(-1, -1);
                }
                else
                {
                    energy.Properties.currentValue -= jump.Properties.energyCost;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(energy.Properties.currentValue, energy.Properties.maxValue);
                }
            }

            if (isExplode)
            {
                if (energy.Properties.currentValue - explode.Properties.energyCost <= 0)
                {
                    isExplode = false;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(-1, -1);
                }
                else
                {
                    energy.Properties.currentValue -= explode.Properties.energyCost;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(energy.Properties.currentValue, energy.Properties.maxValue);
                }
            }

            if (isShift)
            {
                if (energy.Properties.currentValue - shift.Properties.energyCost <= 0)
                {
                    isShift = false;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(-1, -1);
                }
                else
                {
                    energy.Properties.currentValue -= shift.Properties.energyCost;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(energy.Properties.currentValue, energy.Properties.maxValue);
                }
            }
        }

        private void ProcessEnergyRestore()
        {
            if (energy.Properties.currentValue < energy.Properties.maxValue)
            {
                if (Time.time > energy.Properties.nextRestoreTime)
                {
                    energy.Properties.currentValue += energy.Properties.restoreValue;
                    energy.Properties.nextRestoreTime = Time.time + energy.Properties.restoreSpeed;

                    if (OnEnergyChanged != null)
                        OnEnergyChanged(energy.Properties.currentValue, energy.Properties.maxValue);
                }
            }
        }

        public void ResetAffectables()
        {
            foreach (var a in affectables)
                a.Deactivate();
        }
    }
}
