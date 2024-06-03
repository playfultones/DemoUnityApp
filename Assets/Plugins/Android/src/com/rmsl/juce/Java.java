package com.rmsl.juce;

import android.content.Context;

public class Java {
    static { System.loadLibrary("audioplugin_DemoSynth"); }
    public native static void initialiseJUCE(Context context);
}