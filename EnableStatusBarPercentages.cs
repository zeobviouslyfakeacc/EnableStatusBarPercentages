using Harmony;
using UnityEngine;

[HarmonyPatch(typeof(Panel_FirstAid), "Start")]
public class EnableStatusBarPercentages {

	private static readonly Vector3 statusLabelOffset = new Vector3(-27, -6);
	private static readonly Vector3 conditionLabelOffset = new Vector3(71, -10);

	private static void Postfix(Panel_FirstAid __instance) {
		ActivateAndMoveStatusLabel(__instance.m_ColdPercentLabel);
		ActivateAndMoveStatusLabel(__instance.m_FatiguePercentLabel);
		ActivateAndMoveStatusLabel(__instance.m_ThirstPercentLabel);
		ActivateAndMoveStatusLabel(__instance.m_HungerPercentLabel);
		ActivateAndMoveConditionLabel(__instance.m_LabelConditionPercent);
	}

	private static void ActivateAndMoveStatusLabel(UILabel label) {
		label.pivot = UIWidget.Pivot.Center;
		label.gameObject.transform.localPosition += statusLabelOffset;
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
