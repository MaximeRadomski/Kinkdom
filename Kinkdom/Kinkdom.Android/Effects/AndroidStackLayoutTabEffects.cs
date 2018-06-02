using Kinkdom.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Kinkdom")]
[assembly: ExportEffect(typeof(StackLayoutTabEffect), "AndroidStackLayoutTabEffect")]

namespace Kinkdom.Droid.Effects
{
    public class AndroidStackLayoutTabEffects : PlatformEffect
    {
        protected override void OnAttached()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnDetached()
        {
            throw new System.NotImplementedException();
        }
    }
}