#include "UnityAppController.h"

@interface MyPluginAppController : UnityAppController {}
@end

extern "C" {

// We have to manually register the Unity Audio Effect plugin.
struct UnityAudioEffectDefinition;
typedef int (*UnityPluginGetAudioEffectDefinitionsFunc)(
    struct UnityAudioEffectDefinition*** descptr);
extern void UnityRegisterAudioPlugin(
    UnityPluginGetAudioEffectDefinitionsFunc getAudioEffectDefinitions);
extern int UnityGetAudioEffectDefinitions(UnityAudioEffectDefinition*** definitionptr);

}  // extern "C"

@implementation MyPluginAppController

- (void)preStartUnity {
    [super preStartUnity];
    UnityRegisterAudioPlugin(&UnityGetAudioEffectDefinitions); // Initialize native audio plugins
}

@end

IMPL_APP_CONTROLLER_SUBCLASS( MyPluginAppController )
