using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sport.Views;
using Xamarin.Essentials;


namespace Sport
{
    public class UserRepository
    {
        string webAPIKey = "AIzaSyC_gO5-hpgTl07k2KhhWb_HdPLx6aXQYVs";
        FirebaseAuthProvider firebaseAuthProvider;

        public UserRepository()
        {
            firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        }

        public async Task<bool> Register(string email, string name, string password)
        {

            var token = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                
                return true;
            }
            return false;
        }

        public async Task<string> SignIn(string email, string password)
        {
            var token = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }

        public async Task<bool> ResetPassword(string email)
        {

            await firebaseAuthProvider.SendPasswordResetEmailAsync(email);
            return true;
        }
        public void SignOut()
        {
            // Discard the token
            Preferences.Set("token", null);
            Preferences.Set("userEmail", null); ;
            firebaseAuthProvider = null;

        }


        public async Task<string> ChangePassword(string token, string password)
        {
            var auth = await firebaseAuthProvider.ChangeUserPassword(token, password);
            return auth.FirebaseToken;
        }
    }
}
    