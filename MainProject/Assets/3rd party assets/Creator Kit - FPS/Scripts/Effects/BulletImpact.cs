using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    public GameObject bulletHole;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 25 * Time.fixedDeltaTime, ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ImpactManager impactManager = ImpactManager.Instance;
        Instantiate(bulletHole, impactManager.GetImpactPosition(), Quaternion.FromToRotation(Vector3.up, impactManager.GetImpactNormal()));
        if (collision.gameObject.tag == "Burgler") {
            impactManager.PlayImpact();

            Burglar burglar = collision.transform.gameObject.GetComponent<Burglar>();
            if (PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.DeleteKey("Score");
            }
            PlayerPrefs.SetInt("Score", burglar.getValue());
            Weapon.points.Add(PlayerPrefs.GetInt("Score"));

            ShootSceneStateManager.Instance.ToggleAppState(ShootState.Shoot_Complete);
            ManagerHandler.managerHandler.shootSceneScript.setBurglarSpeed(1f);
            burglar.DieAnimation();

        }
            
        /*  ImpactManager impactManager = ImpactManager.Instance;
          Instantiate(bulletHole, impactManager.GetImpactPosition(), Quaternion.FromToRotation(Vector3.up, impactManager.GetImpactNormal()));
          if (collision.gameObject.tag == "Burgler")
          {
              impactManager.PlayImpact();

              impactManager.InvokeTheEvent(collision.gameObject.GetComponent<Burgler>().getValue());

          }

      }*/
        /*  private void OnCollisionExit(Collision collision)
          {
               ImpactManager impactManager=ImpactManager.Instance;
              Instantiate(bulletHole, impactManager.GetImpactPosition(), Quaternion.FromToRotation(Vector3.up, impactManager.GetImpactNormal()));
              if (collision.gameObject.tag=="Burgler")
                  impactManager.PlayImpact();
          }*/
    }
}
