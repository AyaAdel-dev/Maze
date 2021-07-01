using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class opendoorup : MonoBehaviour
{
    public enum SlidingDoorState { None, Open, Close }
    [Header("References")]
    [SerializeField] Transform rightdoor = null;
    [SerializeField] Transform leftdoor = null;
    [Header("Settings")]
    [SerializeField] LayerMask layerstodetect = 0;
    [Range(1, 10)]
    [SerializeField] float speed = 5;
    [Range(.5f, 4.0f)]
    [SerializeField] float delay = 1;
    [SerializeField] float closexpos = 1;
    [SerializeField] float openxpos = 1;
    [Header("Audio")]
    [SerializeField] AudioClip openSFX = null;
    [SerializeField] AudioClip closeSFX = null;
    #region private
    private bool animating = false;
    private SlidingDoorState animatingState = SlidingDoorState.None;
    private SlidingDoorState State = SlidingDoorState.None;
    private List<Transform> inRange = new List<Transform>();
    private AudioSource source = null;
    public AudioSource Source
    {
        get
        {
            if (source == null)
            {
                source = GetComponent<AudioSource>();
                if (source == null)
                {
                    source = gameObject.AddComponent<AudioSource>();
                }
            }
            return source;
        }
    }
    IEnumerator IE_StartAnimating = null, IE_Animate = null, IE_OpenDoor = null;
    #endregion
    private void Start()
    {
        closexpos = Mathf.Abs(leftdoor.transform.position.x);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerstodetect) == 0) { return; }
        inRange.Add(other.transform);
        State = SlidingDoorState.Open;
        StartAnimating();
    }
    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerstodetect) == 0) { return; }
        inRange.Remove(other.transform);
        if (inRange.Count <= 0)
        {
            State = SlidingDoorState.Close;
        }

    }
    void StartAnimating()
    {
        if (IE_StartAnimating != null)
        {
            StopCoroutine(IE_StartAnimating);
        }
        IE_StartAnimating = Begin();
        StartCoroutine(IE_StartAnimating);
    }
    private IEnumerator Begin()
    {
        while (animating)
        {
            yield return null;
        }
        if (IE_Animate != null)
        {
            StopCoroutine(IE_Animate);
        }
        IE_Animate = Animate(State.Equals(SlidingDoorState.Open) ? openxpos : closexpos);
        StartCoroutine(IE_Animate);
    }
    private IEnumerator Animate(float xpos)
    {
        if (utility.Approximately(leftdoor.position.x, xpos, 0.00f))
        {
            yield break;
        }
        animatingState = State;
        yield return new WaitForSeconds(delay);
        if (IE_OpenDoor != null)
        {
            StopCoroutine(IE_OpenDoor);
        }
        IE_OpenDoor = Move(xpos:xpos);
        StartCoroutine(IE_OpenDoor);
        playsound(State.Equals(SlidingDoorState.Open)?openSFX:closeSFX );
        while (animating)
        {
            yield return null;
        }
    }
    private void playsound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    IEnumerator Move(float xpos)
    {
        animating = true;
        while (!utility.Approximately(leftdoor.position.x, xpos, 0.00f))
        {
            float newxpos = leftdoor.position.x;
            newxpos = Mathf.Lerp(newxpos, xpos, speed * Time.deltaTime);
            leftdoor.position = new Vector3(newxpos, leftdoor.position.y, leftdoor.position.z);
            rightdoor.position = new Vector3(-newxpos, rightdoor.position.y, rightdoor.position.z);
            yield return null;
        }
        animating = false;
    }
}







