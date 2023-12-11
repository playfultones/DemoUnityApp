using System.Collections.Generic;
using UnityEngine;

public class DemoKeyboard : MonoBehaviour
{
    public void NoteOn(int noteNumber)
    {
        DemoSynth.noteOn(noteNumber, 1.0f);
    }

    public void NoteOff(int noteNumber)
    {
        DemoSynth.noteOff(noteNumber);
    }
}
