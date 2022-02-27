using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TinyMayhem.Dialouge
{
    public class AnimateTextManager : MonoBehaviour
    {
        [SerializeField] TMP_Text textBox;
        private Coroutine _typeRoutine = null;
        private DialogueVertexAnimator _dialogueVertexAnimator;
        [SerializeField] private AudioClip typingClip;
        [SerializeField] private AudioSourceGroup audioSourceGroup;
        [TextArea] [SerializeField] private string objectiveText;

        private void Awake()
        {
            _dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
        }

        private void Start()
        {
            PlayDialogue(objectiveText);
        }

        void PlayDialogue(string message)
        {
            this.EnsureCoroutineStopped(ref _typeRoutine);
            _dialogueVertexAnimator.textAnimating = false;
            List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
            _typeRoutine =
                StartCoroutine(_dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
        }
    }
}