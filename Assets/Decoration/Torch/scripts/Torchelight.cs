using UnityEngine;
using System.Collections;

public class Torchelight : MonoBehaviour {
	
	public GameObject TorchLight;
	public GameObject MainFlame;
	public GameObject BaseFlame;
	public GameObject Sparks;
	public GameObject Smoke;
	public float MaxLightIntensity;
	public float IntensityLight;

	// Particle Systems and TorchLight
	private ParticleSystem.EmissionModule mainFlameEM, baseFlameEM, sparksEM, smokeEM;
	private Light torchLight;

	void Awake () {
		torchLight = TorchLight.GetComponent<Light> ();
		mainFlameEM = MainFlame.GetComponent<ParticleSystem> ().emission;
		baseFlameEM = BaseFlame.GetComponent<ParticleSystem> ().emission;
		sparksEM = Sparks.GetComponent<ParticleSystem> ().emission;
		smokeEM = Smoke.GetComponent<ParticleSystem> ().emission;
	}

	void Start () {
		torchLight.intensity = IntensityLight;
		mainFlameEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 20f);
		baseFlameEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 15f);
		sparksEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 7f);
		smokeEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 12f);
	}
	

	void Update () {
		if (IntensityLight<0) IntensityLight=0;
		if (IntensityLight>MaxLightIntensity) IntensityLight=MaxLightIntensity;

		torchLight.intensity = IntensityLight/2f+Mathf.Lerp(IntensityLight-0.1f,IntensityLight+0.1f,Mathf.Cos(Time.time*30));

		torchLight.color = new Color(Mathf.Min(IntensityLight/1.5f,1f),Mathf.Min(IntensityLight/2f,1f),0.3f);

		mainFlameEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight*20f);
		baseFlameEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight*15f);
		sparksEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight*7f);
		smokeEM.rate = new ParticleSystem.MinMaxCurve(IntensityLight*12f);

	}
}
