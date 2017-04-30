// 
// Copied from Caliburn Micro
//

namespace TextBoxSampler.Framework
{
    public class PlatformProvider
    {
        private static IPlatformProvider current = new DefaultPlatformProvider();

        public static IPlatformProvider Current
        {
            get { return current; }
            set { current = value; }
        }
    }
}
