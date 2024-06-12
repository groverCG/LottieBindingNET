using Foundation;
using UIKit;
using ObjCRuntime;

namespace iOSLottieBinding;

// @interface SwiftLottieWrapper : NSObject
[BaseType (typeof(NSObject))]
public interface SwiftLottieWrapper
{
    // -(void)initAnimation __attribute__((objc_method_family("none")));
    [Export ("initAnimation")]
    void InitAnimation ();

    // -(void)setAnimationWithAnimation:(NSString * _Nonnull)animation;
    [Export ("setAnimationWithAnimation:")]
    void SetAnimationWithAnimation (string animation);

    // -(UIView * _Nonnull)getView __attribute__((warn_unused_result("")));
    [Export ("getView")]
    UIView View { get; }
}
