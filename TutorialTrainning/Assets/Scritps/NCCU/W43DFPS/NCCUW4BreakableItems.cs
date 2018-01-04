using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class NCCUW4BreakableItems : MonoBehaviour {

    [System.Serializable]
    public class BreakingEntry
    {
        public GameObject BreakNote;
        public float BreakingHP;
    }

    public float CurrentHP;
    public List<BreakingEntry> BreakingSettings;
    public GameObject DestroyEffect;

    public void Hit(float hitValue)
    {
        //Debug.Log("Get Hit");
        if (CurrentHP >0)
        {
            CurrentHP -= hitValue;
            if (CurrentHP<=0)
            {
                DestroyEffect.gameObject.SetActive(true);
                this.transform.DOScale(new Vector3(0, 0, 0), 0.1f).SetDelay(0.1f).OnComplete(() => 
                {
                    Invoke("DisableFX", 10);
                }
                );
            }
            else
            {
                foreach (BreakingEntry entry in BreakingSettings)
                {
                    if (CurrentHP < entry.BreakingHP)
                    {
                        entry.BreakNote.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void DisableFX()
    {
        ParticleSystem[] FXs = this.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem Fx in FXs)
        {
            Fx.Stop();
        }
        Invoke("killSelf", 5);
    }

    public void killSelf()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void Start()
    {
        if (this.gameObject.GetComponent<NCCUW4BreakableItems>())
        {
           Debug.Log("NCCUW4BreakableItems");
        }
    }

}
