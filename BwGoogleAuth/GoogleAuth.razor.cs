using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Use the dotnet pack command rather than the NuGet.exe version nuget pack. To ship the static assets

//https://learn.microsoft.com/en-us/aspnet/core/razor-pages/ui-class?view=aspnetcore-3.1&tabs=visual-studio#consume-content-from-a-referenced-rcl

namespace BwGoogleAuth
{
    public partial class GoogleAuth
    {

     
        [Parameter]
        public String ClientId { get; set; }


        [Parameter]
        public bool Hide { get; set; } = false;

        [Parameter]
        public Credential UserCredential { get; set; }


        private DotNetObjectReference<GoogleAuth> objRef;


     

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {


            if (firstRender)
            {
                objRef = DotNetObjectReference.Create(this);


                await JsRuntime.InvokeVoidAsync("bwjs.initGoogle", new object[] { objRef, ClientId });
            }



        }

        [JSInvokable]
        public async Task SaveCredentials(string mycredential)
        {

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken decodedValue = handler.ReadJwtToken(mycredential);

            UserCredential.Email = (string)decodedValue.Payload["email"];

            UserCredential.UserId = (string)decodedValue.Payload["sub"];
                  
            UserCredential.Name = (string)decodedValue.Payload["given_name"];



            UserCredential.IsLogged = true;

           await UserCredentialChanged.InvokeAsync(UserCredential);

            StateHasChanged();
        }

        //Automatically binded by @bind
        //https://www.syncfusion.com/faq/blazor/components/how-do-you-pass-values-from-child-to-parent-using-eventcallback-in-blazor
        [Parameter]
        public EventCallback<Credential> UserCredentialChanged { get; set; }

        //private Task OnUserCredetialChanged(ChangeEventArgs e)
        //{
        
        //    return UserCredentialChanged.InvokeAsync(UserCredential);
        //}


        public void Dispose()
        {
            objRef?.Dispose();
        }



    }
}
