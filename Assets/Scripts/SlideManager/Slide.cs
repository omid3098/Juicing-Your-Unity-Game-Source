using System;
using BrunoMikoski.AnimationSequencer;
using UnityEngine;
using static BrunoMikoski.AnimationSequencer.AnimationSequencerController;

public class Slide : MonoBehaviour
{
    // This class is the base class for all slides
    // It is attached to all slides in the scene
    // It has a show and hide method that can be converter to tweening or other animations
    AnimationSequencerController animation
    {
        get
        {
            if (_animation == null)
                _animation = GetComponent<AnimationSequencerController>();
            return _animation;
        }
        set => _animation = value;
    }
    AnimationSequencerController _animation;

    void Awake()
    {
        if (animation == null)
            animation = GetComponent<AnimationSequencerController>();
    }

    public void Show(Action onComplete = null)
    {
        // Show the slide
        gameObject.SetActive(true);
        animation.PlayForward(true, onComplete);
    }

    public void Hide(Action onComplete = null)
    {
        // Hide the slide
        animation.ClearPlayingSequence();
        animation.PlayBackwards(true, () =>
        {
            gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }
}
