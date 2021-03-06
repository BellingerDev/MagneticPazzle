﻿using UnityEngine;
using System.Collections;


namespace Utils
{
	public class MaterialDSPController : MonoBehaviour
	{
	    [SerializeField]
		private MaterialDSPItem[] items;

	    private float amp;
	    private float[] smooth = new float[2];

	    void Start()
	    {
	        for (int i = 0; i < 2; i++)
				smooth[i] = 0.0f;

			foreach (var item in items)
				item.RestoreColor();
	    }

	    private void Update()
	    {
			foreach (var item in items)
				item.OnUpdate(amp);
	    }

	    void OnAudioFilterRead(float[] data, int channels)
	    {
	        for (var i = 0; i < data.Length; i = i + channels)
	        {
	            // the absolute value of every sample
	            float absInput = Mathf.Abs(data[i]);
	            // smoothening filter doing its thing
	            smooth[0] = ((0.01f * absInput) + (0.99f * smooth[1]));
	            // exaggerating the amplitude
	            amp = smooth[0] * 7;
	            // it is a recursive filter, so it is doing its recursive thing
	            smooth[1] = smooth[0];
	        }
	    }
	}
}