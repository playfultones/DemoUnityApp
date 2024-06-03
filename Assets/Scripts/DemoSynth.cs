using System;
using System.Runtime.InteropServices;

public static class DemoSynth
{
#if UNITY_IPHONE
    const string libName = "__Internal";
#else
    const string libName = "audioplugin_DemoSynth";
#endif
    
    [DllImport(libName)]
    public static extern IntPtr getInstance();

    [DllImport(libName)]
    public static extern void noteOn(IntPtr ptr, int note, float velocity);
    public static void noteOn(int note, float velo)
    {
        if (getInstance() != IntPtr.Zero)
            noteOn(getInstance(), note, velo);
    }

    [DllImport(libName)]
    public static extern void noteOff(IntPtr ptr, int note);
    public static void noteOff(int note)
    {
        if (getInstance() != IntPtr.Zero)
            noteOff(getInstance(), note);
    }
}