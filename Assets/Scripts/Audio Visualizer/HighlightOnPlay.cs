using UnityEngine;
using System.Collections;

public class HighlightOnPlay : MonoBehaviour {

	public GameObject animateTarget;

	private Sequencer seq;
	private bool playingCurrent;
	private int currentBeat;
	private ParticleSystem parts;

	void Awake ()
	{
		seq = transform.GetComponent<Sequencer>();
		parts = animateTarget.GetComponent<ParticleSystem>();
	}
	// Update is called once per frame
	void Update()
	{
		if (seq.IsPlaying)
		{
			if (seq._currentStep != currentBeat)
			{
				playingCurrent = seq.sequence[seq._currentStep - 1];

				if (playingCurrent)
				{
					animateTarget.GetComponent<MeshRenderer>().enabled = true;
					parts.Play(true);
					Debug.Log("OnBeat: " + seq._currentStep);
				}
				else
				{
					animateTarget.GetComponent<MeshRenderer>().enabled = false;
					Debug.Log("OffBeat: " + seq._currentStep);
				}
			currentBeat = seq._currentStep;
			}
		}
	}
}
