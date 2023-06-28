namespace _01_Calories
{
    public class GlobalLogin
    {
        private static GlobalLogin instance;

        public string Login { get; set; }

        private GlobalLogin(){}

        public static GlobalLogin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalLogin();
                }
                return instance;
            }
        }
    }
}
