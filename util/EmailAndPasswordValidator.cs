namespace LoginComponent.util
{
    public class EmailAndPasswordValidator
    {
        public bool isEmailValid(string email)
        {
            if(email == null)
            {
                throw new ArgumentNullException("Invalid email");
            }
            
            // todo --> do more email checking according to contract 🙂

            return true;
        }

        public bool isPasswordValid(string password)
        {
            if(password.Length < 8)
            {
                throw new ArgumentOutOfRangeException("Invalid password");
            }
            
            // todo --> do more password checking according to contract 🙂

            return true;
        }
    }
}
