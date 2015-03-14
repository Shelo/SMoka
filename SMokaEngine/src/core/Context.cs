using System;

namespace SMokaEngine
{
    public abstract class Context
    {
        Application application;
        public Application Application
        {
            private get
            {
                return application;
            }

            set
            {
                if (application == null)
                {
                    application = value;
                }
            }
        }

        public abstract void Create();
        public abstract void Update();
    }
}

