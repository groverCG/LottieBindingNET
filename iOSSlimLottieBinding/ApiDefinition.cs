using Foundation;
using UIKit;
using ObjCRuntime;

namespace iOSSlimLottieBinding;

// // @interface SwiftLottieWrapper : NSObject
// [BaseType (typeof(NSObject))]
// public interface SwiftLottieWrapper
// {
//     // -(void)initAnimation __attribute__((objc_method_family("none")));
//     [Export ("initAnimation")]
//     void InitAnimation ();
//
//     // -(void)setAnimationWithAnimation:(NSString * _Nonnull)animation;
//     [Export ("setAnimationWithAnimation:")]
//     void SetAnimationWithAnimation (string animation);
//
//     // -(UIView * _Nonnull)getView __attribute__((warn_unused_result("")));
//     [Export ("getView")]
//     UIView View { get; }
// }

[BaseType (typeof(NSObject))]
interface SwiftLottieWrapper
{
    // -(void)setAnimationWithAnimation:(NSString * _Nonnull)animation;
    [Export ("setAnimationWithAnimation:")]
    void SetAnimationWithAnimation (string animation);

    // -(void)playAnimation;
    [Export ("playAnimation")]
    void PlayAnimation ();

    // -(void)pauseAnimation;
    [Export ("pauseAnimation")]
    void PauseAnimation ();

    // -(void)stopAnimation;
    [Export ("stopAnimation")]
    void StopAnimation ();

    // -(UIView * _Nonnull)getView __attribute__((warn_unused_result("")));
    [Export ("getView")]
    UIView View { get; }
}