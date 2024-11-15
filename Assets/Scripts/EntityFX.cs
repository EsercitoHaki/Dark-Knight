using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    protected SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material originalMat;

    [Header("Ailment colors")]
    [SerializeField] private Color[] chillColor;
    [SerializeField] private Color[] igniteColor;
    [SerializeField] private Color[] shockColor;

    [Header("Hit FX")]
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject criticalHitFx;


    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    public void MakeTransprent(bool _transprent)
    {
        if (_transprent)
        {
            sr.color = Color.clear;
        }
        else
        {
            sr.color = Color.white;
        }
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;

        sr.color = Color.white;
        yield return new WaitForSeconds(flashDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if(sr.color != Color.white)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.red;
        }
    }

    private void CancelColorChange()
    {
        CancelInvoke();
        sr.color = Color.white;
    }

    public void ShockFxFor(float _seconds)
    {
        InvokeRepeating("ShockColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }

    public void ChillFxFor(float _seconds)
    {
        InvokeRepeating("ChillColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }

    public void IgniteFxFor(float _seconds)
    {
        InvokeRepeating("IgniteColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }

    private void IgniteColorFx()
    {
        if(sr.color != igniteColor[0])
        {
            sr.color = igniteColor[0];
        }
        else
        {
            sr.color = igniteColor[1];
        }
    }

    private void ShockColorFx()
    {
        if(sr.color != shockColor[0])
        {
            sr.color = shockColor[0];
        }
        else
        {
            sr.color = shockColor[1];
        }
    }

    private void ChillColorFx()
    {
        if(sr.color != chillColor[0])
        {
            sr.color = chillColor[0];
        }
        else
        {
            sr.color = chillColor[1];
        }
    }

    public void CreateHitFx(Transform _target, bool _critical)
    {
        float yRotation = 0;
        
        if (GetComponent<Entity>().facingDir == -1)
        {
            yRotation = 180;
        }
        

        Vector3 hitFxRotation = new Vector3(0, yRotation, 0); // Giữ nguyên góc xoay, chỉ điều chỉnh theo hướng nhân vật

        GameObject hitPrefab = _critical ? criticalHitFx : hitFx;

        // Tạo đối tượng hiệu ứng va chạm tại vị trí _target với góc xoay đã được chỉnh sửa
        GameObject newHitFx = Instantiate(hitPrefab, _target.position, Quaternion.Euler(hitFxRotation));
        Destroy(newHitFx, .2f);
    }

}
