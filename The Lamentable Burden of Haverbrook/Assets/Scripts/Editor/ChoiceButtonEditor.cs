using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChoiceButton))]
[CanEditMultipleObjects]
public class ChoiceButtonEditor : Editor {

	SerializedProperty suspicionValue;
	SerializedProperty happinessValue;
	SerializedProperty populationValue;
	SerializedProperty fanatacismValue;
	SerializedProperty hungerValue;
	SerializedProperty timeValue;
	SerializedProperty cowValue;
	SerializedProperty bloodValue;

	void OnEnable()
	{
		suspicionValue = serializedObject.FindProperty("suspicionValue");
		happinessValue = serializedObject.FindProperty("happinessValue");
		populationValue = serializedObject.FindProperty("populationValue");
		fanatacismValue = serializedObject.FindProperty("fanatacismValue");
		hungerValue = serializedObject.FindProperty("hungerValue");
		timeValue = serializedObject.FindProperty("timeValue");
		cowValue = serializedObject.FindProperty("cowValue");
		bloodValue = serializedObject.FindProperty("bloodValue");
	}

	public override void OnInspectorGUI()
	{
		ChoiceButton choiceButton = (ChoiceButton)target;

		serializedObject.Update();

		/* EditorGUILayout.PropertyField(suspicionValue);
		EditorGUILayout.PropertyField(happinessValue);
		EditorGUILayout.PropertyField(populationValue);
		EditorGUILayout.PropertyField(fanatacismValue);
		EditorGUILayout.PropertyField(hungerValue); */

		serializedObject.ApplyModifiedProperties();
		
		choiceButton.changeSuspicion = GUILayout.Toggle(choiceButton.changeSuspicion, "Change Suspicion On Press");
		choiceButton.changeHappiness = GUILayout.Toggle(choiceButton.changeHappiness, "Change Happiness On Press");
		choiceButton.changePopulation = GUILayout.Toggle(choiceButton.changePopulation, "Change Population on Press");
		choiceButton.changeFanatacism = GUILayout.Toggle(choiceButton.changeFanatacism, "Change Fanatacism on Press");
		choiceButton.changeHunger = GUILayout.Toggle(choiceButton.changeHunger, "Change Hunger on press");
		choiceButton.changeBlood = GUILayout.Toggle(choiceButton.changeBlood, "Change Blood on Press");
		choiceButton.changeCows = GUILayout.Toggle(choiceButton.changeCows, "Change Cows on Press");

		GUILayout.Space(20f);

		if(choiceButton.changeSuspicion)
		{
			choiceButton.suspicionValue = EditorGUILayout.FloatField("Change Suspicion By: " , choiceButton.suspicionValue);
		}

		if(choiceButton.changeHappiness)
		{
			choiceButton.happinessValue = EditorGUILayout.FloatField("Change Happiness by: " , choiceButton.happinessValue);
		}

		if(choiceButton.changePopulation)
		{
			choiceButton.populationValue = EditorGUILayout.FloatField("Change Population by: ", choiceButton.populationValue);
		}

		if(choiceButton.changeFanatacism)
		{
			choiceButton.fanatacismValue = EditorGUILayout.FloatField("Change Fanatacism by: ", choiceButton.fanatacismValue);
		}

		if(choiceButton.changeHunger)
		{
			choiceButton.hungerValue = EditorGUILayout.FloatField("Change Hunger by: ", choiceButton.hungerValue);
		}

		if(choiceButton.changeBlood)
		{
			choiceButton.bloodValue = EditorGUILayout.FloatField("Change Blood by: " , choiceButton.bloodValue);
		}

		if(choiceButton.changeCows)
		{
			choiceButton.cowValue = EditorGUILayout.FloatField("Change Cows by: ", choiceButton.cowValue);
		}

		if(choiceButton.changeSuspicion || choiceButton.changeHappiness || choiceButton.changePopulation
			|| choiceButton.changeFanatacism || choiceButton.changeHunger || choiceButton.changeBlood || choiceButton.changeCows)
		{
			choiceButton.timeValue = EditorGUILayout.FloatField("Change over seconds: ", choiceButton.timeValue);
		}

		GUILayout.Space(20f);
		
		DrawDefaultInspector();				
	}
}
