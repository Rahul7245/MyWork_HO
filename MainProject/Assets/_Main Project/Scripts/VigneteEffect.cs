using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VigneteEffect : MonoBehaviour
{
    public static VigneteEffect Instance  { get; protected set; }
    PostProcessVolume postProcessVolume;
    Vignette vignette;
    bool m_isFilling=false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        postProcessVolume = gameObject.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isFilling)
        VigneteEffectFill();
    }
    void VigneteEffectFill() {
        
        if(vignette.intensity.value<0.512f)
            vignette.intensity.value += 0.2f*Time.deltaTime;
    }
    public void VigneteEffectStart() {
        m_isFilling = true;
    }
    public void ResetVignete()
    {
        m_isFilling = false;
        vignette.intensity.value = 0;
    }

}
