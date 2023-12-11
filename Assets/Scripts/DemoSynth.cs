using System;
using System.Runtime.InteropServices;

public static class DemoSynth
{
    const string iosLibName = "__Internal";
    const string macosLibName = "DemoSynth";
    
#if UNITY_IPHONE
    [DllImport(iosLibName)]
#else
    [DllImport(macosLibName)]
#endif
    private static extern IntPtr getInstance();


#if UNITY_IPHONE
    [DllImport(iosLibName)]
#else
    [DllImport(macosLibName)]
#endif
    public static extern void noteOn(IntPtr ptr, int note, float velocity);
    public static void noteOn(int note, float velo)
    {
        if (getInstance() != IntPtr.Zero)
            noteOn(getInstance(), note, velo);
    }

#if UNITY_IPHONE
    [DllImport(iosLibName)]
#else
    [DllImport(macosLibName)]
#endif
    public static extern void noteOff(IntPtr ptr, int note);
    public static void noteOff(int note)
    {
        if (getInstance() != IntPtr.Zero)
            noteOff(getInstance(), note);
    }
}