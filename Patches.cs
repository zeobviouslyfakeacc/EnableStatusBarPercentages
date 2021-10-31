using HarmonyLib;
using UnityEngine;

internal static class Patches {

	[HarmonyPatch(typeof(Panel_FirstAid), "Enable")]
	private static class EnableStatusBarPercentages {

		private static readonly Vector3 containerOffset = new Vector3(10, 5);
		private static readonly Vector3 statusLabelOffset = new Vector3(-72, -8);
		private static readonly Vector3 conditionLabelOffset = new Vector3(72, -10);

		private static bool initialized = false;

		private static void Prefix(Panel_FirstAid __instance) {
			if (initialized) return;
			initialized = true;

			CenterStatusLabel(__instance.m_ColdStatusLabel);
			CenterStatusLabel(__instance.m_FatigueStatusLabel);
			CenterStatusLabel(__instance.m_ThirstStatusLabel);
			CenterStatusLabel(__instance.m_HungerStatusLabel);

			ActivateAndMovePercentLabel(__instance.m_ColdPercentLabel);
			ActivateAndMovePercentLabel(__instance.m_FatiguePercentLabel);
			ActivateAndMovePercentLabel(__instance.m_ThirstPercentLabel);
			ActivateAndMovePercentLabel(__instance.m_HungerPercentLabel);

			ActivateAndMoveConditionLabel(__instance.m_LabelConditionPercent);
		}

		private static void CenterStatusLabel(UILabel label) {
			label.alignment = NGUIText.Alignment.Center;
			label.transform.localPosition += new Vector3(-label.width / 2, 0) + containerOffset;
		}

		private static void ActivateAndMovePercentLabel(UILabel label) {
			label.alignment = NGUIText.Alignment.Left;
			label.transform.localPosition += statusLabelOffset + containerOffset;
			label.fontSize = 14;

			label.enabled = true;
			NGUITools.SetActive(label.gameObject, true);
		}

		private static void ActivateAndMoveConditionLabel(UILabel label) {
			label.pivot = UIWidget.Pivot.Left;
			label.gameObject.transform.localPosition += conditionLabelOffset;

			label.enabled = true;
			NGUITools.SetActive(label.gameObject, true);
		}
	}

	[HarmonyPatch(typeof(WellFed), "Update")]
	private static class MoveConditionLabelWhenWellFed {

		private static readonly Vector3 wellFedOffset = new Vector3(22, 0);
		private static bool wellFedActive = false;

		private static void Postfix(WellFed __instance) {
			bool newActive = __instance.HasWellFed();
			if (newActive == wellFedActive) return;

			Transform labelTransform = InterfaceManager.m_Panel_FirstAid.m_LabelConditionPercent.transform;
			float moveDirection = newActive ? +1 : -1;
			labelTransform.localPosition += moveDirection * wellFedOffset;

			wellFedActive = newActive;
		}
	}
}
