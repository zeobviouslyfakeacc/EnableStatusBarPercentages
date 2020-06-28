using MelonLoader;
using UnityEngine;

namespace EnableStatusBarPercentages {
	internal class EnableStatusBarPercentagesMod : MelonMod {
		public override void OnApplicationStart() {
			Debug.Log($"[{InfoAttribute.Name}] version {InfoAttribute.Version} loaded!");
		}
	}
}
