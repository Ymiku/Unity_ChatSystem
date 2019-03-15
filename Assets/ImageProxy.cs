using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageProxy : Image {

	public override Material GetModifiedMaterial (Material baseMaterial)
	{
		return base.GetModifiedMaterial (baseMaterial);
	}
}
