using UnityEngine;
using System.Collections;

public class HighlightOnPlay : MonoBehaviour {

	private Sequencer seq;
	private bool playingCurrent;
	private int currentBeat;

	void Awake ()
	{
		seq = transform.GetComponent<Sequencer>();
		Debug.Log(seq.sequence);
	}
	// Update is called once per frame
	void LateUpdate()
	{
		if (seq.IsPlaying)
		{
			if (seq._currentStep != currentBeat || currentBeat == null)
			{
				playingCurrent = seq.sequence[seq._currentStep - 1];

				if (playingCurrent)
				{
					Debug.Log("OnBeat: " + seq._currentStep);
				}
				else
				{
					Debug.Log("OffBeat: " + seq._currentStep);
				}
			currentBeat = seq._currentStep;
			}
		}
	}
}
