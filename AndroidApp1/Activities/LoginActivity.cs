using AndroidApp1.BaseClasses;
using Firebase.Database;

namespace AndroidApp1.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);
            
            Button loginButton = FindViewById<Button>(Resource.Id.buttonLogin);

            //sobrecarrega o m�todo de click
            loginButton.Click += LoginButton_Click;

        }
        private async void LoginButton_Click(object? sender, EventArgs e)
        {
            //Captura os valores dos campos de texto da tela
            var email = FindViewById<EditText>(Resource.Id.editTextEmail)?.Text;
            var password = FindViewById<EditText>(Resource.Id.editTextPassword)?.Text;

            //Conecta com o banco de dados Realtime Database do Firebase
            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/" );

            var usuario = (await firebase
                .Child("usuarios")
                .OnceAsync<Usuario>()).Select(item => new  Usuario
                {
                    Email = item.Object.Email,
                    Senha = item.Object.Senha,
                    Nome = item.Object.Nome
                }).Where(item => item.Email == email).FirstOrDefault();

            if (usuario != null)
            {
                if(usuario.Senha == password)
                {
                    Toast.MakeText(this, "Usu�rio Logado com sucesso!", ToastLength.Short)?.Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Senha incorreta. Digite novamente!", ToastLength.Short)?.Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Usu�rio n�o encontrado!", ToastLength.Short)?.Show();
            }

        }
    }
}