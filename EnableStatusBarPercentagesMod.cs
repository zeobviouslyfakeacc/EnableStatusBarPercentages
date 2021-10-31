using MelonLoader;
using UnityEngine;

namespace EnableStatusBarPercentages {
	internal class EnableStatusBarPercentagesMod : MelonMod {
		public override void OnApplicationStart() {
			Debug.Log($"[{Info.Name}] version {Info.Version} loaded!");
		}
	}
}
