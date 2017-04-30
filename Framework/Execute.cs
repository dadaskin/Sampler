//
// Copied from Caliburn Micro
//

using System;
using System.Threading.Tasks;

namespace TextBoxSampler.Framework
{
    public static class Execute
    {
        public static bool InDesignMode
        {
            get { return PlatformProvider.Current.InDesignMode; }
        }

        public static void BeginOnUIThread(this Action action)
        {
            PlatformProvider.Current.BeginOnUIThread(action);
        }

        public static Task OnUIThreadAsync(this Action action)
        {
            return PlatformProvider.Current.OnUIThreadAsync(action);
        }

        public static void OnUIThread(this Action action)
        {
            PlatformProvider.Current.OnUIThread(action);
        }
    }
}
