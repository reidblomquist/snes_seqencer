using UnityEngine;
using System.Collections;

public class HighlightOnPlay : MonoBehaviour {

	public GameObject animateTarget;
	public bool log;

	private Sequencer seq;
	private bool playingCurrent;
	private int currentBeat;
	private ParticleSystem parties;
	private MeshRenderer meshy;
	private int subSteps = 0;

	void Awake()
	{
		seq = transform.GetComponent<Sequencer>();
		parties = animateTarget.GetComponent<ParticleSystem>();
		meshy = animateTarget.GetComponent<MeshRenderer>();
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
					subSteps = 1;
					meshy.enabled = true;
					parties.Play(true);
					if (log)
					{
						Debug.Log("OnBeat: " + seq._currentStep);
						Debug.Log("subSteps: " + subSteps);
					}
				}
				else
				{
					meshy.enabled = false;
					if (log)
					{
						Debug.Log("OffBeat: " + seq._currentStep);
						Debug.Log("subSteps: " + subSteps);
					}
				}
			currentBeat = seq._currentStep;
			}
			else
			{
				subSteps++;
			}
			if (seq._currentStep == currentBeat && subSteps > seq.bpm * 0.04)
			{
				meshy.enabled = false;
			}
		}
	}
}
